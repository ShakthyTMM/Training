//Program to display Reduced String
Console.WriteLine ("Enter a string: ");
var Input = Console.ReadLine () ?? "";
List<string> Output = new List<string> ();
(int, int) CountChar (string Input) {
   int c = 0, i = 0;
   for (i = 0; i < Input.Length - 1; i++) {
      if (Input[i] == Input[i + 1]) c++;
      else break;
   }
   return (c, i);
}
while (Input.Length != 0) {
   (int count, int j) = CountChar (Input);
   if (count % 2 == 0) Output.Add (Input[j].ToString ());
   Input = Input.Substring (j + 1);
}
Output.ForEach (Console.Write);
