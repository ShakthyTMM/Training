// Program to develop Spell Bee game
using static System.Console;

char[] Letters = { 'E', 'I', 'S', 'A', 'R', 'N', 'T' };
int TotalScore = 0;
var validWords = File.ReadAllLines ("C:/Users/shakthy.r/Downloads/words-shuffle.txt")
                              .Where (x => x.Length >= 4
                               && x.Contains (Letters[0])
                               && x.All (Letters.Contains)).Select (GetScore)
                               .OrderBy (x => x.Pangram).OrderByDescending (x => x.Score).ThenBy (x => x).ToList ();

foreach (var Word in validWords) {
   if (Word.Pangram) ForegroundColor = ConsoleColor.Green;
   WriteLine ($"{Word.Score,5} {Word.Word}");
   ResetColor ();
}
WriteLine ($"-----------------\n{TotalScore,5} TOTAL");
(int Score, bool Pangram, string Word) GetScore (string Word) {
   int Score;
   bool Pangram = Letters.All (Word.Contains);
   Score = (Word.Length > 4 ? Word.Length : 1) + (Pangram ? 7 : 0);
   TotalScore += Score;
   return (Score, Pangram, Word);
}
