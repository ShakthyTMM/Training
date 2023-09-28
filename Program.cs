// Program to Print String Permutations
using static System.Console;
int count = 0;
string answer = "";
Write ("Enter the string : ");
string s = ReadLine () ?? "";
if (s.Length > 0 && s.All (Char.IsLetter)) {
   WriteLine ("\nAll Possible Strings are : ");
   Permute (s, answer);
   Write ($"\nNumber of Possible Permutations: {count}\n");
} else WriteLine ("Enter Valid Input");

void Permute (string s, string answer) {
   if (s.Length == 0) {
      WriteLine (answer);
      count++;
      return;
   }
   for (int i = 0; i < s.Length; i++)
      Permute (s[..i] + s[(i + 1)..], answer + s[i]);
}