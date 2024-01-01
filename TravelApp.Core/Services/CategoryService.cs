using Microsoft.EntityFrameworkCore;
using TravelApp.Core.Contracts;
using TravelApp.Core.DTOModels;
using TravelApp.Infrastructure.Data;
using TravelApp.Infrastructure.Data.Entities;

namespace TravelApp.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly TravelAppDbContext context;

        public CategoryService(TravelAppDbContext _context)
        {
            context = _context;
        }

        public async Task CreateAsync(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name
            };

            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await context.Categories.FindAsync(id);

            if (category != null)
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await context.Categories.Select(c => new CategoryDto
            {
                Name = c.Name
            })
            .ToListAsync();
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await context.Categories.FindAsync(id);

            if (category == null)
            {
                throw new ArgumentException("Category not found");
            }

            return new CategoryDto
            {
                Name = category.Name
            };
        }

        public async Task UpdateAsync(CategoryDto categoryDto)
        {
            var categoryToUpdate = await context.Categories.FindAsync(categoryDto.Id);

            if (categoryToUpdate == null)
            {
                throw new ArgumentException("Category not found");
            }

            categoryToUpdate.Name = categoryDto.Name;

            await context.SaveChangesAsync();
        }
    }
}
