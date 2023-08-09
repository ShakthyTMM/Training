Console.WriteLine ("Enter a number: ");
int num = int.Parse (Console.ReadLine ());
int i;
if (num == 1)
   Console.WriteLine ("1 is neither Prime or Composite");
else {
   for (i = 2; i <= num / 2; i++) {
      if (num % i == 0) {
         Console.WriteLine ("The number is not a prime number");
         break;
      }
   }
   if (i > num / 2) Console.WriteLine ("The number is a prime number");
}
