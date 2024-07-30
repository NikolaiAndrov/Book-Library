namespace Library.Services.Interfaces
{
    using Library.Models.Book;

    public interface IBookService
    {
        Task<IEnumerable<BookAllViewModel>> GetAllBooksAsync();

        Task<IEnumerable<BookMineViewModel>> GetMyBooksAsync(string userId);

        Task AddBookAsync(BookAddPostModel model);

        Task AddToCollectionAsync(int bookId, string userId);

        Task<bool> IsBookExistingByIdAsync(int bookId);

        Task<bool> IsInCollectionAsync(int bookId, string userId);

        Task RemoveFromCollectionAsync(int bookId, string userId);
    }
}
