//Program.cs
//CHOCOLATE WRAPPERS
//Program to find the maximum number of chocolates that can get along with any unused money X and wrappers W
//Given money X , along with price P of a chocolate and required wrappers W for a chocolate in exchange.
//Sample Input :X = 15, P = 4, W = 3
// Sample Output :C = 4, X = 3, W = 1
using static System.Console;
Write ("Enter the total money: ");
if (!int.TryParse (ReadLine (), out int money) || money <= 0)
   Write ("Enter valid money");
else {
   Write ("Enter price of a chocolate: ");
   if (!int.TryParse (ReadLine (), out int priceofChocolate) || priceofChocolate <= 0)
      Write ("Enter valid price for a chocolate");
   else {
      Write ("Enter the number of wrappers in exchange for a chocolate: ");
      if (!int.TryParse (ReadLine (), out int wrappers) || wrappers <= 0)
         Write ("Enter valid number of wrappers");
      else if (money >= priceofChocolate) {
         var result = GetmaxChoc (money, priceofChocolate, wrappers);
         Write ($"\nThe maximum number of chocolates :{result.MaxChoc}\nThe remaining money: {result.Money}\nThe remaining wrappers: {result.Wrappers}\n");
      } else Write ("The Money is too Low.");
   }
}
/// <summary>This method returns a tuple with maximum chocolate for the given money with remaining money and remaining wrappers</summary>
/// <param name="a">This is the money available</param>
/// <param name="b">This is the price of a chocolate</param>
/// <param name="c">This is the number of wrappers exchanges for a chocolate</param>
(int MaxChoc, int Money, int Wrappers) GetmaxChoc (int a, int b, int c) {
   int maxchoc = a / b, money = a % b, wrappers = maxchoc, extrachoc = 0;
   while (wrappers >= c) {
      for (; wrappers >= c; wrappers -= c) {
         maxchoc++;
         extrachoc++;
      }
      wrappers += extrachoc;
      extrachoc = 0;
   }
   return (maxchoc, money, wrappers);
}