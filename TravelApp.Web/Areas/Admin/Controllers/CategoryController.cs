using Microsoft.AspNetCore.Mvc;
using TravelApp.Core.Contracts;
using TravelApp.Core.DTOModels;
using TravelApp.Web.Areas.Admin.Controllers;

namespace TravelApp.Web.Controllers
{
    public class CategoryController : BaseAdminController
    {

        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllAsync();
            return View(categories);
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var category = await categoryService.GetByIdAsync(id);
                return View(category);
            }
            catch (Exception)
            {
                throw new ArgumentException("Category not found");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await categoryService.CreateAsync(categoryDto);
                return RedirectToAction(nameof(Index));
            }

            return View(categoryDto);
        }


        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var category = await categoryService.GetByIdAsync(id);
                return View(category);
            }
            catch (Exception)
            {
                throw new ArgumentException("Category not found");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await categoryService.UpdateAsync(categoryDto);
                }
                catch (Exception)
                {

                    throw new ArgumentException("Category not found");
                }
                return RedirectToAction(nameof(Index));
            }

            return View(categoryDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var category = await categoryService.GetByIdAsync(id);
                return View(category);
            }
            catch (Exception)
            {
                throw new ArgumentException("Category not found");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
