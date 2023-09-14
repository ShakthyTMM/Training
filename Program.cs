//Program to Print Diamond
Console.WriteLine ("Enter no of lines: ");
int n = int.Parse (Console.ReadLine () ?? "");
int space = n;
int condition = (n * 2) + 1;
for (int i = 1; i <= condition; i += 2) {
   Console.WriteLine (string.Concat (Enumerable.Repeat (" ", space)) + string.Concat (Enumerable.Repeat ("*", i)));
   space--;
}
int blank = 1;
for (int j = condition - 2; j >= 1; j -= 2) {
   Console.WriteLine (string.Concat (Enumerable.Repeat (" ", blank)) + string.Concat (Enumerable.Repeat ("*", j)));
   blank++;
}
