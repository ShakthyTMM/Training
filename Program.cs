//Program.cs
//VOTING CONTEST
//Program to get votes in a string and return the winner with maximum number of votes
//Sample Input :Helloworld
//Sample Output :L, 3 => Winner and votes 
using System.Diagnostics.Metrics;
using static System.Console;
WriteLine ("Give your vote(s): ");
string votes = ReadLine ().ToLower ().Replace (" ", "");
if (votes != "" && votes.All (Char.IsLetter)) {
   var vote = getWinner (votes);
   string key = vote.Char.ToString ();
   WriteLine ($"The Winner is ({key} or {key.ToUpper ()}) with {vote.Counter} vote(s)");
} else Write ("Enter a valid vote");

///<summary>Function getWinner to return the winner with number of votes </summary>
///<param name="votes">votes given as string</param>
(char Char, int Counter) getWinner (string votes) {
   var vote = votes.GroupBy (x => x)
                 .Select (x => (Char: x.Key, counter: x.Count ()))
                 .OrderByDescending (x => x.counter).FirstOrDefault ();
   return (vote.Char, vote.counter);

}
