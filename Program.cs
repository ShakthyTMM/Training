//Program to Swap two Numbers
Console.Write ("Enter the First Number: ");
int.TryParse (Console.ReadLine () ?? "", out int Number1);
Console.Write ("Enter the Second Number: ");
int.TryParse (Console.ReadLine () ?? "", out int Number2);
SwapNumbers (Number1, Number2);

void SwapNumbers (int a, int b) {
   (a, b) = (b, a);
   Console.WriteLine ($"The Swapped Numbers: \nThe First Number is {a} \nThe Second Number is {b}");
}
