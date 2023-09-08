//Program to Print Digital Root
using static System.Console;
WriteLine ("Enter a number: ");
int num = int.Parse (ReadLine ()?? "");
int sum = 0;
while (num > 0) {
   int n = num % 10;
   sum += n;
   num /= 10;
}
if (sum > 10) {
   int t = sum % 10;
   sum /= 10;
   int m = t + sum;
   WriteLine (m);
} else WriteLine (sum);
