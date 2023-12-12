// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Expression evaluator
// Implementation of unary operator in the expression evaluator
// ----------------------------------------------------------------------------------------
namespace Eval {
   internal class Program {
      static void Main (string[] args) {
         var eval = new Evaluator ();
         for (; ; ) {
            Console.Write (">");
            string input = Console.ReadLine ().Trim ().ToLower ();
            if (input == "") break;
            try {
               double result = eval.Evaluate (input);
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine (Math.Round (result, 10));
            } catch (Exception e) {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine (e.Message);
            }
            Console.ResetColor ();
         }

      }
   }
}
