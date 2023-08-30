//Program to Find Factorial of a Number
Console.WriteLine ("Enter a number: ");
double.TryParse (Console.ReadLine (), out double fact);
Console.WriteLine (Factorial (fact));
double Factorial (double n) {
   if (n != 0)
      return n * Factorial (n - 1);
   return 1;
}

