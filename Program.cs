//Program to  DISPLAY THE INDIVIDUAL DIGITS OF A GIVEN NUMBER 
using static System.Console;
WriteLine ("Enter a number: ");
if (double.TryParse (ReadLine () ?? "", out double Input)) {
   string Output = Input.ToString ();
   GetNumbers (Output);
} else WriteLine ("Enter a valid number");
void GetNumbers (string Number) {
   var Integral = new List<string> ();
   var Decimal = new List<string> ();
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
   Write ("The Integral Part is : ");
   Integral.ForEach (num => Write (num + " "));
   Write ("\nThe Fractional Part is : ");
   Decimal.ForEach (num => Write (num + " "));
}
