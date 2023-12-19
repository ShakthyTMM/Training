// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// File name parser
// To parse a file name and return a tuple with the drive, folders, file name and extension
// ----------------------------------------------------------------------------------------
using static State;
Console.Write ("Enter the file name: ");
string input = Console.ReadLine ().Trim ().ToUpper () + "~";
(char drive, string[] folder, string fname, string ext) = FileParse (input);
Console.Write ($"Drive    : {drive}\nFolders  : ");
foreach (var ch in folder) Console.Write ($"{ch}   ");
Console.WriteLine ($"\nFile Name: {fname}\nExtension: {ext}");

/// <summary>Parses a file name and returns the parts of the file name as a tuple</summary>
/// State diagram reference: file://C:/Users/ranganathansh/Pictures/statediagram.jpg
(char, string[], string, string) FileParse (string input) {
   State s = A;
   Action none = () => { };
   Action todo;
   char drive = ' '; int i = 0; string[] folder = new string[input.Length]; string fname = "", ext = "";
   foreach (var ch in input) {
      (s, todo) = (s, ch) switch {
         (A, >= 'A' and <= 'Z') => (B, () => drive = ch),
         (B, ':') => (C, none),
         (C, '\\') => (D, none),
         (D or E, >= 'A' and <= 'Z') => (E, () => folder[i] += ch),
         (E, '\\') => (D, () => i++),
         (E, '.') => (F, () => { fname = folder[i]; folder = folder[..i]; }),
         (F or G, >= 'A' and <= 'Z') => (G, () => ext += ch),
         (G, '~') => (I, none),
         _ => (Z, none),
      };
      todo ();
   }
   if (s == I) return (drive, folder, fname, ext);
   throw new FormatException ("Invalid format");

}
enum State { A, B, C, D, E, F, G, I, Z };