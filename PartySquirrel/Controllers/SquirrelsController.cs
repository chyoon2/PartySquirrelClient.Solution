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
    public IActionResult Index() //gonutsnonuts page
    {
      var result = Squirrel.GetSquirrel();
      return View(result);
    }

    [Authorize]
    public IActionResult Create() // form to add details
    {
      return View();
    }

    [HttpPost, Authorize]
    public IActionResult Create(Squirrel squirrel)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      _db.Squirrels.Add(squirrel);
      _db.SaveChanges();
      return RedirectToAction("Details", "Parties", new { id = userId } );
    }

    [Authorize]
    public IActionResult Details(int id) //squirrel details page
    {
      var thisSquirrel = _db.Squirrels.FirstOrDefault(squirrel => squirrel.SquirrelId == id);
      return View(thisSquirrel);
    }

    [Authorize]
    public IActionResult Edit(int id)
    {
      var squirrelChange = _db.Squirrels.FirstOrDefault(squirrel => squirrel.SquirrelId == id);
      return View(squirrelChange);
    }

    [HttpPost, Authorize]
    public ActionResult Edit(Squirrel squirrel)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      _db.Entry(squirrel).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", "Parties", new { id = userId });
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