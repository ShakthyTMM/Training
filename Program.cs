//Program to Swap Indices of the Random Number Generated
Console.WriteLine ("The Number Generated: ");
Random random = new Random ();
int Number = random.Next ();
Console.WriteLine (Number);
Console.Write ("Enter the Indices to be Swapped: ");
int.TryParse (Console.ReadLine () ?? "", out int index1);
int.TryParse (Console.ReadLine () ?? "", out int index2);
SwapIndices (Number, index1, index2);

void SwapIndices (int num, int a, int b) {
   string Input = num.ToString ();
   int[] NumberArr = new int[Input.Length];
   for (int j = 0; j < Input.Length; j++) {
      NumberArr[j] = int.Parse (Input[j].ToString ());
   }
   (NumberArr[a], NumberArr[b]) = (NumberArr[b], NumberArr[a]);
   for (int i = 0; i < NumberArr.Length; i++) Console.Write (NumberArr[i]);

}