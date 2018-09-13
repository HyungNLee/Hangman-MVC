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
    private List<Char> _wrongGuessList = new List<Char> {};

    private static List<Game> _allGames = new List<Game> {};

    public Game ()
    {
      _guesses = 6;
      _wrongGuesses = 0;
      _guessWord = PickWord();
      _displayWord = CreateDisplayWord();
      _picURL = GetPicture();
      allGames.Add(this);
      _id = _allGames.Count;
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

    public void Guess (char C)
    {

    }

    public void UpdateDisplayWord(char C)
    {
      List<int> replaceIndex = new List<int> {};
      for (i = 0; i < _guessWord.Length; i++)
      {
        if (_guessWord[i] == C)
        {
          replaceIndex.Add(i);
        }
      }
      foreach (int num in replaceIndex)
      {
        num = num*2;
        _guessWord[num] = C;
      }
    }

    public void UpdateDisplay()
    {
      _picURL = GetPicture();
      _displayWord = UpdateDisplayWord();
    }
  }
}
