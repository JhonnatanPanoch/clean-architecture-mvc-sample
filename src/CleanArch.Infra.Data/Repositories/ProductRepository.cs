using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Repositories;
using CleanArch.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Product model)
        {
            _context.Products.Add(model);
            var result =await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var model = await _context.Products.FindAsync(id);

            _context.Products.Remove(model);

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var model = await _context.Products.FindAsync(id);
            return model;
        }

        public async Task<Product> GetProductCategoryAsync(int id)
        {
            var model = await _context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return model;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return  await _context.Products.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Product model)
        {
            _context.Products.Update(model);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}