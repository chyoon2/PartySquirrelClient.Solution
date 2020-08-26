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
  [Authorize]
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
      var user = await _userManager.FindByIdAsync(id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      List<SquirrelUser> userSquirrels = _db.SquirrelUser.Where(join => join.UserId == id).Include(join => join.Squirrel).ToList();
      List<PartyMessage> partyMessages = _db.PartyMessages.Where(message => message.UserId == id).Include(message => message.User).Include(message => message.UserFrom).ToList();
      PartyDetailsViewModel viewModel = new PartyDetailsViewModel(); 
      viewModel.User = user;
      viewModel.CurrentUser = currentUser;
      viewModel.SquirrelCount = userSquirrels.Count();
      viewModel.PartyMessages = partyMessages;
      int currentColumn = 1;
      foreach(SquirrelUser join in userSquirrels)
      {
        if (currentColumn == 1)
        {
          viewModel.Column1.Add(join);
        }
        if (currentColumn == 2)
        {
          viewModel.Column2.Add(join);
        }
        if (currentColumn == 3)
        {
          viewModel.Column3.Add(join);
        }
        if (currentColumn < 3)
        {
          currentColumn ++;
        }
        else
        {
          currentColumn = 1;
        }
      }
      return View(viewModel);
    }
  }
}