Console.WriteLine ("Enter a word: ");
string String = Console.ReadLine () ?? "";
Console.Write ("ABECEDARIAN WORD: ");
Console.WriteLine (Check (String));
char[] Check (string String) {
   char[] Sortword = String.ToArray ();
   Array.Sort (Sortword);
   for (int i = 1; i < Sortword.Length; i++) {
      if (Sortword[0] != Sortword[i]) return (Sortword);
   }
   char[] empty = new char[0];
   return empty;
}
