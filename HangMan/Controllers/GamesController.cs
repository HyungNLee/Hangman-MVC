using Microsoft.AspNetCore.Mvc;
using HangMan.Models;
using System;
using System.Collections.Generic;

namespace HangMan.Controllers
{
  public class GamesController : Controller
  {
    [HttpGet("/game/new")]
    public ActionResult Index ()
    {
      Game newGame = new Game();
      return View(newGame);
    }

    [HttpPost("/game/flow/{id}")]
    public ActionResult Index (int id)
    {
      Game newGame = Game.FindById(id);
      newGame.Guess(Request.Form["guess"]);
      return View(newGame);
    }
  }
}
