using System.Text;
Console.OutputEncoding = new UnicodeEncoding ();
string[] str1 = new[] { "\u265C", "\u265E", "\u265D", "\u265B", "\u265A", "\u265D", "\u265E", "\u265C" };
string[] str2 = new[] { "\u2656", "\u2658", "\u2657", "\u2655", "\u2654", "\u2657", "\u2658", "\u2656" };
Console.WriteLine ("\u250C" + string.Concat (Enumerable.Repeat ("\u2500\u2500\u2500\u252C", 7)) + "\u2500\u2500\u2500\u2510");
for (int j = 0; j < str1.Length; j++)
   Console.Write ("\u2502 " + str1[j] + " ");
Console.WriteLine ("\u2502");
Console.WriteLine ("\u251C" + string.Concat (Enumerable.Repeat ("\u2500\u2500\u2500\u253C", 7)) + "\u2500\u2500\u2500\u2524");
Console.Write (string.Concat (Enumerable.Repeat ("\u2502 \u265F ", 8)));
Console.WriteLine ("\u2502");
Console.WriteLine ("\u251C" + string.Concat (Enumerable.Repeat ("\u2500\u2500\u2500\u253C", 7)) + "\u2500\u2500\u2500\u2524");
for (int i = 3; i <= 6; i++) {
   Console.WriteLine (string.Concat (Enumerable.Repeat ("\u2502   ", 9)));
   Console.WriteLine ("\u251C" + string.Concat (Enumerable.Repeat ("\u2500\u2500\u2500\u253C", 7)) + "\u2500\u2500\u2500\u2524");
}
Console.Write (string.Concat (Enumerable.Repeat ("\u2502 \u2659 ", 8)));
Console.WriteLine ("\u2502");
Console.WriteLine ("\u251C" + string.Concat (Enumerable.Repeat ("\u2500\u2500\u2500\u253C", 7)) + "\u2500\u2500\u2500\u2524");
for (int k = 0; k < str2.Length; k++) {
   Console.Write ("\u2502 " + str2[k] + " ");
}
Console.WriteLine ("\u2502");
Console.WriteLine ("\u2514" + string.Concat (Enumerable.Repeat ("\u2500\u2500\u2500\u2534", 7)) + "\u2500\u2500\u2500\u2518");
