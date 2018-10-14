using CoreCourse.Spyshop.Domain.Catalog;
using CoreCourse.Spyshop.Web.Areas.Admin.ViewModels;
using CoreCourse.Spyshop.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly SpyShopContext _context;
        private readonly IHostingEnvironment _env;

        public ProductsController(SpyShopContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var viewModel = new ProductsIndexVm
            {
                Products = await _context.Products
                    .OrderBy(e => e.SortNumber).ThenBy(e => e.Name).ToListAsync()
            };
            return View(viewModel);
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(e => e.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductsDetailsVm
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PhotoUrl = product.PhotoUrl,
                Price = product.Price,
                SortNumber = product.SortNumber,
                CategoryName = product.Category.Name
            };

            return View(viewModel);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            var viewModel = new ProductsCreateVm
            {
                Price = 0
            };
            viewModel.AvailableCategories = _context.Categories.OrderBy(e => e.Name);
            return View(viewModel);
        }

        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductsCreateVm createVm)
        {
            if (ModelState.IsValid)
            {
                Category category = _context.Categories.Find(createVm.CategoryId.Value);

                if (category != null) {
                    Product createdProduct = new Product
                    {
                        Name = createVm.Name,
                        Description = createVm.Description,
                        Price = createVm.Price,
                        PhotoUrl = createVm.PhotoUrl,
                        SortNumber = createVm.SortNumber,
                        Category = category
                    };
                    createdProduct.PhotoUrl = await SaveProductImage(createVm.UploadedImage);

                    _context.Add(createdProduct);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(nameof(createVm.CategoryId), "This category doesn't exist");
                }
            }
            createVm.AvailableCategories = _context.Categories.OrderBy(e => e.Name);
            return View(createVm);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.Products
                .Include(e => e.Category)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            var viewModel = new ProductsEditVm
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PhotoUrl = product.PhotoUrl,
                Price = product.Price,
                SortNumber = product.SortNumber,
                CategoryId = product.Category.Id,
                AvailableCategories = _context.Categories.OrderBy(e => e.Name)
            };

            return View(viewModel);
        }


        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ProductsEditVm editVm)
        {
            if (id != editVm.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    Category category = _context.Categories.Find(editVm.CategoryId.Value);

                    if(category != null)
                    {
                        Product updatedProduct = _context.Products.Find(editVm.Id);
                        updatedProduct.Id = editVm.Id;
                        updatedProduct.Name = editVm.Name;
                        updatedProduct.Description = editVm.Description;
                        updatedProduct.Price = editVm.Price;
                        updatedProduct.SortNumber = editVm.SortNumber;
                        updatedProduct.Category = category;

                        if (editVm.UploadedImage != null)
                        {
                            DeleteProductImage(updatedProduct);
                            updatedProduct.PhotoUrl = await SaveProductImage(editVm.UploadedImage);
                        }

                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(editVm.CategoryId), "This category doesn't exist");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(editVm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            editVm.AvailableCategories = _context.Categories.OrderBy(e => e.Name);
            return View(editVm);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            return await Details(id);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product = await _context.Products.FindAsync(id);

            DeleteProductImage(product);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        private async Task<string> SaveProductImage(IFormFile file)
        {
            string uniqueFileName = Guid.NewGuid().ToString("N") + file.FileName;
            string savePath = Path.Combine(_env.WebRootPath, "images", "products", uniqueFileName);

            using (var newfileStream = new FileStream(savePath, FileMode.Create))
            {
                await file.CopyToAsync(newfileStream);
            }
            return uniqueFileName;
        }

        private void DeleteProductImage(Product product)
        {
            if (!string.IsNullOrWhiteSpace(product?.PhotoUrl))
            {
                string deletePath = Path.Combine(_env.WebRootPath, "images", "products", product?.PhotoUrl);
                System.IO.File.Delete(deletePath);
            }
        }
    }
}
