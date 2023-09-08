﻿// Program to Guess Secret Number (FROM LSB to MSB)
using static System.Console;

int Remainder = 0, Divisor = 2, Number = 0, Exp = 0;
for (int tries = 0; tries <= 7; tries++) {
   Write ($"Is the remainder {Remainder} when divided by {Divisor} (Y/N)? ");
   if (ReadKey ().Key == ConsoleKey.N) {
      Remainder += Divisor / 2;
      Number += (int)(1 * Math.Pow (2, Exp));
   }
   Exp++;
   Divisor = (int)Math.Pow (2, Exp + 1);
   WriteLine ();
}
WriteLine ($"\nThe Secret Number is : {Number}");