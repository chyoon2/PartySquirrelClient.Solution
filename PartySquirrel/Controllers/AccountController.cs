
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PartySquirrel.Models;
using System.Threading.Tasks;
using PartySquirrel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;

namespace PartySquirrel.Controllers
{
  public class AccountController: Controller
  {
    private readonly PartySquirrelContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PartySquirrelContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);

      return View(currentUser);
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.Email, FirstName = model.FirstName, LastName = model.LastName };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }

    public async Task<ActionResult> Edit(string id)
    {
      var user = await _userManager.FindByIdAsync(id);
      var model = new RegisterViewModel { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName };
      return View(model);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(RegisterViewModel model, string id)
    {
      var user = await _userManager.FindByIdAsync(id);
      user.Email = model.Email;
      user.FirstName = model.FirstName;
      user.LastName = model.LastName;
      if (!String.IsNullOrEmpty(model.Password)) {
        await _userManager.RemovePasswordAsync(user);
        await _userManager.AddPasswordAsync(user, model.Password);
      }
      var result = await _userManager.UpdateAsync(user);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }
  }
}