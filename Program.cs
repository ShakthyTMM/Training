// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// File name parser
// To parse a file name and return a tuple with the drive, folders, file name and extension
// ----------------------------------------------------------------------------------------
using static State;
using static System.Console;

(char?, string[], string, string) NULL = (null, null, null, null);
// Test cases for Filename parser
Dictionary<string, (char? drive, string[] folders, string fname, string ext)> sTests = new () {
   ["C:\\PROGRAMS\\DOCUMENTS\\README.TXT"] = ('C', new[] { "PROGRAMS", "DOCUMENTS" }, "README", "TXT"),
   ["C:\\PROGRAMS\\DOCUMENTS\\FILES\\README.TXT"] = ('C', new[] { "PROGRAMS", "DOCUMENTS", "FILES" }, "README", "TXT"),
   ["C:\\README.TXT"] = ('C', new[] { "" }, "README", "TXT"), ["C:\\PROGRAMS\\DOCUMENTS\\README"] = NULL,
   ["C:\\PROGRAMS\\DOCUMENTS/README"] = NULL, ["C:\\"] = NULL, [":\\PROGRAMS\\README.TXT"] = NULL,
   ["C:\\\\DOCUMENTS\\README"] = NULL, ["C:PROGRAMS\\DOCUMENTS\\README.TXT"] = NULL,
   ["C:PROGRAMS\\DOCUMENTS\\README."] = NULL, ["C:.TXT"] = NULL, ["CPROGRAMS\\DOCUMENTS\\README.TXT"] = NULL,
   ["C:PROGRAMS\\DOCUMENTS\\README.TXT"] = NULL
};
foreach (var (s, f1) in sTests) {
   (char? drive, string[] folders, string fname, string ext) f2 = FileParse (s);
   ForegroundColor = Same (f1, f2) ? ConsoleColor.White : ConsoleColor.Red;
   if (f2 == NULL) {
      Write ($"{s} => NULL\n");
      continue;
   }
   Write ($"{s} =>{f2.drive}, ");
   if (f2.folders != null && f2.folders.Length != 0)
      foreach (var folder in f2.folders)
         Write ($"{folder}" + (Array.IndexOf (f2.folders, folder) == (f2.folders.Length - 1) ? $", " : "\\"));
   Write ($"{f2.fname}, {f2.ext}\n");
   ResetColor ();
}
bool Same ((char? drive, string[] folders, string fname, string exp) f1, (char? drive, string[] folders, string fname, string exp) f2) {
   if (f2 == NULL && !f1.Equals (f2)) return false;
   if (f2.folders != null && f2.folders.Length != 0)
      for (int i = 0; i < f2.folders.Length; i++)
         if (f1.folders[i] != f2.folders[i]) return false;
   if (!(f1.drive == f2.drive && f1.fname == f2.fname && f1.exp == f2.exp)) return false;
   return true;
}

/// <summary>Parses a file name and returns the parts of the file name as a tuple</summary>
/// State diagram reference: file://C:/Users/ranganathansh/Pictures/statediagram.jpg
(char?, string[], string, string) FileParse (string input) {
   State s = A;
   Action none = () => { },todo;
   char? drive = null; int i = 0; string[] folder = new string[input.Length]; string fname = "", ext = "";
   foreach (var ch in input + '~') {
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
   return (null, null, null, null);
}
enum State { A, B, C, D, E, F, G, I, Z };