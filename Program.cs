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
      while (!mGameOver) {
         mKey = ReadKey (true);
         UpdateGameState (mKey);
         DisplayBoard ();
         if (mCol == 0) Clear ();
      }
      SetCursorPosition ((WindowWidth - 21) / 2, CursorTop += 4);
      WriteLine ("Press Any key to exit");
      _ = ReadKey (true);
   }

   #region Implementation ----------------------------------------
   /// <summary>Selects a random word as the secret word from the text file</summary>
   void SelectWord () {
      mWords = File.ReadAllLines ("C:/etc/dict-5.txt");
      var puzzles = File.ReadAllLines ("C:/etc/puzzle-5.txt");
      mSecretWord = puzzles[new Random ().Next (puzzles.Length)];
   }

   /// <summary>Displays the layout of the game</summary>
   void DisplayBoard () {
      OutputEncoding = new UnicodeEncoding ();
      int x;
      SetCursorPosition ((WindowWidth - 15) / 2, mRow);
      (x, _) = GetCursorPosition ();
      for (int i = mRow; i < 6; i++) {
         for (int j = 0; j < 5; j++) {
            if (!(char.IsLetter (mGrid[i, j])) && i == 0 && j == 0) mGrid[i, j] = '\u25cc';
            mGrid[i, j] = (char.IsLetter (mGrid[i, j]) || mGrid[i, j] == '\u25cc') ? mGrid[i, j] : '\u00b7';
            if (char.IsLetter (mGrid[i, j]) && mWord.Length == 5 && mKey.Key == ConsoleKey.Enter)
               ForegroundColor = mLetterColors.TryGetValue (mGrid[i, j], out ConsoleColor value) && !mWord[..j].Contains (mWord[j])
                               ? value : ConsoleColor.DarkGray;
            Write ($" {mGrid[i, j]} ");
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
         if (alpha == 'A' && mKey.Key == ConsoleKey.Enter)
            LetterColors (mKeyColors);
         if (mKeyColors.TryGetValue (alpha, out ConsoleColor value)) ForegroundColor = value;
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
         if (mCol < 5) {
            mGrid[mRow, mCol] = Char.ToUpper (Key.KeyChar);
            mWord += mGrid[mRow, mCol];
            if (mCol < 4) mGrid[mRow, ++mCol] = '\u25cc';
            else ++mCol;
         }
      }
      if (Key.Key == ConsoleKey.LeftArrow || Key.Key == ConsoleKey.Backspace) {
         if (string.IsNullOrEmpty (mWord)) return;
         mWord = mWord[..(mCol - 1)];
         if (mCol == 5) mGrid[mRow, --mCol] = '\u25cc';
         else {
            mGrid[mRow, --mCol] = '\u25cc';
            mGrid[mRow, mCol + 1] = '\u00b7';
         }
      }
      if (mCol == 5 && Key.Key == ConsoleKey.Enter) {
         mCol = 0;
         if (mWords.Contains (mWord)) {
            LetterColors (mLetterColors);
            if (mWord == mSecretWord) {
               mGameOver = true;
               PrintMessage ($"You found the word in {mRow + 1} tries", ConsoleColor.Green);
               return;
            }
         } else {
            for (int j = 0; j < 5; j++)
               mGrid[mRow, j] = j == 0 ? '\u25cc' : '\u00b7';
            PrintMessage ($"{mWord} is not a word", ConsoleColor.Yellow);
            mWord = "";
            return;
         }
         if (mRow == 5) {
            mGameOver = true;
            (string res, ConsoleColor colour) = mWord == mSecretWord
                                             ? ($"You found the word in {mRow + 1} tries", ConsoleColor.Green)
                                             : ($"Sorry - the word was {mSecretWord}", ConsoleColor.Yellow);
            PrintMessage (res, colour);
            return;
         }
         mGrid[mRow + 1, mCol] = '\u25cc';
         DisplayBoard ();
         mRow++;
         PrintMessage ($" {6 - mRow} tries remaining ", ConsoleColor.Yellow);
      }
   }

   /// <summary>Clears the dictionary for each word</summary>
   void Clear () {
      mWord = "";
      mLetterColors.Clear ();
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
      for (int j = 0; j < mWord.Length; j++) {
         if (color.TryGetValue (mWord[j], out ConsoleColor value) && value is ConsoleColor.Green or ConsoleColor.Blue) continue;
         color[mWord[j]] = mSecretWord.Contains (mWord[j]) ? (mWord[j] == mSecretWord[j]
                             ? ConsoleColor.Green : ConsoleColor.Blue) : ConsoleColor.DarkGray;
      }
   }
   #endregion

   #region Private data ------------------------------------------
   ConsoleKeyInfo mKey;
   Dictionary<char, ConsoleColor> mLetterColors = new (), mKeyColors = new ();
   string[] mWords;
   string mWord, mSecretWord;
   bool mGameOver = false;
   int mRow, mCol;
   char[,] mGrid = new char[6, 5];
   #endregion
}
#endregion
