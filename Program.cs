using System.Linq;
internal class Program {
   private static void Main (string[] args) {
      List<int> list = new List<int> ();
      IEnumerable<int> a = Enumerable.Range (1, 10000000);
      foreach (var i in a) {
         string length = Convert.ToString (i);
         var number = i;
         double sum = 0;
         for (int j = 1; j <= length.Length; j++) {
            var rem = number % 10;
            sum = sum + Math.Pow (rem, length.Length);
            number /= 10;
         }
         if (sum == i) {
            list.Add (i);
         }
      }
      string temp = String.Join ("", args);
      int count = Convert.ToInt32 (temp);
      Console.WriteLine (list.ElementAt (count - 1));
   }

}
