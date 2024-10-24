using Microsoft.EntityFrameworkCore;
using UpSkillingTask.DTOs.CategoryDtos;
using UpSkillingTask.Models;
using UpSkillingTask.Services.Interfaces;

namespace UpSkillingTask.Services.Implemention
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            return await _context.Categories
                .Select(category => new CategoryDto
                {
                    CategoryId = category.Id,
                    Name = category.Name,
                    Description = category.Description
                })
                .ToListAsync();
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.Where(x => x.Id == id)
                .Select(category => new CategoryDto
                {
                    CategoryId = category.Id,
                    Name = category.Name,
                    Description = category.Description
                }).FirstOrDefaultAsync();


            return category;
        }

        public async Task<bool> AddCategoryAsync(AddCategoryDto addCategoryDto)
        {
            try
            {

                var category = new Category
                {
                    Name = addCategoryDto.Name,
                    Description = addCategoryDto.Description
                };

                _context.Categories.Add(category);
                var saved = await _context.SaveChangesAsync();
                return saved > 0;
            }
            catch (Exception)
            {

               return false;
            }

        }

        public async Task<bool> UpdateCategoryAsync(int id, EditCategoryDto editCategoryDto)
        {

            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return false;
                }


                category.Name = editCategoryDto.Name;
                category.Description = editCategoryDto.Description;

                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                var deleted = await _context.SaveChangesAsync();
                return deleted > 0; 
            }
            return false; 
        }
    }
}
