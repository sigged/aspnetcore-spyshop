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
    public class CategoriesController : Controller
    {
        private readonly SpyShopContext _context;

        public CategoriesController(SpyShopContext context)
        {
            _context = context;
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
            var viewModel = new CategoriesIndexVm
            {
                Categories = await _context.Categories
                    .OrderBy(e => e.Name)
                    .ToListAsync()
            };
            return View(viewModel);
        }


        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return NotFound();

            //example usage of projection to a View Model with LINQ
            var viewModel = await _context.Categories
                .Select(c =>
                    new CategoriesEditVm
                    {
                        Id = c.Id,
                        Name = c.Name,
                        NumberOfProducts = c.Products.Count()
                    }
                )
                .FirstOrDefaultAsync(e => e.Id == id);

            if (viewModel == null)
                return NotFound();

            return View(viewModel);
        }

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            return View(new CategoriesCreateVm());
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriesCreateVm createVm)
        {
            if (ModelState.IsValid)
            {
                Category createCategory = new Category
                {
                    Name = createVm.Name
                };
                _context.Add(createCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createVm);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return NotFound();

            var viewModel = await _context.Categories
                .Select(c =>
                    new CategoriesEditVm
                    {
                        Id = c.Id,
                        Name = c.Name,
                        NumberOfProducts = c.Products.Count()
                    }
                )
                .FirstOrDefaultAsync(e => e.Id == id);

            if (viewModel == null)
                return NotFound();

            return View(viewModel);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, CategoriesEditVm editVm)
        {
            if (id != editVm.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    Category updatedCategory = _context.Categories.Find(editVm.Id);
                    updatedCategory.Id = editVm.Id;
                    updatedCategory.Name = editVm.Name;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(editVm.Id))
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
            return View(editVm);
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            return await Details(id);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(long id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}