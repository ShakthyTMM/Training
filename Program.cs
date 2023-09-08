// Program to Guess a number 
using static System.Console;
while (true) {
   int guess = new Random ().Next (1, 100);
   string userguess;
   int val = 0, count = 0;
   WriteLine ("Guess a number between 1 and 100");
   while (val != guess) {
      userguess = ReadLine ()?? "";
      if ((!int.TryParse (userguess, out val) || val < 1 || val > 100)) {
         WriteLine ("Invalid Number");
         continue;
      }
      if (val > guess) WriteLine ("Guess is High");
      else if (val != guess) WriteLine ("Guess is Low");
      count++;
   }
   WriteLine ($"{val}  is the correct number\nTotal number of attempts is {count}\nPress ENTER to play again");
   if (ReadKey ().Key != ConsoleKey.Enter) break;
   else
      continue;
}
