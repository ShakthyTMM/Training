internal class Program {
   private static void Main (string[] args) {
      if (int.TryParse (args[0], out int count) && args.Length == 1 && Convert.ToInt32 (args[0]) > 0)
         GetArmstrong (count);
      else Console.WriteLine ("Enter a valid number");
   }
   static void GetArmstrong (int count) {
      int index = 0;
      double sum = 0;
      var number = 0;
      while (count > index) {
         number++;
         sum = 0;
         var check = number;
         string length = Convert.ToString (number);
         for (int j = 1; j <= length.Length; j++) {
            var rem = check % 10;
            sum = sum + Math.Pow (rem, length.Length);
            check /= 10;
         }
         if (sum == number) index++;
      }
      Console.WriteLine ($"The {count}th Armstrong Number is : {sum}");
   }
}
