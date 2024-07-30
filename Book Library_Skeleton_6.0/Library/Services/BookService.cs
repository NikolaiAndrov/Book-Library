namespace Library.Services
{
    using Library.Data;
    using Library.Data.Models;
    using Library.Models.Book;
    using Library.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookAsync(BookAddPostModel model)
        {
            Book book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId,
            };

            await this.dbContext.Books.AddAsync(book);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddToCollectionAsync(int bookId, string userId)
        {
            ApplicationUserBook applicationUserBook = new ApplicationUserBook
            {
                BookId = bookId,
                ApplicationUserId = userId
            };

            await this.dbContext.ApplicationUsersBooks.AddAsync(applicationUserBook);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookAllViewModel>> GetAllBooksAsync()
        {
            IEnumerable<BookAllViewModel> books = await this.dbContext.Books
                .AsNoTracking()
                .Select(b => new BookAllViewModel
                {
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Title = b.Title,
                    Author = b.Author,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToArrayAsync();

            return books;
        }

        public async Task<IEnumerable<BookMineViewModel>> GetMyBooksAsync(string userId)
        {
            IEnumerable<BookMineViewModel> myBooks = await this.dbContext.ApplicationUsersBooks
                .AsNoTracking()
                .Where(ub => ub.ApplicationUserId == userId)
                .Select(ub => new BookMineViewModel
                {
                    Id = ub.Book.Id,
                    ImageUrl = ub.Book.ImageUrl,
                    Title = ub.Book.Title,
                    Author = ub.Book.Author,
                    Description = ub.Book.Description,
                    Category = ub.Book.Category.Name
                })
                .ToArrayAsync();

            return myBooks;
        }

        public async Task<bool> IsBookExistingByIdAsync(int bookId)
        {
            bool isExisting = await this.dbContext.Books
                .AsNoTracking()
                .AnyAsync(b => b.Id == bookId);

            return isExisting;
        }

        public async Task<bool> IsInCollectionAsync(int bookId, string userId)
        {
            bool isInCollection = await this.dbContext.ApplicationUsersBooks
                .AsNoTracking()
                .AnyAsync(ub => ub.ApplicationUserId == userId && ub.BookId == bookId);

            return isInCollection;
        }

        public async Task RemoveFromCollectionAsync(int bookId, string userId)
        {
            ApplicationUserBook applicationUserBook = await this.dbContext.ApplicationUsersBooks
                .FirstAsync(ub => ub.BookId == bookId && ub.ApplicationUserId == userId);

            this.dbContext.ApplicationUsersBooks.Remove(applicationUserBook);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
