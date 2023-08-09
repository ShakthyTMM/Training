Console.WriteLine ("Enter number of terms: ");
int n = int.Parse (Console.ReadLine ());
int num = 0, sum = 1, val = 0;
if (n == 1) {
   Console.Write ("0");
} else Console.Write ("0 1 ");
for (int i = 1; i <= n - 2; i++) {
   if (n > 2) {
      val = num + sum;
      Console.Write (val + " ");
      num = sum;
      sum = val;
   }
}
