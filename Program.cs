namespace _1 {
   internal class Program {
      static void Main (string[] args) {
         Console.WriteLine ("Enter a number :");
         if (int.TryParse (Console.ReadLine (), out int num)) {
            Console.WriteLine ("Do you want convert to (B)inary or (H)exadecimal?");
            switch (Console.ReadKey ().Key) {
               case (ConsoleKey.B):
                  Console.WriteLine ();
                  Console.WriteLine (Convert.ToString (num, 2));
                  break;
               case (ConsoleKey.H):
                  Console.WriteLine ();
                  Console.WriteLine ($"{num:X}");
                  break;
               default:
                  Console.WriteLine ("Enter a valid number");
                  break;
            }
         }
      }
   }
}