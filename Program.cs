// program to build a frequency table
using static System.Console;
Dictionary<char, int> frequency = new ();
var words = File.ReadAllLines ("C:/Users/shakthy.r/Downloads/words.txt")
                .SelectMany (x => x);
foreach (var ch in words) {
   if (frequency.TryGetValue (ch, out var count)) frequency[ch] = count + 1;
   else frequency.Add (ch, count = 1);
}
foreach (var word in frequency.OrderByDescending (x => x.Value).Take (7))
   WriteLine (word);
