//Program to Check LONGEST ABECEDARIAN WORD 
Console.WriteLine ("Enter the number of words to check for Abecedarian word: ");
if (int.TryParse (Console.ReadLine (), out int Terms)) {
   string[] Words = new string[Terms];
   for (int i = 0; i < Terms; i++) {
      Console.WriteLine ($"Enter word {i + 1}: ");
      Words[i] = Console.ReadLine () ?? "";
   }
   Console.WriteLine ($"The Longest Abecedarian Word is : {GetAbecedarian (Words)}");
} else Console.WriteLine ("Enter Valid Input");

string GetAbecedarian (string[] Words) {
   string[] SortedArray = new string[Words.Length];
   List<string> Sorted = new List<string> ();
   for (int i = 0; i < Words.Length; i++) {
      char[] charArray = Words[i].ToCharArray ();
      Array.Sort (charArray);
      SortedArray[i] = new string (charArray);
      if (SortedArray[i] == Words[i])
         Sorted.Add (SortedArray[i]);
   }
   string LongestWord = Sorted.OrderByDescending (x => x.Length).First ();
   return LongestWord;
}