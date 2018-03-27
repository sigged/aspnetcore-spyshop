using CoreCourse.Spyshop.Domain;
using CoreCourse.Spyshop.Domain.Catalog;
using CoreCourse.Spyshop.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IRepository<Category, long> _cRepository;

        public CategoriesController(IRepository<Category, long> cRepository)
        {
            _cRepository = cRepository;
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
            var viewModel = new CategoriesIndexVm
            {
                Categories = await _cRepository.GetAll()
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
            var viewModel = await _cRepository.GetAll()
                .Select(c =>
                    new CategoriesEditVm {
                        Id = c.Id,
                        Name = c.Name,
                        NumberOfProducts = c.Products.Count()
                    }
                )
                .SingleOrDefaultAsync(e => e.Id == id);

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
                Category createCategory = new Category {
                    Name = createVm.Name
                };
                await _cRepository.AddAsync(createCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(createVm);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return NotFound();

            var viewModel = await _cRepository.GetAll()
                .Select(c =>
                    new CategoriesEditVm {
                        Id = c.Id,
                        Name = c.Name,
                        NumberOfProducts = c.Products.Count()
                    }
                )
                .SingleOrDefaultAsync(e => e.Id == id);

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
                    Category updatedCategory = await _cRepository.GetByIdAsync(editVm.Id);
                    updatedCategory.Id = editVm.Id;
                    updatedCategory.Name = editVm.Name;
                    await _cRepository.UpdateAsync(updatedCategory);
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
            var category = await _cRepository.GetByIdAsync(id);
            await _cRepository.DeleteAsync(category);
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(long id)
        {
            return _cRepository.GetAll().Any(e => e.Id == id);
        }
    }
}
