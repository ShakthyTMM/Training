using System.Text;
using static System.Console;
OutputEncoding = new UnicodeEncoding ();
string[,] numbers = new string[,] { { "7", "8", "9" }, { "4", "5", "6" }, { "1", "2", "3" } };
int x, y;
(x, y) = GetCursorPosition ();
Display ();
void Display () {
   CursorLeft = x;
   CursorTop = y;
   for (int i = 0; i < 3; i++) {
      for (int j = 0; j < 3; j++) {
         Write ($" {numbers[i, j]}  ");
         if (j != 2) Write ("│");
      }
      WriteLine ();
      if (i != 2) {
         Write (string.Concat (Enumerable.Repeat ("────┼", 2)));
         WriteLine ("────");
      }
   }
}
for (int k = 1; k <= 9; k++) {
   var key = ReadKey (true);
   for (int i = 0; i < 3; i++) {
      for (int j = 0; j < 3; j++) {
         numbers[i, j] = "D" + numbers[i, j];
         if (key.Key.ToString () != numbers[i, j]) continue;
         numbers[i, j] = "X";
      }
   }
   Display ();
}

