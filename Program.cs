// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Wordle
// To implement wordle game
// ----------------------------------------------------------------------------------------
#region Program ---------------------------------------------------------------------------------------- 
using System.Text;
using static System.Console;
Wordle s = new ();
s.Run ();

class Wordle {
   /// <summary>Public interface routine to run the game</summary>
   public void Run () {
      CursorVisible = false;
      SelectWord ();
      DisplayBoard ();
      while (!GameOver) {
         key = ReadKey (true);
         UpdateGameState (key);
         DisplayBoard ();
         if (c == 0) Clear ();
      }
      SetCursorPosition ((WindowWidth - 21) / 2, CursorTop += 4);
      WriteLine ("Press Any key to exit");
      _ = ReadKey (true);
   }
   #region Implementation ----------------------------------------
   /// <summary>Selects a random word as the secret word from the text file</summary>
   void SelectWord () {
      var puzzles = File.ReadAllLines ("C:/etc/puzzle-5.txt");
      secretWord = puzzles[new Random ().Next (puzzles.Length)];
   }

   /// <summary>Displays the layout of the game</summary>
   void DisplayBoard () {
      OutputEncoding = new UnicodeEncoding ();
      int x;
      SetCursorPosition ((WindowWidth - 15) / 2, r);
      (x, _) = GetCursorPosition ();
      for (int i = r; i < 6; i++) {
         for (int j = 0; j < 5; j++) {
            if (!(char.IsLetter (grid[i, j])) && i == 0 && j == 0) grid[i, j] = '\u25cc';
            grid[i, j] = (char.IsLetter (grid[i, j]) || grid[i, j] == '\u25cc') ? grid[i, j] : '\u00b7';
            if (char.IsLetter (grid[i, j]) && word.Length == 5 && key.Key == ConsoleKey.Enter)
               ForegroundColor = letterColors.TryGetValue (grid[i, j], out ConsoleColor value) && !word[..j].Contains (word[j])
                               ? value : ConsoleColor.DarkGray;
            Write ($" {grid[i, j]} ");
            ResetColor ();
         }
         WriteLine ();
         CursorLeft = x;
      }
      CursorLeft = x - 8;
      ForegroundColor = ConsoleColor.DarkGray;
      WriteLine (string.Concat (Enumerable.Repeat ("\u005F", 31)));
      ResetColor ();
      CursorLeft = x - 8;
      int count = 0;
      for (char alpha = 'A'; alpha <= 'Z'; alpha++) {
         count++;
         if (alpha == 'A' && key.Key == ConsoleKey.Enter) {
            LetterColors (keyColors);
         }
         if (keyColors.ContainsKey (alpha)) ForegroundColor = keyColors[alpha];
         if (count % 7 == 0) {
            Write ($"{alpha}\n");
            ResetColor ();
            CursorLeft = x - 8;
            continue;
         }
         Write ($"{alpha}    ");
         ResetColor ();
      }
   }

   /// <summary>Updates the state of the game for every entry</summary>
   /// <param name="Key">Entry given by the player</param>
   void UpdateGameState (ConsoleKeyInfo Key) {
      if (char.IsLetter (Key.KeyChar)) {
         if (c < 5) {
            grid[r, c] = Char.ToUpper (Key.KeyChar);
            word += grid[r, c];
            if (c < 4) grid[r, ++c] = '\u25cc';
            else ++c;
         }
      }
      if (Key.Key == ConsoleKey.LeftArrow || Key.Key == ConsoleKey.Backspace) {
         if (string.IsNullOrEmpty (word)) return;
         word = word[..(c - 1)];
         if (c == 5) grid[r, --c] = '\u25cc';
         else {
            grid[r, --c] = '\u25cc';
            grid[r, c + 1] = '\u00b7';
         }
      }
      if (c == 5 && Key.Key == ConsoleKey.Enter) {
         var words = File.ReadAllLines ("C:/etc/dict-5.txt");
         c = 0;
         if (words.Contains (word)) {
            LetterColors (letterColors);
            if (word == secretWord) {
               GameOver = true;
               PrintMessage ($"You found the word in {r + 1} tries", ConsoleColor.Green);
               return;
            }
         } else {
            for (int j = 0; j < 5; j++)
               grid[r, j] = j == 0 ? '\u25cc' : '\u00b7';
            PrintMessage ($"{word} is not a word", ConsoleColor.Yellow);
            word = "";
            return;
         }
         if (r == 5) {
            GameOver = true;
            (string res, ConsoleColor colour) = word == secretWord
                                             ? ($"You found the word in {r + 1} tries", ConsoleColor.Green)
                                             : ($"Sorry - the word was {secretWord}", ConsoleColor.Yellow);
            PrintMessage (res, colour);
            return;
         }
         grid[r + 1, c] = '\u25cc';
         DisplayBoard ();
         r++;
         PrintMessage ($" {6 - r} tries remaining ", ConsoleColor.Yellow);
      }
   }

   /// <summary>Clears the dictionary for each word</summary>
   void Clear () {
      word = "";
      letterColors.Clear ();
   }

   /// <summary>Prints the message based on the state of the game</summary>
   /// <param name="message">Message to be displayed</param>
   /// <param name="color">Colour in which the message is expected to be printed</param>
   void PrintMessage (string message, ConsoleColor color) {
      SetCursorPosition ((WindowWidth - message.Length) / 2, CursorTop += 2);
      ForegroundColor = color;
      WriteLine (message);
      ResetColor ();
   }

   /// <summary>Updates the given dictionaries with entries and corresponding colour</summary>
   /// <param name="color">Dictionary to be updated</param>
   void LetterColors (Dictionary<char, ConsoleColor> color) {
      for (int j = 0; j < word.Length; j++) {
         if (color.TryGetValue (word[j], out ConsoleColor value) && value is ConsoleColor.Green or ConsoleColor.Blue) continue;
         color[word[j]] = secretWord.Contains (word[j]) ? (word[j] == secretWord[j]
                             ? ConsoleColor.Green : ConsoleColor.Blue) : ConsoleColor.DarkGray;
      }
   }
   #endregion
   #region Private data ------------------------------------------
   ConsoleKeyInfo key;
   Dictionary<char, ConsoleColor> letterColors = new (), keyColors = new ();
   string word = "", secretWord = "";
   bool GameOver = false;
   int r, c;
   char[,] grid = new char[6, 5];
   #endregion
}
#endregion
