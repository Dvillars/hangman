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
                Game.SetGameList(newGame);
                return View["gameScreen.cshtml", newGame];
            };

            Post["/Guessed"] = _ =>
            {
                string guess = Request.Form["guess"];
                List<Game> gameList = new List<Game>();
                gameList = Game.GetGameList();
                Game currentGame = gameList[0];
                currentGame.LetterChecker(guess);
                Game.SetGameList(currentGame);
                return View["gameScreen.cshtml", currentGame];
            };

            Post["/Answer"] = _ =>
            {
                string wordGuess = Request.Form["word-guess"];
                List<Game> gameList = new List<Game>();
                gameList = Game.GetGameList();
                Game currentGame = gameList[0];
                if (currentGame.CheckWin(wordGuess))
                {
                    return View["win.cshtml"];
                }
                else
                {
                    currentGame.SetTries(currentGame.GetTries());
                    Game.SetGameList(currentGame);
                    return View["gameScreen.cshtml", currentGame];
                }
            };
        }
    }
}
