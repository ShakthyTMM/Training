//Program to guess a number between 1 and 100 (MSB to LSB)
using static System.Console;
WriteLine ("Guess a number between 1 and 100");
WriteLine ("Is the greater than 50?(if yes press Y or press N");
int minimum = 0, maximum = 0, middle = 0;
var key = ReadKey ().Key;
if (key == ConsoleKey.Y) {
   minimum = 50; maximum = 100;
   for (int i = 0; i < 6; i++) {
      if (middle != minimum || maximum - minimum != 1) {
         middle = ((maximum + minimum + 1) / 2);
         WriteLine ($"\nIs the number greater than {middle}? (press Y for yes N for no)");
         if (ReadKey ().Key == ConsoleKey.Y) minimum = middle;
         else maximum = middle;
      }
   }
   WriteLine ($"The guessed number is {maximum}");
} else if (key == ConsoleKey.N) {
   minimum = 1; maximum = 50;
   for (int i = 0; i < 6; i++) {
      if (middle != minimum || maximum - minimum != 1) {
         middle = (maximum + minimum + 1) / 2;
         WriteLine ($"\nIs the number greater than {middle}? (press Y for yes N for no)");
         if (ReadKey ().Key == ConsoleKey.Y) minimum = middle;
         else maximum = middle;
      }
   }
   WriteLine ($"The guessed number is {maximum}");
}
