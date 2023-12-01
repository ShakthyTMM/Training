// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Double Parse
// To implement double.Parse method that takes a string and returns a double
// ----------------------------------------------------------------------------------------
internal class Program {
   private static void Main (string[] args) {
      Console.WriteLine (Mdouble.Parse ("-3.1492e14") + "\n" + Mdouble.Parse ("59625454.45e-45"));
   }
   /// <summary>Mdouble class to implement Parse method</summary>
   class Mdouble {

      /// <summary>Converts the string representation of a number to it's double-precision floating-point number equivalent </summary>
      /// <param name="s">The string(numeric value) which needs to be converted into double-precision floating-point number</param>
      /// <returns>Returns the double-precision floating-point number equivalent to the given numeric value s</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="FormatException"></exception>
      public static double Parse (string s) {
         if (string.IsNullOrEmpty (s)) throw new ArgumentNullException ();
         double number = 0.0;
         string[] parts = Array.Empty<string> ();
         //Splitting the string into integral, fractional and exponent parts
         parts = s.Trim ().ToLower ().Split (".");
         string integer = parts[0];
         string sign = (integer[0] == '-' || integer[0] == '+') ? integer[..1] : "";
         integer = integer.TrimStart ('-', '+');
         if (!integer.All (char.IsDigit) || integer.StartsWith ('e') || string.IsNullOrEmpty (integer)) throw new FormatException ();
         //Calculating the integral part 
         foreach (var digit in integer) {
            number *= 10.0;
            number += digit - '0';
         }
         string fraction = parts[1];
         string exponentdigits = "";
         char expsign = ' ';
         int power = 0;
         if (fraction.Contains ('e')) {
            //Splitting exponent part from fractional part
            exponentdigits = fraction[fraction.IndexOf ('e')..];
            fraction = fraction.Remove (fraction.IndexOf ("e"), exponentdigits.Length);
            if (!fraction.All (char.IsDigit) || fraction.StartsWith ('e') || string.IsNullOrEmpty (fraction)) throw new FormatException ();
            int eindex = exponentdigits.IndexOf ('e');
            if (exponentdigits[eindex + 1] == '-' || exponentdigits[eindex + 1] == '+' || char.IsDigit (exponentdigits[eindex + 1])) {
               expsign = exponentdigits[eindex + 1];
               exponentdigits = char.IsDigit (exponentdigits[eindex + 1]) ? exponentdigits.Remove (eindex, 1) : exponentdigits.Remove (eindex, 2);
            }
            //Calculating the exponent part
            foreach (var digit in exponentdigits) {
               power *= 10;
               power += digit - '0';
            }
            if (expsign == '-') power = -power;
         }
         //Calculating the factorial part
         double factor = 1.0;
         foreach (var digit in fraction) {
            factor *= 10.0;
            number += (digit - '0') / factor;
         }
         if (sign == "-") number = -number;
         double exponent = Math.Pow (10.0, power);
         number *= exponent;
         return number;
      }
   }
}

