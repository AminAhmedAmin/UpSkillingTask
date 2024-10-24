using UpSkillingTask.DTOs.CategoryDtos;

namespace UpSkillingTask.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<bool> AddCategoryAsync(AddCategoryDto addCategoryDto);
        Task<bool> UpdateCategoryAsync(int id, EditCategoryDto editCategoryDto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
