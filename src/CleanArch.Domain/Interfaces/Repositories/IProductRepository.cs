using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductCategoryAsync();
        Task<Product> GetByIdAsync();
        Task<Product> CreateAsync();
        Task<Product> UpdateAsync();
        Task<Product> DeleteAsync();
    }
}