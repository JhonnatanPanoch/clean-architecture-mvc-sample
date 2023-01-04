using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetByIdAsync();
        Task<Category> CreateAsync();
        Task<Category> UpdateAsync();
        Task<Category> DeleteAsync();
    }
}