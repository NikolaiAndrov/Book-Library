namespace Library.Services.Interfaces
{
    using Library.Models.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
