// Program to develop Spell Bee game
using static System.Console;

char[] letters = { 'E', 'I', 'S', 'A', 'R', 'N', 'T' };
int totalScore = 0;
var validWords = File.ReadAllLines ("C:/Users/shakthy.r/Downloads/words-shuffle.txt")
                              .Where (x => x.Length >= 4
                               && x.Contains (letters[0])
                               && x.All (letters.Contains)).Select (GetScore)
                               .OrderByDescending (x => x.Score).ThenBy (x => x).ToList ();

foreach (var word in validWords) {
   if (word.Pangram) ForegroundColor = ConsoleColor.Green;
   WriteLine ($"{word.Score,5} {word.Word}");
   ResetColor ();
}
WriteLine ($"-----------------\n{totalScore,5} TOTAL SCORE");
(int Score, bool Pangram, string Word) GetScore (string word) {
   int score;
   bool pangram = letters.All (word.Contains);
   score = (word.Length > 4 ? word.Length : 1) + (pangram ? 7 : 0);
   totalScore += score;
   return (score, pangram, word);
}
