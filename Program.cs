Console.WriteLine ("Enter number of terms : ");
int length = int.Parse (Console.ReadLine () ?? "");
List<int> series = new List<int> ();
int a = 0, b = 1, count = 1;
Fibonacci (a, b, count, length);
void Fibonacci (int a, int b, int count, int length) {
   if (count <= length) {
      Console.Write (a + " ");
      series.Add (a);
      Fibonacci (b, a + b, count + 1, length);
   }
}
Console.WriteLine ();
foreach (var item in series) {
   Console.Write (item + " ");
}
