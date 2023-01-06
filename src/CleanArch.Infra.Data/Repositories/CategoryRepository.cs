using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Repositories;
using CleanArch.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Category model)
        {
            _context.Categories.Add(model);
            var saveResult = await _context.SaveChangesAsync();

            return saveResult > 0;
        }

        public async Task<bool> UpdateAsync(Category model)
        {
            _context.Categories.Update(model);
            var saveResult = await _context.SaveChangesAsync();

            return saveResult > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _context.Categories.Remove(await _context.Categories.FindAsync(id));
            var saveResult =  await _context.SaveChangesAsync();
            
            return saveResult > 0;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
