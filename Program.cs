// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Wordle
// To implement wordle game
// ----------------------------------------------------------------------------------------
#region Program ---------------------------------------------------------------------------------------- 
using System.Reflection;
using static System.Console;
using static System.ConsoleColor;

namespace WordleGame {
   public class Wordle {
      // Interface ---------------------------------
      // Public interface routine to run the game
      public void Run () {
         ClearScreen ();
         SelectWord ();
         DisplayBoard ();
         while (!GameOver) {
            ConsoleKey key = ReadKey (true).Key;
            UpdateGameState (key);
            DisplayBoard ();
         }
         PrintResult ();
      }

      #region Implementation ----------------------------------------
      // Implementation ----------------------------
      // Set up suitable colors and clear the screen
      void ClearScreen () {
         BackgroundColor = Black;
         Clear ();
         GRIDX = WindowWidth / 2 - 7;
         KBDX = WindowWidth / 2 - 16;
         CursorVisible = false;
         OutputEncoding = System.Text.Encoding.Unicode;
      }

      // Select a word at random 
      public void SelectWord () {
         mDict = LoadStrings ("dict-5.txt");
         mWord = "CHAIN";
      }

      // Display the current state of the board
      public void DisplayBoard () {
         // First, display the game state
         for (int y = 0; y < 6; y++)
            for (int x = 0; x < 5; x++) {
               char ch = mGuess[y][x];
               ConsoleColor color = White;
               if (y < mY) {
                  color = DarkGray;
                  if (mWord[x] == ch) color = Green;
                  else if (mWord.Contains (ch)) color = Blue;
               }
               if (ch == ' ') ch = '\u00b7';
               if (x == mX && y == mY) ch = '\u25cc';
               if (!IsTest) Put (x * 3 + GRIDX, y * 2 + GRIDY, color, ch);
               Save (ch, color, "Letter");
            }

         // Then, add the 'keyboard hint display' - this shows the keys 
         // that we've already used along with some color codes
         if (!IsTest) Put (KBDX, KBDY - 2, DarkGray, new string ('_', 31));
         string recent = mY == 0 ? "     " : mGuess[mY - 1];
         for (int i = 0; i < 26; i++) {
            int x = i % 7, y = i / 7;
            char ch = (char)('A' + i);
            ConsoleColor color = White;                                 // Not yet used
            if (mGuess.Take (mY).Any (a => a.Contains (ch))) color = DarkGray;    // Already used
            if (recent.Contains (ch) && mWord.Contains (ch)) {
               color = Blue;     // Used in an incorrect position in the recent guess
               int a = recent.IndexOf (ch), b = mWord.IndexOf (ch);
               if (a == b) color = Green;
            }
            if (!IsTest) Put (x * 5 + KBDX, y * 1 + KBDY, color, ch);
            Save (ch, color, "keys");
         }

         // If the user has recently typed in a word that is not in the
         // dictionary, display that
         string error = (mBadWord != null) ? $"{mBadWord} is not a word" : new string (' ', 20);
         if (!IsTest) Put (WindowWidth / 2 - 10, RESULTY + 1, Yellow, error);
      }
      int GRIDX = 3, GRIDY = 1;
      int KBDX = 3, KBDY = 14;

      // Check if the game is over
      bool GameOver => mSucceeded || mFailed;
      bool mSucceeded;               // User succeeded in guessing the word
      bool mFailed;                  // User failed to guess the word
      public bool IsTest = false;    // True while testing

      // Update the game-state based on the key the user pressed
      public void UpdateGameState (ConsoleKey info) {
         mBadWord = null;
         if (info is ConsoleKey.LeftArrow or ConsoleKey.Backspace && mX > 0) {
            // First, handle left / backspace to erase the last character
            Set (--mX, mY, ' ');
            return;
         }
         if (info is ConsoleKey.Enter && mX == 5) {
            // Handle the Enter key to submit a new word
            // First, if the current word is not in the dictionar, don't 
            // accept it
            if (!mDict.Contains (mGuess[mY])) {
               mBadWord = mGuess[mY];
               return;
            }
            mX = 0;
            if (mGuess[mY++] == mWord) {
               mSucceeded = true;
            } else if (mY == 6) mFailed = true;
            return;
         }
         char ch = char.ToUpper ((char)info);
         if (ch is >= 'A' and <= 'Z' && mX < 5) {
            // Handle letter keys to input a new character
            Set (mX++, mY, ch);
            return;
         }

         // Set a particular character of a particular guess string
         void Set (int x, int y, char ch) {
            var array = mGuess[y].ToCharArray ();
            array[x] = ch;
            mGuess[y] = new string (array);
         }
      }

      // Check if the two files are equal
      public bool CheckTextFilesEqual (string f1, string f2) {
         var file1 = File.ReadAllText (f1).Replace ("\r\n", "\n");
         var file2 = File.ReadAllText (f2).Replace ("\r\n", "\n");
         if (file1.Equals (file2)) return true;
         var p = System.Diagnostics.Process.Start ("C:/Program Files/WinMerge/WinMergeU.exe", $"\"{f1}\" \"{f2}\"");
         p.WaitForExit ();
         return false;
      }

      // Format the character based on the color
      string Format (char ch, ConsoleColor color) =>
          color switch {
             Green => new string ($"{{{ch}}}"),
             Blue => new string ($"[{ch}]"),
             DarkGray => new string ($"({ch})"),
             White => new string ($" {ch} "),
             _ => throw new FormatException ()
          };

      // Helper routine to load strings from a assembly-manifest resource file
      string[] LoadStrings (string file) {
         using var stream = Assembly.GetExecutingAssembly ().GetManifestResourceStream ($"Training.Data.{file}");
         using var reader = new StreamReader (stream);
         return reader.ReadToEnd ().Split ("\r\n");
      }

      // Print the final result
      void PrintResult () {
         Put (KBDX, RESULTY, DarkGray, new string ('_', 31));
         if (mSucceeded)
            Put (WindowWidth / 2 - 15, RESULTY + 2, Green, $"You found the word in {mY} tries");
         else
            Put (WindowWidth / 2 - 13, RESULTY + 2, Yellow, $"Sorry - the word was {mWord}");
         Put (WindowWidth / 2 - 11, RESULTY + 4, White, "Press any key to quit");
         ReadKey ();
         WriteLine ();
      }
      int RESULTY = 18;

      // Print the character with it's corresponding color
      void Put (int x, int y, ConsoleColor color, object data) {
         CursorLeft = x; CursorTop = y; ForegroundColor = color;
         Write (data);
         ResetColor ();
      }

      // Save the result to the file
      public void Save (char ch, ConsoleColor color, string type) {
         if (type == "keys") {
            if (LCount == 1) File.AppendAllText ("c:/etc/wordletest.txt", string.Concat (Enumerable.Repeat ('_', 31)) + "\n");
            File.AppendAllText ("c:/etc/wordletest.txt", LCount % 7 == 0 || ch == 'Z' ? Format (ch, color) + "\n" : Format (ch, color));
            LCount++;
         } else {
            File.AppendAllText ("c:/etc/wordletest.txt", KCount % 5 == 0 ? Format (ch, color) + "\n" : Format (ch, color));
            KCount++;
         }
         if (LCount % 27 == 0) {
            mGuess = new string[] { "     ", "     ", "     ", "     ", "     ", "     " };
            mX = 0; mY = 0; KCount = 1; LCount = 1;
         }
      }
      int KCount = 1, LCount = 1;
      #endregion

      #region Private data ------------------------------------------
      // State -------------------------------------
      string[] mDict;   // The dictionary of all possible words
      string[] mGuess = { "     ", "     ", "     ", "     ", "     ", "     " };   // The 6 guesses of the user
      string mWord;
      int mY = 0;       // The word we're typing into now
      int mX = 0;       // The letter within that word we're typing in
      string mBadWord;  // This is set if the user types in a word not in the dictionary
      #endregion
   }

   class Program {
      static void Main () => new Wordle ().Run ();
   }
}
#endregion
