namespace Cards.Controllers
{
    using Cards.Data.Models;
    using Cards.Models.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signManager;

        public UsersController(SignInManager<User> signManager, UserManager<User> userManager)
        {
            this.signManager = signManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return this.View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserFormModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var newUser = new User
            {
                UserName = user.Name,
                Email = user.Email,
            };
            //parolata e heshirana podava se dolu

            var result = await this.userManager.CreateAsync(newUser, user.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginForm user)
        {

            var logeetUser = await this.userManager.FindByNameAsync(user.Name);

            if (logeetUser == null)
            {
                return gre6ki(user);
            }

            var passworValid = await this.userManager.CheckPasswordAsync(logeetUser, user.Password);

            if (!passworValid)
            {
                return gre6ki(user);
            }



            await this.signManager.SignInAsync(logeetUser, true);

            //dokato sam ne se razlogne  6te stoi lognat
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ChangePassword()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var userID = this.userManager.GetUserId(this.User);

            var userID2 = this.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var userName =  this.userManager.GetUserName(this.User);


            return this.View();
        }

        private IActionResult gre6ki(UserLoginForm user)
        {
            var error = "Gre6ka";

            ModelState.AddModelError(string.Empty, error);

            return View(user);
        }
    }
}
