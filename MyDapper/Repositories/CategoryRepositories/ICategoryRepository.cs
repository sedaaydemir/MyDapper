using MyDapper.Dtos.CategoryDtos;

namespace MyDapper.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id);

    }
}
