while (true) {
   int guess = new Random ().Next (1, 100);
   string userguess;
   int val = 0, count = 0;
   Console.WriteLine ("Guess a number between 1 and 100");
   while (val != guess) {
      userguess = Console.ReadLine ();
      if ((!int.TryParse (userguess, out val) || val < 1 || val > 100)) {
         Console.WriteLine ("Invalid Number");
         continue;
      }
      if (val > guess) Console.WriteLine ("Guess is High");
      else if (val != guess) Console.WriteLine ("Guess is Low");
      count++;
   }
   Console.WriteLine (val + " is the correct number");
   Console.WriteLine ("Total number of attempts " + count);
   Console.WriteLine (" Press ENTER to play again");
   if (Console.ReadKey ().Key != ConsoleKey.Enter) break;
   else
      continue;
}
