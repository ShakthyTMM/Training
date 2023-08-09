Console.WriteLine ("Enter a text: ");
string name = Console.ReadLine ();
var origi = name.ToLower ().Replace (" ", "").ToCharArray ();
var rev = name.ToLower ().Replace (" ", "").ToCharArray ();
Array.Reverse (rev);
if (Enumerable.SequenceEqual (origi, rev)) Console.WriteLine ("It is a palindrome"); else Console.WriteLine ("It is not a palindrome");
