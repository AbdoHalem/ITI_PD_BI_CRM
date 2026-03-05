using Day1.Models.ViewModel;
using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Day1.Controllers
{
    public class AccountController : Controller
    {
        IEntityRepo<User> userRepo;
        public AccountController(IEntityRepo<User> _userRepo)
        {
            userRepo = _userRepo;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            // 1. Search for the user using the Repository
            // The FindAll method in UserRepo already includes UserRoles
            var user = userRepo.FindAll(u => u.UserName == model.UserName && u.Password == model.Password).FirstOrDefault();
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Username or Password.");
                return View(model);
            }
            // Create claims for the logged-in user
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.UserEmail)
            };
            // Add roles if the user has any
            if (user.UserRoles != null)
            {
                foreach (var userRole in user.UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole.Role));
                }
            }
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        //public async Task<IActionResult> Login(LoginVM model)
        //{
        //    // 1. Search for the user using the Repository
        //    // Simulate a login case
        //    if (model.UserName == "Aly") // Wrong login
        //    {
        //        ModelState.AddModelError("", "username or password is incorrect");
        //        return View(model);
        //    }
        //    // Correct Login
        //    Claim c1 = new Claim(ClaimTypes.Name, model.UserName);
        //    Claim c2 = new Claim(ClaimTypes.Email, "a@a.a");
        //    Claim c3 = new Claim(ClaimTypes.Role, "Admin");
        //    Claim c4 = new Claim(ClaimTypes.Role, "Instructor");
        //    ClaimsIdentity ci = new ClaimsIdentity("Cookies");
        //    ci.AddClaim(c1);
        //    ci.AddClaim(c2);
        //    ci.AddClaim(c3);
        //    ci.AddClaim(c4);
        //    ClaimsPrincipal cp = new ClaimsPrincipal();
        //    cp.AddIdentity(ci);
        //    await HttpContext.SignInAsync(cp);
        //    return RedirectToAction("Index", "Home");
        //}

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if(ModelState.IsValid)
            {
                // Check if username already exists in the database
                if (userRepo.FindAll(u => u.UserName == model.UserName).Any())
                {
                    ModelState.AddModelError("UserName", "Username already exists.");
                    return View(model);
                }
                // Create a new User object without setting the Id
                // The database will automatically generate the Id (Identity)
                User newUser = new User
                {
                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    Password = model.Password
                };
                // Add a default role for the new user
                newUser.UserRoles.Add(new UserRole { Role = "Student" });
                // Save the user to the database
                userRepo.Add(newUser);
                return RedirectToAction("Login");
            }
            return View(model);
        }
    }
}
