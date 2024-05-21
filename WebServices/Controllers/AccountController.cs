using Core.Dots;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
  
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

           
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto dto)
        {


            if (ModelState.IsValid)
            {
              
                var user = new ApplicationUser()
                {
                    UserName = dto.UserName,
                    Email = dto.UserEmail,
                    PhoneNumber = dto.UserPhone,

                };
                //create user
                user.Id = Guid.NewGuid().ToString();
                var result = await _userManager.CreateAsync(user, dto.Password);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                return RedirectToAction("Register", "Account");
            }









               }
     

        public IActionResult Login()
            {
                return View();
            }
          
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user is not null)
                {
                    var password = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                    if (password)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                        if (result.Succeeded)
                            return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ViewBag.ErrorLogin = false;
                        //ModelState.AddModelError(string.Empty, "Invalid Password");
                    }
                }
                else
                {
                    ViewBag.ErrorLogin = false;
                    //ModelState.AddModelError(string.Empty, "Invalid Email");
                }
            }
            return View(loginViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //return RedirectToAction(nameof(Login));
            return RedirectToAction("Index", "Home");

        }


    }

}




