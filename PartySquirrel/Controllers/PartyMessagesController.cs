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
  public class PartyMessagesController : Controller
  {
    private readonly PartySquirrelContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public PartyMessagesController(PartySquirrelContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    } 

    public IActionResult Create(string id, string fromId) 
    {
      CreatePartyMessageViewModel viewModel = new CreatePartyMessageViewModel();
      viewModel.UserId = id;
      viewModel.UserFromId = fromId;
      return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePartyMessageViewModel viewModel)
    {
      var userTo = await _userManager.FindByIdAsync(viewModel.UserId);
      var userFrom = await _userManager.FindByIdAsync(viewModel.UserFromId);
      PartyMessage newMessage = new PartyMessage();
      newMessage.UserId = viewModel.UserId;
      newMessage.User = userTo;
      newMessage.UserFromId = viewModel.UserFromId;
      newMessage.UserFrom = userFrom;
      newMessage.MessageBody = viewModel.MessageBody;
      _db.PartyMessages.Add(newMessage);
      _db.SaveChanges();
      return RedirectToAction("Details", "Parties", new {id = viewModel.UserId});
    }
  }
}