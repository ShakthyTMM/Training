// Program to Print String Permutations
string answer = "";
Console.Write ("Enter the string : ");
string s = Console.ReadLine () ?? "";
if (s.Length > 0 && s.All (Char.IsLetter)) {
   Console.WriteLine ("\nAll possible strings are : ");
   permute (s, answer);
} else Console.WriteLine ("Enter Valid Input");
void permute (String s, String answer) {
   if (s.Length == 0) {
      Console.WriteLine (answer + "  ");
      return;
   }
   for (int i = 0; i < s.Length; i++) {
      char ch = s[i];
      String left_substr = s.Substring (0, i);
      String right_substr = s.Substring (i + 1);
      String rest = left_substr + right_substr;
      permute (rest, answer + ch);
   }
}
