// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Anagram
// To print all possible anagrams 
// ----------------------------------------------------------------------------------------
var wordsList = File.ReadAllLines ("C:/etc/words.txt")
            .GroupBy (x => string.Concat (x.OrderBy (c => c))) // Grouping the anagrams by sorting them 
            .Where (x => x.Count () > 1) // Eliminating the non anagrams words
            .OrderByDescending (x => x.Count ()); // Arranging based on the number of anagrams in descending order 
using (StreamWriter sw = new ("C:/etc/test.txt"))
   foreach (var words in wordsList) sw.WriteLine ($"{words.Count ()} {string.Join (", ", words)}");