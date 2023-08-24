Console.WriteLine ("Enter a string: ");
string String = Console.ReadLine () ?? "";
char[] Chars = String.ToCharArray ();
if (String != null) {
   char[] Resultstring = new char[100];
   for (int i = 0; i < Chars.Length - 1; i++) {
      if (Chars[i] == Chars[i + 1]) {
         if (i == 0) Resultstring[i] = Chars[i];
         continue;
      }
      if (Chars.Length > 2) { Resultstring[i] = Chars[i + 1]; continue; } else if (Chars.Length == 2) { Resultstring[i] = Chars[i]; Resultstring[i + 1] = Chars[i + 1]; break; }
   }
   Resultstring[0] = Chars[0];
   for (int j = 0; j < Resultstring.Length; j++) Console.Write (Resultstring[j]);
} else Console.WriteLine ("Empty String");
