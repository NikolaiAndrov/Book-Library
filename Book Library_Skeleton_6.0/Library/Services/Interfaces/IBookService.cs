namespace Library.Services.Interfaces
{
    using Library.Models.Book;

    public interface IBookService
    {
        Task<IEnumerable<BookAllViewModel>> GetAllBooksAsync();
    }
}
