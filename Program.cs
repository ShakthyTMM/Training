// Program to Reverse a given number
using static System.Console;
WriteLine ("Enter a number: ");
string Number = ReadLine () ?? "";
int i, numberLength = Number.Length;
int condition = numberLength / 2;
for (i = 0; i <= condition; i++)
   if (Number[i] != Number[numberLength - 1 - i])
      break;
WriteLine ("It is " + (i == condition + 1 ? "" : "not ") + "a palindrome");
