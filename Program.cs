// Program to develop Spell Bee game
using static System.Console;

char[] letters = { 'E', 'I', 'S', 'A', 'R', 'N', 'T' };
int score = 0;
var validWords = File.ReadAllLines ("C:/Users/shakthy.r/Downloads/words-shuffle.txt")
                              .Where (x => x.Length >= 4
                               && x.Contains (letters[0])
                               && x.All (letters.Contains)).Select (GetScore)
                               .OrderBy (x => x.Item3).OrderByDescending (x => x.Item1).ToList ();
foreach (var word in validWords) {
   if (word.Item2) ForegroundColor = ConsoleColor.Green;
   WriteLine ($"{word.Item1,5} {word.Item3}");
   ResetColor ();
}
WriteLine ($"-----------------\n{score,5} TOTAL");
(int, bool, string) GetScore (string word) {
   int point;
   bool pangram = letters.All (word.Contains);
   point = (word.Length > 4 ? word.Length : 1) + (pangram ? 7 : 0);
   score += point;
   return (point, pangram, word);
}
