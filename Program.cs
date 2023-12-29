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

(char?, string, string, string) NULL = (null, null, null, null);
// Test cases for Filename parser
Dictionary<string, (char?, string, string, string)> sTests = new () {
   ["C:/PROGRAMS/DOCUMENTS/README.TXT"] = ('C', "PROGRAMS/DOCUMENTS", "README", "TXT"),
   ["C:/PROGRAMS/DOCUMENTS/FILES/README.TXT"] = ('C', "PROGRAMS/DOCUMENTS/FILES", "README", "TXT"),
   ["C:/README.TXT"] = ('C', "", "README", "TXT"), ["C:/PROGRAMS/DOCUMENTS/README"] = NULL,
   ["C:/PROGRAMS/DOCUMENTS/README"] = NULL, ["C:/"] = NULL, [":/PROGRAMS/README.TXT"] = NULL,
   ["C://DOCUMENTS/README"] = NULL, ["C:PROGRAMS/DOCUMENTS/README.TXT"] = NULL,
   ["C:PROGRAMS/DOCUMENTS/README."] = NULL, ["C:.TXT"] = NULL, ["CPROGRAMS/DOCUMENTS/README.TXT"] = NULL,
   ["C:PROGRAMS/DOCUMENTS/README.TXT"] = NULL
};
foreach (var (s, f1) in sTests) {
   (char? drive, string folders, string fname, string ext) f2 = FileParse (s);
   ForegroundColor = Same (f1, f2) ? ConsoleColor.White : ConsoleColor.Red;
   Write (f2 == NULL ? $"{s} => NULL\n" : $"{s} =>{f2.drive}, {f2.folders}, {f2.fname}, {f2.ext}\n");
   ResetColor ();
}
bool Same ((char?, string, string, string) f1, (char?, string, string, string) f2) => f1.Equals (f2);

/// <summary>Parses a file name and returns the parts of the file name as a tuple</summary>
/// State diagram reference: file://C:/Users/ranganathansh/Pictures/statediagram.jpg
(char?, string, string, string) FileParse (string input) {
   State s = A;
   Action none = () => { }, todo;
   char? drive = null; int i = 0; string[] folders = new string[input.Length]; string fname = "", ext = "";
   foreach (var ch in input + '~') {
      (s, todo) = (s, ch) switch {
         (A, >= 'A' and <= 'Z') => (B, () => drive = ch),
         (B, ':') => (C, none),
         (C, '/') => (D, none),
         (D or E, >= 'A' and <= 'Z') => (E, () => folders[i] += ch),
         (E, '/') => (D, () => { folders[i] += '/'; i++; }),
         (E, '.') => (F, () => { fname = folders[i]; folders = folders[..i]; }),
         (F or G, >= 'A' and <= 'Z') => (G, () => ext += ch),
         (G, '~') => (I, none),
         _ => (Z, none),
      };
      todo ();
   }
   if (s == I) {
      string folder = string.Join ("", folders).TrimEnd ('/');
      return (drive, folder, fname, ext);
   }
   return (null, null, null, null);
}
enum State { A, B, C, D, E, F, G, I, Z };