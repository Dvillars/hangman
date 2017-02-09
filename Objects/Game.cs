using System;
using System.Collections.Generic;

namespace Hangman.Objects
{
    public class Game
    {
        private string _currentState;
        private string _answer;
        private int _tries;
        private string _result;
        private List<string> _knownLetters = new List<string>();

        public string GetCurrentState()
        {
            return _currentState;
        }
        public void SetCurrentState(string newCurrentState)
        {
            _currentState = newCurrentState;
        }

        public string GetAnswer()
        {
            return _answer;
        }
        public void SetAnswer(string newAnswer)
        {
            _answer = newAnswer;
        }

        public int GetTries()
        {
            return _tries;
        }
        public void SetTries(int newTries)
        {
            _tries = newTries;
        }

        public string GetResult()
        {
            return _result;
        }
        public void SetResult(string newResult)
        {
            _result = newResult;
        }

        public List<string> GetKnownLetters()
        {
            return _knownLetters;
        }
        public void SetKnownLetters(List<string> newKnownLetters)
        {
            _knownLetters = newKnownLetters;
        }

        public Game (string answer)
        {
            _answer = answer;
            for (int i = 0; i < _answer.Length; i++)
            {
                _knownLetters.Add("_ ");
            }
            _tries = 0;
            _result = "You have executed " + _tries + " tries!";
        }

        public void CheckLetter(string letter)
        {
            if (_answer.IndexOf(letter) > -1)
            {
                for (int i = 0; i < _answer.Length; i++)
                {
                    if (_answer.Substring(i, i + 1) == letter)
                    {
                        _knownLetters[i] = letter + " ";
                    }
                }
                _result = ListToString();
            }
            else
            {
                _tries++;
                _result = "You have executed " + _tries + " tries!";
            }
        }

        public string ListToString ()
        {
            for (int i = 0; i < _answer.Length; i++)
            {
                _currentState += _knownLetters[i];
            }
            return _currentState;
        }

    }
}
