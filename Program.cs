//Program to check prime number
Console.WriteLine ("Enter a number: ");
int.TryParse (Console.ReadLine () ?? "", out int num);
int i;
if (num == 1)
   Console.WriteLine ("1 is neither Prime or Composite");
else {
   int Limit = num / 2; 
   for (i = 2; i <= Limit; i++) {
      if (num % i == 0) {
         Console.WriteLine ("The number is not a prime number");
         break;
      }
   }
   if (i > Limit) Console.WriteLine ("The number is a prime number");
}
