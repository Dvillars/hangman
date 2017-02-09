using Nancy;
using Hangman.Objects;
using System.Collections.Generic;
using System;

namespace Hangman
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                return View["index.cshtml"];
            };

            Post["/Game"] = _ =>
            {
                string input = Request.Form["new-answer"];
                Game newGame = new Game(input);
                return View["gameScreen.cshtml", newGame];
            };
        }
    }
}
