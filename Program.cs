Console.WriteLine ("Enter two numbers: ");
int a = int.Parse (Console.ReadLine ());
int b = int.Parse (Console.ReadLine ());
GCD (a, b);
LCM (a, b);
void GCD (int a, int b) {
   while (a != 0 && b != 0) {
      if (a < b) b %= a; else a %= b;
   }
   Console.WriteLine ((a == 0) ? $"GCD is" + b : $"GCD is " + a);
}
void LCM (int a, int b) {
   int max = (a > b) ? a : b;
   while (true) {
      if (max % a == 0 && max % b == 0) {
         Console.WriteLine ("LCM is " + max);
         break;
      }
      max++;
   }
}
