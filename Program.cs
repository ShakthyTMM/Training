//Program.cs
//SORT AND SWAP SPECIAL CHARACTERS
//Program to sort a given array with the given sort order, and placing the elements which match the given
//special character in the last of the array
// Sample Input: [a, b, c, a, c, b, d], a, “descending”
//Sample Output: d, c, c, b, b, a, a

using static System.Console;
char[] chars = new char[char.MaxValue];
while (true) {
   Write ("Enter the number of elements in the array: ");
   if (!int.TryParse (ReadLine (), out int n)) {
      Write ("Enter a valid input\n");
      continue;
   } else {
      for (int i = 0; i < n; i++) {
         while (true) {
            Write ($"Enter element {i + 1} : ");
            if (!char.TryParse (ReadLine () ?? "".ToLower (), out chars[i]) || !char.IsLetter (chars[i]))
               WriteLine ("Enter valid input\n");
            else break;
         }
      }
      while (true) {
         WriteLine ("Enter the special character among the array: ");
         if (!char.TryParse (ReadLine () ?? "".ToLower (), out char s) || !char.IsLetter (s)) {
            WriteLine ("Enter valid input\n");
            continue;
         } else {
            while (true) {
               WriteLine ("Is the array to be sorted in descending order (Y/N): ");
               if (!char.TryParse (ReadLine () ?? "".ToLower (), out char order) && order != 'y' && order != 'n') {
                  Write ("Enter valid input\n");
                  continue;
               } else {
                  if (order == 'y') PrintSortedArray (chars, s, order);
                  else PrintSortedArray (chars, s);
               }
               break;
            }
         }
         break;
      }
   }
   break;
}
/// <summary> Function to sorted the array in the given sort order and print</summary>
/// <param name="arr"> array of character to be sorted</param>
/// <param name="s"> special character</param>
/// <param name="o">Sort order</param>
void PrintSortedArray (char[] arr, char s, char o = 'n') {
   var elementsTodelete = arr.Where (x => x == s);
   var sortedarray = o == 'n' ? arr.Where (x => x != s).OrderBy (x => x).Concat (elementsTodelete) : arr.Where (x => x != s).OrderByDescending (x => x).Concat (elementsTodelete);
   foreach (var ch in sortedarray) Write (ch);
}
