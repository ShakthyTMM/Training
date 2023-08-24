Console.WriteLine ("Enter a string: ");
string String = Console.ReadLine () ?? "";
char[] Isogram = String.ToCharArray ();
bool result = CheckIsogram (Isogram, String);
if (result == true) Console.WriteLine ("The string is an Isogram");
else Console.WriteLine ("The string is not an Isogram");
bool CheckIsogram (char[] Isogram, string String) {
   for (int i = 0; i < String.Length - 2; i++) {
      for (int j = i + 1; j < String.Length; j++) {
         if (Isogram[i] == Isogram[j]) return false;
         else continue;

      }
   }
   return true;
}
