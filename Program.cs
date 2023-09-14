//Program to Swap Indices of the Random Number Generated
using static System.Console;
WriteLine ("The Number Generated: ");
Random random = new Random ();
string num = random.Next ().ToString ();
WriteLine (num);
Write ("Enter the Indices to be Swapped: ");
int.TryParse (ReadLine () ?? "", out int index1);
int.TryParse (ReadLine () ?? "", out int index2);
SwapIndices (num, index1, index2);

void SwapIndices (string Input, int a, int b) {
   char[] result = Input.ToCharArray ();
   (result[a], result[b]) = (result[b], result[a]);
   for (int j = 0; j < result.Length; j++) Write (result[j]);
}