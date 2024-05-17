using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using FMS.Models;

namespace FMS.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    #region RegisterBasic

    [HttpGet]
    [AllowAnonymous]
    public IActionResult RegisterBasic()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterBasic(Register register)
    {
        IdentityResult _result = new();

        try
        {
            if (ModelState.IsValid)
            {
                User _user = new User()
                {
                    Name = register.Name,
                    Email = register.Email,
                    UserName = register.UserName,
                    PhoneNumber = register.PhoneNumber,
                };

                var user = await _userManager.FindByNameAsync(register.UserName!);

                if (user == null)
                {
                    _result = await _userManager.CreateAsync(_user, register.Password!);

                    if (_result.Succeeded)
                    {
                        if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                        {
                            await _roleManager.CreateAsync(new IdentityRole("admin"));
                        }
                        await _userManager.AddToRoleAsync(_user, "admin");

                        return RedirectToAction("LoginBasic", "Auth");
                    }
                    else
                    {
                        ViewData["ValidateMessage"] = _result.Errors.ToList()[0].Description;
                        return View();
                    }
                }
                else
                {
                    ViewData["ValidateMessage"] = "UserName alreday there";
                    return View();
                }
            }

            return View();
        }
        catch (Exception)
        {

            throw;
        }

    }

    #endregion

    #region Login / LogOut Basic

    [HttpGet]
    [AllowAnonymous]
    public IActionResult LoginBasic()
    {
        //Check User alreday login or not
        ClaimsPrincipal claimsPrincipal = HttpContext.User;

        return claimsPrincipal.Identity!.IsAuthenticated ? RedirectToAction("Index", "Dashboards", new { area = "" }) : View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginBasic(Login login)
    {
        try
        {
            User _user = new User();

            if (ModelState.IsValid)
            {
                if (login.UserName != null)
                {
                    //Find The UserName
                    _user = await _userManager.FindByNameAsync(login.UserName!);
                    if (_user != null && !_user.EmailConfirmed)
                        _user.EmailConfirmed = true;
                }

                var result = await _signInManager.PasswordSignInAsync(login.UserName!, login.Password!, login.KeepLoggedIn, lockoutOnFailure: false);

                //Verify the credential
                if (result.Succeeded)
                {
                    _user.LastLogin = DateTime.Now;
                    await _userManager.UpdateAsync(_user);

                    var roles = await _userManager.GetRolesAsync(_user);

                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,login.UserName!),
                        new Claim(ClaimTypes.Role,roles.FirstOrDefault()!),
                new Claim("OtherProperties","Example Role")
                };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = login.KeepLoggedIn
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);

                    return RedirectToAction("Index", "Dashboards", new { area = "" });
                }
                else
                {
                    ViewData["ValidateMessage"] = "Check you login credentails and try again";
                    return View(login);
                    //return Unauthorized("Check you login credentails and try again");
                }
            }
            else
            {
                return View(login);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IActionResult> LogOut()
    {
        //await _signInManager.SignOutAsync();
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("LoginBasic", "Auth", new { area = "" });
    }

    #endregion


    public IActionResult ForgotPasswordBasic() => View();
}
