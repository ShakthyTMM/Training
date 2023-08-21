Console.WriteLine ("Enter number of rows: ");
int rows = int.Parse (Console.ReadLine ());
int val = 0;
for (int i = 0; i < rows; i++) {
   for (int blank = 0; blank <= rows - i; blank++)
      Console.Write ("   ");
   for (int j = 0; j <= i; j++) {
      if (i == 0 || j == 0 || i == j) val = 1;
      else {
         val = val * (i - j + 1) / j;
      }
      Console.Write (val + "     ");
   }
   Console.WriteLine ();
}

