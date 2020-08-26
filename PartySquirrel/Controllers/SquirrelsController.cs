using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
  public class SquirrelsController : Controller
  {
    private readonly PartySquirrelContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public SquirrelsController(PartySquirrelContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    } 
    [Authorize]
    public IActionResult Index() //gonutsnonuts page
    {
      CreateSquirrelViewModel viewModel = new CreateSquirrelViewModel(){Image = Src.GetPhoto()};
      viewModel.Name = RandomThing.RandomName();
      return View(viewModel);
    }
    [Authorize]
    public IActionResult Create(CreateSquirrelViewModel viewModel) // form to add details
    {
      return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(CreateSquirrelViewModel viewModel)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      Squirrel squirrel = new Squirrel()
      {
        Name = viewModel.Name,
        Image = viewModel.Image,
        PartyTrick = viewModel.PartyTrick,
        PartyStory = viewModel.PartyStory,
        PartyLocation = viewModel.PartyLocation,
        PartySince = viewModel.PartySince,
        Creator = userId
      };
      _db.Squirrels.Add(squirrel);

      _db.SquirrelUser.Add(new SquirrelUser(){SquirrelId = squirrel.SquirrelId, UserId = userId, Squirrel = squirrel, User = currentUser});
      _db.SaveChanges();
      return RedirectToAction("Details", "Parties", new { id = userId } );
    }

    public IActionResult Details(int id) //squirrel details page
    {
      var thisSquirrel = _db.Squirrels.FirstOrDefault(squirrel => squirrel.SquirrelId == id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      
      if((_db.SquirrelUser.Where(join => join.SquirrelId == thisSquirrel.SquirrelId && join.UserId == userId ).ToList().Count() < 1) && (thisSquirrel.Creator != userId))
      {
        ViewBag.AllowAdd = true;
      }
      else
      {
        ViewBag.AllowAdd = false;
      }
      return View(thisSquirrel);
    }

    public IActionResult Edit(int id)
    {
      var squirrelChange = _db.Squirrels.FirstOrDefault(squirrel => squirrel.SquirrelId == id);
      return View(squirrelChange);
    }

    [HttpPost]
    public ActionResult Edit(Squirrel squirrel)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      _db.Entry(squirrel).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", "Parties", new { id = userId });
    }

    [HttpPost]
    public ActionResult AddSquirrel(int id)
    {
      var addedSquirrel = _db.Squirrels.FirstOrDefault(squirrel => squirrel.SquirrelId == id);
      _db.SquirrelUser.Add(new SquirrelUser() { UserId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, SquirrelId = addedSquirrel.SquirrelId });
      _db.SaveChanges();
      return RedirectToAction("Details", "Parties", new {id = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value});
    }

    public IActionResult Delete (int id)
    {
      var thisSquirrel = _db.Squirrels.FirstOrDefault(squirrel => squirrel.SquirrelId == id);
      return View(thisSquirrel);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirm (int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var joinList = _db.SquirrelUser.Where(entry => entry.SquirrelId == id).ToList();
      var joinEntry = _db.SquirrelUser.FirstOrDefault(entry => entry.SquirrelId == id && entry.UserId == userId);
      if (joinList.Count == 1)
      {
        var thisSquirrel = _db.Squirrels.FirstOrDefault(squirrel => squirrel.SquirrelId == joinEntry.SquirrelId);
        _db.Squirrels.Remove(thisSquirrel);
      }
      _db.SquirrelUser.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", "Parties", new { id = userId });
    }
  }
}