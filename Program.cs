Dictionary<int, string> numtoword = new () { { 1, "one" }, { 2, "two" }, { 3, "three" }, { 4, "four" }, { 5, "five" },
    { 6, "six" }, { 7, "seven" }, { 8, "eight" }, { 9, "nine" }, { 10, "Ten" },
    {11,"Eleven" },{12,"Twelve" },{13,"Thirteen" },{14,"Fourteen" },{15,"Fifteen" },
    {16,"Sixteen" },{17,"Seventeen" },{18,"Eighteen" },{19,"Nineteen" },{20,"Twenty" },
    {30,"Thirty" },{40,"Fourty" },{50,"Fifty" },{60,"Sixty"},{70,"Seventy" },{80,"Eighty" },{90,"Ninety" } };
Console.Write ("Enter a number: ");
var num = int.Parse (Console.ReadLine ());
Console.Write ("Do you want to convert to (W)ords or (R)oman number: ");
switch (Console.ReadKey ().Key) {
   case ConsoleKey.W:
      Console.WriteLine ();
      ConvertToWords (num, numtoword);
      break;
   case ConsoleKey.R:
      Console.WriteLine ();
      ConvertToRoman (num);
      break;
   default: Console.WriteLine ("Enter a valid number"); break;
}
void ConvertToWords (int num, Dictionary<int, string> numtoword) {
   int quot = 0;
   string result = "";
   while (num > 0) {
      string Words = Convert.ToString (num);
      if (Words.Length == 8 || Words.Length == 9) {
         quot = num / 10000000;
         result += (Convert.ToString (quot).Length == 2 && quot > 20 ? numtoword[quot - (quot % 10)] + " " + numtoword[quot % 10] : numtoword[quot]) + " Crore ";
         num = num % 10000000;
      }
      if (Words.Length == 6 || Words.Length == 7) {
         quot = num / 100000;
         result += (Convert.ToString (quot).Length == 2 && quot > 20 ? numtoword[quot - (quot % 10)] + " " + numtoword[quot % 10] : numtoword[quot]) + " Lakhs ";
         num = num % 100000;
      }
      if (Words.Length == 5 || Words.Length == 4) {
         quot = num / 1000;
         result += (Convert.ToString (quot).Length == 2 && quot > 20 ? numtoword[quot - (quot % 10)] + " " + numtoword[quot % 10] : numtoword[quot]) + " Thousand ";
         num = num % 1000;
      }
      if (Words.Length == 3) {
         quot = num / 100;
         result += numtoword[quot] + " Hundred and ";
         num = num % 100;
      }
      if (Words.Length == 2) {
         if (Convert.ToString (num).Length == 2 && num > 20) {
            result += numtoword[num - (num % 10)] + " " + numtoword[num % 10];
            num = num / 10;
            break;
         } else {
            result += numtoword[num];
            break;
         }
      }
      if (Words.Length == 1) {
         result += Convert.ToString (num).Length == 2 && num > 20 ? numtoword[num - (num % 10)] + numtoword[num % 10] : numtoword[num];
         num = num / 10;
      }

   }
   Console.WriteLine (result);
}
void ConvertToRoman (int num) {
   Dictionary<int, string> numtoroman = new () {{0, "" }, { 1, "I" }, { 2, "II" }, { 3, "III" }, { 4, "IV" }, { 5, "V" },
    { 6, "VI" }, { 7, "VII" }, { 8, "VIII" }, { 9, "IX" }, { 10, "X" },{40,"XL" },{50,"L" },{90,"XC" },{100,"C"},{200,"CC"},
    {300,"CCC"},{400,"CD"},{500,"D"},{600,"DC" },{700,"DCC" },{800,"DCCC" },{900,"CM"},{1000,"M"}};
   string result = "";
   int val = 0;
   while (num > 0) {
      string Roman = Convert.ToString (num);
      if (Roman.Length == 4)
         result += numtoroman[num];
      if (Convert.ToString (num).Length == 3) {
         val = num - (num % 100);
         result += numtoroman[val];
         num = num % 100;
      }
      if (Roman.Length == 2) {
         if (num > 10 && num < 40) {
            val = num / 10;
            result += string.Concat (Enumerable.Repeat ("X", val)) + numtoroman[num % 10];
            break;
         }
         if (num > 40 && num < 50) {
            val = num % 10;
            result += numtoroman[num - (num % 10)] + numtoroman[num % 10];
            break;
         }
         if (num > 50 && num < 90) {
            val = num - 50;
            result += numtoroman[50] + (val - (val % 10) > 10 ? string.Concat (Enumerable.Repeat ("X", val / 10)) + numtoroman[num % 10] : numtoroman[val]);
            break;
         }
         if (num > 90 && num < 100) {
            val = num - 90;
            result += numtoroman[90] + numtoroman[val];
            break;
         }
         if (num == 10 || num == 40 || num == 50 || num == 90 || num == 100) {
            result += numtoroman[num];
            break;
         }
      }
      if (num < 10) {
         result += numtoroman[num];
         break;
      }
   }
   Console.WriteLine (result);
}
