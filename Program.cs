// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Double Parse
// To implement double.Parse method that takes a string and returns a double
// ----------------------------------------------------------------------------------------
using static System.Console;
internal class Program {
   private static void Main (string[] args) {
      const double NaN = double.NaN;
      Dictionary<string, double> sTests = new () {
         ["-12"] = -12, ["+12"] = 12, ["12"] = 12, ["-+12"] = NaN, ["*12"] = NaN,
         ["12.3"] = 12.3, ["12.34"] = 12.34, ["12.-3"] = NaN, [".14"] = 0.14, ["12."] = 12, ["12~"] = NaN, ["a12"] = NaN,
         ["12b"] = NaN, ["12..3"] = NaN, ["12e3"] = 12000, ["12.34e3"] = 12340, ["12.34E-2"] = 0.1234, ["12.34e-2"] = 0.1234, ["12.3e"] = NaN,
         ["12.3e-+"] = NaN, ["12.3e-+3"] = NaN, ["12.34e5."] = NaN, [".e3"] = NaN, ["e4"] = NaN, ["12e"] = NaN,
         ["12.34"] = 12.34, ["0.12"] = 0.12, ["12.0"] = 12, ["12e0"] = 12, ["0e0"] = 0, ["12.0e0"] = 12, ["+e3"] = NaN,
         ["123.456"] = 123.456
      };
      foreach (var (s, f1) in sTests) {
         double f2 = Math.Round (Mdouble.Parse (s), 8);
         ForegroundColor = Same (f1, f2) ? ConsoleColor.White : ConsoleColor.Red;
         WriteLine ($"{s} => {f2}    \n");
         ResetColor ();
      }
      bool Same (double f1, double f2) {
         if (double.IsNaN (f1)) return double.IsNaN (f2);
         return (f1 - f2) < 1e-6;
      }
   }

   /// <summary>Mdouble class to implement Parse method</summary>
   class Mdouble {
      /// <summary>Converts the string representation of a number to it's double-precision floating-point number equivalent </summary>
      /// <param name="s">The string(numeric value) which needs to be converted into double-precision floating-point number</param>
      /// <returns>Returns the double-precision floating-point number equivalent to the given numeric value s</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="FormatException"></exception>
      public static double Parse (string s) {
         if (string.IsNullOrEmpty (s) || s.StartsWith ('e') || s.EndsWith ('e')) return double.NaN;
         double number = 0.0; string edigits = "", sign = ""; char expsign = ' '; int power = 0;

         // Splitting the string into integral, fractional and exponent parts
         s = s.Trim ().ToLower ();
         int eindex = s.IndexOf ('e'), dindex = s.IndexOf ('.');
         string integer = s.Contains ('.') ? (s[..dindex] == "" ? "0" :
                                              s[..dindex]) : s.Contains ('e') ? s[..eindex] : s;
         if (integer != "0" && integer[0] is '+' or '-') {
            sign = integer[..1];
            integer = integer.Remove (0, 1);
         }
         if (Error (integer)) return double.NaN;

         // Calculating the integral part 
         foreach (var digit in integer) {
            if (integer == "0") break;
            number *= 10.0;
            number += digit - '0';
         }

         // Calculating the factorial part
         if (s.Contains ('.') && s[^1] != '.') {
            string f = s.Contains ('e') ? s[(dindex + 1)..eindex] : s[(dindex + 1)..];
            if (Error (f)) return double.NaN;
            double factor = 1.0;
            foreach (var digit in f) {
               factor *= 10.0;
               number += (digit - '0') / factor;
            }
         }
         if (sign == "-") number = -number;

         // Splitting exponent part from fractional part
         if (s.Contains ('e')) {
            edigits = s[eindex..];
            int expindex = edigits.IndexOf ('e');
            if (edigits[expindex + 1] is '+' or '-' || char.IsDigit (edigits[expindex + 1])) {
               expsign = edigits[expindex + 1];
               edigits = char.IsDigit (edigits[expindex + 1]) ? edigits.Remove (expindex, 1) : edigits.Remove (expindex, 2);
            }

            // Calculating the exponent part
            if (Error (edigits)) return double.NaN;
            foreach (var digit in edigits) {
               power *= 10;
               power += digit - '0';
            }
            if (expsign == '-') power = -power;
         }
         double exponent = Math.Pow (10.0, power);
         number *= exponent;
         return number;

         bool Error (string s) {
            if (!s.All (char.IsDigit) || string.IsNullOrEmpty (s)) return true;
            return false;
         }
      }
   }
}

