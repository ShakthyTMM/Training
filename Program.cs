// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Eight Queens
// To print all valid solutions or 12 unique solutions of eight queens problem
// ----------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

#region Program ---------------------------------------------------------------------------------------- 
internal class Program {
   private static void Main (string[] args) {
      Write ("Print: 1. All Solutions \t 2. Unique Solutions :");
      var choice = ReadKey ().Key;
      if (ConsoleKey.D1 == choice) {
         EightQueens (0);
         PrintBoard ();
      } else if (ConsoleKey.D2 == choice) {
         EightQueens (0, true);
         PrintBoard ();
      } else WriteLine ("Enter a valid number");
   }

   #region Private Data ------------------------------------------
   static int[] sPosition = new int[8];
   static List<int[]> sSolutions = new ();
   #endregion

   #region Implementation ----------------------------------------
   /// <summary>To find all valid solutions using backtracking</summary>
   /// <param name="r">Row of the chess board</param>
   /// <param name="unique">To store the choice of required type of solution</param>
   static void EightQueens (int r, bool unique = false) {
      for (sPosition[r] = 0; sPosition[r] < 8; sPosition[r]++) {
         if (!IsSafe (r)) continue;
         if (r == 7) {
            if (unique == true && IsuniqueSolution (sPosition.ToArray ())) return;
            sSolutions.Add (sPosition.ToArray ());
         } else EightQueens (r + 1, unique);
      }
   }

   /// <summary>To find the possible positions for the queens to be placed</summary>
   /// <param name="r">Row of the chess board</param>
   /// <returns>Returns true if the given position is safe else false</returns>
   static bool IsSafe (int r) {
      for (int x = 0; x < r; x++) {
         int i = r - x, j = Math.Abs (sPosition[r] - sPosition[x]);
         if (j == 0 || i - j == 0) return false;
      }
      return true;
   }

   /// <summary>To check whether the found solution is unique</summary>
   /// <param name="position">The found solution</param>
   /// <returns>Returns true if the given solution is not unique else false</returns>
   static bool IsuniqueSolution (int[] position) {
      for (int i = 0; i < 4; i++) {
         position = Rotate (position);
         if (sSolutions.Any (x => x.SequenceEqual (position) || x.SequenceEqual (Mirror (position)))) return true;
      }
      return false;
   }

   /// <summary>Rotates the given solution to check for similarity with the before found solutions</summary>
   /// <param name="position">The solution which is to be checked</param>
   /// <returns>Returns the rotated solution</returns>
   static int[] Rotate (int[] position) {
      int[] temp = new int[8];
      for (int i = 0; i < 8; i++) temp[position[i]] = 7 - i;
      return temp;
   }

   /// <summary>Mirrors the given solution to check for similarity with the before found solutions</summary>
   /// <param name="position">The solution which is to be checked</param>
   /// <returns>Returns the mirrored solution</returns>
   static int[] Mirror (int[] position) => position.Select (i => 7 - i).ToArray ();

   /// <summary>Prints the chess board with all possible solutions</summary>
   static void PrintBoard () {
      OutputEncoding = new UnicodeEncoding ();
      int i = 0;
      foreach (var solution in sSolutions) {
         WriteLine ($"\nSolution : {i + 1}");
         WriteLine ("┌" + string.Concat (Enumerable.Repeat ("───┬", 7)) + "───┐");
         for (int r = 0; r < 8; r++) {
            for (int c = 0; c <= 8; c++)
               Write (solution[r] == c ? "│ ♕ " : "│   ");
            WriteLine ("\n" + (r < 7 ? "├" + string.Concat (Enumerable.Repeat ("───┼", 7)) + "───┤" :
                                        "└" + string.Concat (Enumerable.Repeat ("───┴", 7)) + "───┘"));
         }
         i++;
      }
   }
   #endregion
}
#endregion