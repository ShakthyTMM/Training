//Program to  DISPLAY THE INDIVIDUAL DIGITS OF A GIVEN NUMBER 
Console.WriteLine ("Enter a number: ");
if (double.TryParse (Console.ReadLine () ?? "", out double Input)) {
   string Output = Input.ToString ();
   GetNumbers (Output);
} else Console.WriteLine ("Enter a valid number");
void GetNumbers (string Number) {
   List<string> Integral = new List<string> ();
   List<string> Decimal = new List<string> ();
   foreach (var ch in Number) {
      if (ch.ToString () != ".") {
         Integral.Add (ch.ToString ());
         continue;
      } else if (ch.ToString () == ".") {
         int Length = Number.IndexOf (ch) + 1;
         for (int i = Length; i < Number.Length; i++) Decimal.Add (Number[i].ToString ());
      }
      break;
   }
   Console.Write ("The Integral Part is : ");
   Integral.ForEach (num => Console.Write (num + " "));
   Console.Write ("\nThe Fractional Part is : ");
   Decimal.ForEach (num => Console.Write (num + " "));
}
