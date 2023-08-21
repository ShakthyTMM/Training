Console.WriteLine ("Enter a number: ");
int num = int.Parse (Console.ReadLine ());
int original = num;
int n = 0;
while (num > 0) {
   int rem = num % 10;
   n = (10 * n) + rem;
   num /= 10;
}
Console.WriteLine (n);
if (original == n) Console.WriteLine ("It is a palindrome");
else Console.WriteLine ("It is not a palindrome");
