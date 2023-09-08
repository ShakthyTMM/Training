// Program to Reverse a given number
using static System.Console;
WriteLine ("Enter a number: ");
string Number = ReadLine () ?? "";
int i, numberLength = Number.Length;
for (i = 0; i <= numberLength / 2; i++)
   if (Number[i] != Number[numberLength - 1 - i])
      break;
WriteLine ("It is " + (i == numberLength / 2 + 1 ? "" : "not ") + "a palindrome");
