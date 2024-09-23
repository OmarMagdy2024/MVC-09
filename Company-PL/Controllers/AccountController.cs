using Company_DAL.Models;
using Company_PL.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Company_PL.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _UserManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_UserManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpVM signupvm)
		{
			if (ModelState.IsValid)
			{
				var model = new ApplicationUser()
				{
					UserName = $"{signupvm.FName}{signupvm.LName}",
					Email = signupvm.Email,
					IsAgree = signupvm.IsAgree
				};
				var result = await _UserManager.CreateAsync(model, signupvm.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("SignIn");
				};
				foreach (var Errors in result.Errors)
				{
					ModelState.AddModelError(string.Empty, Errors.Description);
				}
			}
			return View(signupvm);
		}

		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		//[Authorize]
		public async Task<IActionResult> SignIn(SignInVM signipvm)
		{
			if (ModelState.IsValid)
			{
				var User = await _UserManager.FindByEmailAsync(signipvm.Email);
                if (User is not null)
                {
                    if (await _UserManager.CheckPasswordAsync(User,signipvm.Password))
                    {
						var result = await _signInManager.PasswordSignInAsync(User, signipvm.Password, signipvm.RememberMe, false);
                        if (result.Succeeded)
                        {
							return RedirectToAction(nameof(HomeController.Index),"Home");
                        }
					}
					ModelState.AddModelError(string.Empty, "An Email Or Password Are UnCorrect");
				}
				ModelState.AddModelError(string.Empty, "Invalid Login");
            }
			return View(signipvm);
		} 

		public async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(SignIn));
		}

		public IActionResult ForgetPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ForgetPassword(ForgetPasswordVM resetPasswordVM)
		{
			if (ModelState.IsValid)
			{
				var user = await _UserManager.FindByEmailAsync(resetPasswordVM.Email);
				if (user is not null)
				{
					var token = await _UserManager.GeneratePasswordResetTokenAsync(user);
					var resetpasswordurl = Url.Action("ResetPassword", "Account", new { email = resetPasswordVM.Email ,token = token});
					var email = new Email()
					{
						Supject = "Reset You Supject",
						Resipiant = resetPasswordVM.Email,
						Body = resetpasswordurl
					};
					Helper.SendEmail(email);
					return RedirectToAction(nameof(CheckYourInbox));
				}
				ModelState.AddModelError(string.Empty, "Invalid Email");
            }
			return View(resetPasswordVM);
        }

		public IActionResult CheckYourInbox()
		{  return View(); }

		public IActionResult ResetPassword(string email,string token)
		{
			TempData["Email"]=email;
			TempData["Token"]=token;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
		{
			if (ModelState.IsValid)
			{
				var user= await _UserManager.FindByEmailAsync(TempData["Email"] as string);
				var result = await _UserManager.ResetPasswordAsync(user, TempData["Token"] as string, resetPasswordVM.Password);
				if(result.Succeeded)
				{
					return RedirectToAction(nameof(SignIn));
				}
                foreach (var item in result.Errors)
                {
					ModelState.AddModelError(string.Empty, item.Description);
                }
			}
			return View(resetPasswordVM);
		}
	}
}
