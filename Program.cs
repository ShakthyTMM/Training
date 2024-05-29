using System.Diagnostics;

namespace PSI;

static class Start {
   static void Main () {
      Routine ("(3 + 2) * 4 - 17 * -five * (two + 1 + 4 + 5)");
      Routine ("3 + 2 > (6 * 5)");
      Routine ("a = (5 + 5) - 6 + 2");
   }

   // Checks the 'ExprGrapher' visitor pattern 
   static void Routine (string expr) {
      var parser = new Parser (new Tokenizer (expr));
      var node = parser.Parse ();
      var sb = node.Accept (new ExprILGen ());
      Console.WriteLine ("\nGenerated code: ");
      Console.WriteLine (sb);
      var graph = new ExprGrapher (expr);
      node.Accept (graph);
      Directory.CreateDirectory ("c:/etc");
      graph.SaveTo ("c:/etc/test.html");
      var pi = new ProcessStartInfo ("c:/etc/test.html") { UseShellExecute = true };
      Process.Start (pi);
      Console.Write ("\nPress any key..."); Console.ReadKey (true);
   }
}
