// Program to implement Factorial in a iterative method
using static System.Console;
WriteLine ("Enter a number: ");
int.TryParse (ReadLine (), out var fact);
WriteLine (Factorial (fact));
int Factorial (int fact) {
   int f = 1;
   for (int i = 1; i <= fact; i++)
      f *= i;
   return f;
}
