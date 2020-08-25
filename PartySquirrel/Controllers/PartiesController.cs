using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartySquirrel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PartySquirrel.ViewModels;

namespace PartySquirrel.Controllers
{
  public class PartiesController : Controller
  {
    private readonly PartySquirrelContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public PartiesController(PartySquirrelContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    } 
    public IActionResult Index() //Party Index. see all the other users parties
    {
      List<ApplicationUser> allUsers = _userManager.Users.ToList();
      return View(allUsers);
    }

    public async Task<ActionResult> Details(string id)
    {
      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
      // SquirrelUser profile = new SquirrelUser();
      var user = await _userManager.FindByIdAsync(id);
      //var profile = _db.SquirrelUser.Include(join => join.User).FirstOrDefault(join => join.UserId == id);
      ViewBag.FirstName = user.FirstName;
      var userSquirrels = _db.SquirrelUser.Where(join => join.UserId == id).Include(join => join.Squirrel).ToList();

      return View(userSquirrels);
    }
  }
}