// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Double Parse
// To implement double.Parse method that takes a string and returns a double
// ----------------------------------------------------------------------------------------
using System.Text.RegularExpressions;
using static System.Console;
internal class Program {
   private static void Main (string[] args) {
      WriteLine (Mdouble.Parse ("-3.14926E+9") + "\n" + Mdouble.Parse ("-52145621.152E-5"));
   }
}
class Mdouble {
   public static double Parse (string s) {
      if (s == null) throw new ArgumentNullException ();
      //Regular Expressions(regex) class checks for pattern matching with the given string
      Regex pattern = new (@"\s*(?<sign>[+-])?(?<integer>[0-9]+)(\.(?<fraction>[0-9]*))?([Ee](?<expsign>[+-])?(?<exponent>[0-9]+))?\s*",
          //Explicitcapture, a member of regexoptions enum which is used to capture only explicitly named groups
          RegexOptions.ExplicitCapture);

      //Match property compares the given string with the pattern
      //Match object comprises the result of the comparison
      Match match = pattern.Match (s);

      //Success, a property of match class indicates whether the pattern is successfully matched all the part of the string
      if (!match.Success) throw new FormatException ();

      //Value, a property of match class returns the matched substrings of match and captured groups
      //Groups, also a property of match class groups the matched substrings
      string sign = match.Groups["sign"].Value;
      string integer = match.Groups["integer"].Value;
      string fraction = match.Groups["fraction"].Value;
      string expsign = match.Groups["expsign"].Value;
      string exponentdigits = match.Groups["exponent"].Value;
      double number = 0.0;

      foreach (var digit in integer) {
         number *= 10.0;
         number += digit - '0';
      }
      double factor = 1.0;
      foreach (var digit in fraction) {
         factor *= 10.0;
         number += (digit - '0') / factor;
      }
      if (sign == "-") number = -number;
      int power = 0;
      foreach (var digit in exponentdigits) {
         power *= 10;
         power += digit - '0';
      }
      if (expsign == "-") power = -power;
      double exponent = Math.Pow (10.0, power);
      number *= exponent;
      return number;
   }
}
