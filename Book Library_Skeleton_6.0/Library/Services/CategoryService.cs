namespace Library.Services
{
    using Library.Data;
    using Library.Models.Category;
    using Library.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly LibraryDbContext dbContext;

        public CategoryService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            IEnumerable<CategoryViewModel> categories = await this.dbContext.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return categories;
        }

        public async Task<bool> IsCategoryExistingByIdAsync(int id)
        {
            bool isCategoryExisting = await this.dbContext.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Id == id);

            return isCategoryExisting;
        }
    }
}
