using System;
using System.Collections.Generic;

namespace HangMan.Models
{
  public class Game
  {
    private int _guesses;
    private int _wrongGuesses;
    private string _guessWord;
    private string _displayWord;
    private string _picURL;
    private int _id;
    private string _guessResult;
    private List<String> _wrongGuessList = new List<String> {};
    private List<String> _allGuessedList = new List<String> {};

    private static List<Game> _allGames = new List<Game> {};

    public Game ()
    {
      _guesses = 6;
      _wrongGuesses = 0;
      _guessWord = PickWord();
      _displayWord = CreateDisplayWord();
      _picURL = GetPicture();
      _allGames.Add(this);
      _id = _allGames.Count;
      _guessResult = "Please guess a letter.";
    }

    public string GetDisplayWord()
    {
      return _displayWord;
    }

    public string GetResult()
    {
      return _guessResult;
    }

    public string GetWrongList()
    {
      string wrongList = "";

      foreach (string C in _wrongGuessList)
      {
        wrongList = wrongList + C + " ";
      }

      return wrongList;
    }

    public int GetId()
    {
      return _id;
    }

    public string PickWord()
    {
      return "hello";
    }

    public string CreateDisplayWord()
    {
      string display = "_";
      for (int i = 1; i < _guessWord.Length; i++)
      {
        display += " _";
      }
      return display;
    }

    public string GetPicture()
    {
      string URL = "Hangman" + _wrongGuesses + ".png";
      return URL;
    }

    public static List<Game> GetAll()
    {
      return _allGames;
    }

    public static Game FindById(int id)
    {
      return _allGames[id - 1];
    }

    public void Guess (string C)
    {
      if (_allGuessedList.Contains(C))
      {
        _guessResult = "You've already guessed " + C + ".";
      }
      else if (C.Length != 1)
      {
        _guessResult = "Please enter one letter.";
      }
      else
      {
        _allGuessedList.Add(C);
        if (_guessWord.Contains(C))
        {
          UpdateDisplayWord(C);
          _guessResult = "The word contains " + C + ".";
          WinCondition();
        }
        else
        {
          _guesses -= 1;
          _wrongGuesses += 1;
          _wrongGuessList.Add(C);
          _picURL = GetPicture();
          _guessResult = "The word does not contains " + C + ".";
          WinCondition();
        }
      }
    }

    public void UpdateDisplayWord(string C)
    {
      List<int> replaceIndex = new List<int> {};

      for (int i = 0; i < _guessWord.Length; i++)
      {
        if (_guessWord[i] == C[0])
        {
          replaceIndex.Add(i);
        }
      }
      foreach (int num in replaceIndex)
      {
        int index = num*2;
        char[] array = _displayWord.ToCharArray();
        array[index] = C[0];
        _displayWord = new string(array);
      }
    }

    public void UpdateDisplay()
    {
      _picURL = GetPicture();
    }

    public void WinCondition()
    {
      if (!_displayWord.Contains("_"))
      {
        _guessResult = "You win!";
      }
      else if (_guesses == 0)
      {
        _guessResult = "You lose!";
      }
    }

  }
}
