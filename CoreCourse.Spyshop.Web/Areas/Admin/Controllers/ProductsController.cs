using CoreCourse.Spyshop.Domain.Catalog;
using CoreCourse.Spyshop.Web.Areas.Admin.ViewModels;
using CoreCourse.Spyshop.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly SpyShopContext _context;

        public ProductsController(SpyShopContext context)
        {
            _context = context;
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
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
                        Product updatedProduct = new Product
                        {
                            Id = editVm.Id,
                            Name = editVm.Name,
                            Description = editVm.Description,
                            Price = editVm.Price,
                            PhotoUrl = editVm.PhotoUrl,
                            SortNumber = editVm.SortNumber,
                            Category = category
                        };
                        _context.Update(updatedProduct);
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
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
