using static System.Console;
while (true) {
   WriteLine ("\nEnter a number :");
   if (int.TryParse (Console.ReadLine (), out int num)) {
      WriteLine ("Do you want convert to (B)inary or (H)exadecimal?");
      switch (ReadKey ().Key) {
         case (ConsoleKey.B):
            WriteLine ("\n" + Convert.ToString (num, 2));
            break;
         case (ConsoleKey.H):
            WriteLine ($"\n{num:X}");
            break;
         default:
            WriteLine ("Enter a valid number");
            break;
      }
   }
   WriteLine ("Do you want to convert again? (Y)es or (No)");
   if (ReadKey ().Key == ConsoleKey.Y) continue;
   else break;
}
      