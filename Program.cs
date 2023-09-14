// Program to develop Spell Bee game
using static System.Console;
using System.IO;

string[] words = File.ReadAllLines ("C:/Users/shakthy.r/Downloads/words-shuffle.txt");
char[] letters = { 'E', 'I', 'S', 'A', 'R', 'N', 'T' };
var resultList = new List<string> ();
foreach (var word in words.Where(x=> x.Length >= 4 
                               && x.Contains (letters[0]) 
                               && letters.All (x.Contains))) 
resultList.Add (word);
resultList = resultList.OrderBy (x => x).OrderByDescending (x => x.Length).ToList ();
int point, score = 0;
resultList = Pangram (resultList);
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
List<string> Pangram (List<string> list) {
   var pangrams = new List<string> ();
   foreach (var ch in list.Where (x => x.Length > 4 && letters.All (x.Contains))) {
      pangrams.Add (ch);
      ForegroundColor = ConsoleColor.Green;
      WriteLine ($"{point = ch.Length + 7}. {ch}");
      list.Remove (ch);
      score += ch.Length + 7;
   }
   return list;
}
