//Program to Check for ISOGRAM
using static System.Console;
WriteLine ("Enter a string: ");
string isogram = ReadLine () ?? "";
bool result = CheckIsogram (isogram);
WriteLine ("The String is " + (result == true ? "" : "not ") + "an Isogram");
bool CheckIsogram (string Isogram) {
   return Isogram.Distinct ().Count () == Isogram.Length;
}

