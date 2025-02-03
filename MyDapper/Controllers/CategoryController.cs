using Microsoft.AspNetCore.Mvc;
using MyDapper.Dtos.CategoryDtos;
using MyDapper.Repositories;
using MyDapper.Repositories.CategoryRepositories;

namespace MyDapper.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task< IActionResult> CategoryList()
        {
            var values =await _categoryRepository.GetAllCategoryAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryRepository.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var values =await _categoryRepository.GetByIdCategoryAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
           await _categoryRepository.UpdateCategoryAsync(updateCategoryDto);
           return RedirectToAction("CategoryList");
        }
    }
}
