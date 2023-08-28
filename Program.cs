Console.WriteLine ("Enter two numbers: ");
int.TryParse (Console.ReadLine ()?? "", out int a);
int.TryParse (Console.ReadLine () ?? "", out int b);
Console.WriteLine(GetGCD(a, b) + " is the GCD"); 
LCM (a, b);
int GetGCD (int a, int b) {
   if (a == 0) return b;
   else if (b == 0) return a;
   else return (a < b) ? GetGCD (a, b % a) : GetGCD (b, a % b); 
}
void LCM (int a, int b) {
   int max = (a > b) ? a : b;
   while (true) {
      if (max % a == 0 && max % b == 0) {
         Console.WriteLine (max + " is the LCM ");
         break;
      }
      max++;
   }
}
