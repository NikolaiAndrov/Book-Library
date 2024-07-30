namespace Library.Controllers
{
    using Library.Models.Book;
    using Library.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Security.Permissions;

    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<BookAllViewModel> books;

            try
            {
                books = await this.bookService.GetAllBooksAsync();
            }
            catch (Exception)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            IEnumerable<BookMineViewModel> myBooks;

            try
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                myBooks = await this.bookService.GetMyBooksAsync(userId);
            }
            catch (Exception)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return View(myBooks);
        }
    }
}
