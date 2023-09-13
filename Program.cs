// Program to develop Spell Bee game
using static System.Console;
using System.IO;

string[] words = File.ReadAllLines ("C:/Users/shakthy.r/Downloads/words.txt");
char[] letters = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };
List<string> resultList = new List<string> ();
foreach (var word in words) {
   int count = 0;
   for (int i = 0; i < word.Length; i++) {
      if (!letters.Contains (word[i])) {
         count = 0;
         break;
      } else count++;
   }
   if (count >= 4 && word.Contains (letters[0]))
      resultList.Add (word);
}
resultList = resultList.OrderByDescending (x => x.Length).ToList ();
int point = 0;
int score = 0;
resultList.Remove (isPangram (resultList));
foreach (var ch in resultList) {
   ForegroundColor = ConsoleColor.White;
   if (ch.Length == 4) {
      WriteLine ($"{point = 1,2}. {ch}");
      score++;
   } else {
      WriteLine ($"{point = ch.Length,2}. {ch}");
      score += ch.Length;
   }
}
WriteLine ($"----\n{score} total");
string isPangram (List<string> list) {
   foreach (var ch in list) {
      if (ch.Length > 4 && letters.All (ch.Contains)) {
         ForegroundColor = ConsoleColor.Green;
         WriteLine ($"{point = 15}. {ch}");
         score += 15;
         return ch;
      }
   }
   return "";
}
