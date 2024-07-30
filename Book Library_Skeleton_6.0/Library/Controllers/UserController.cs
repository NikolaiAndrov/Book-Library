namespace Library.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Library.Models.User;
    using Library.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        
        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            bool isAuthenticated = this.User?.Identity?.IsAuthenticated ?? false;

            if (isAuthenticated == false)
            {
                return this.View();
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterFormModel model)
        {
            bool isAuthenticated = this.User?.Identity?.IsAuthenticated ?? false;

            if (isAuthenticated == false)
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(model);
                }

                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password
                };

                await this.userManager.SetEmailAsync(user, model.Email);
                await this.userManager.SetUserNameAsync(user, model.UserName);

                IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        this.ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return this.View(model);
                }

                return this.RedirectToAction(nameof(this.Login));
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            bool isAuthenticated = this.User?.Identity?.IsAuthenticated ?? false;

            if (isAuthenticated == false)
            {
                return this.View();
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginFormModel model)
        {
            bool isAuthenticated = this.User?.Identity?.IsAuthenticated ?? false;

            if (isAuthenticated == false)
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(model);
                }

                var result = await this.signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (!result.Succeeded)
                {
                    return this.View(model);
                }

                return this.RedirectToAction("All", "Book");
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return this.RedirectToAction("Index", "Home");
        }
    }
}
