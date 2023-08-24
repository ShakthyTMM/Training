Console.WriteLine ("Guess a number between 1 and 100");
Console.WriteLine ("Is the greater than 50?(if yes press Y or press N");
int minimum = 0, maximum = 0, middle = 0;
var key = Console.ReadKey ().Key;
if (key == ConsoleKey.Y) {
   minimum = 50; maximum = 100;
   for (int i = 0; i < 6; i++) {
      if (middle != minimum || maximum - minimum != 1) {
         middle = ((maximum + minimum + 1) / 2);
         Console.WriteLine ($"\nIs the number greater than {middle}? (press Y for yes N for no)");
         if (Console.ReadKey ().Key == ConsoleKey.Y) minimum = middle;
         else maximum = middle;
      }
   }
   Console.WriteLine ($"The guessed number is {maximum}");
} else if (key == ConsoleKey.N) {
   minimum = 1; maximum = 50;
   for (int i = 0; i < 6; i++) {
      if (middle != minimum || maximum - minimum != 1) {
         middle = (maximum + minimum + 1) / 2;
         Console.WriteLine ($"\nIs the number greater than {middle}? (press Y for yes N for no)");
         if (Console.ReadKey ().Key == ConsoleKey.Y) minimum = middle;
         else maximum = middle;
      }
   }
   Console.WriteLine ($"The guessed number is {maximum}");
}
