//Program.cs
//VOTING CONTEST
//Program to get votes in a string and return the winner with maximum number of votes
//Sample Input :Helloworld
//Sample Output :L, 3 => Winner and votes 
using static System.Console;
WriteLine ("Give your vote(s): ");
string votes = ReadLine ().ToLower ().Replace (" ", "");
if (!string.IsNullOrEmpty (votes) && votes.All (Char.IsLetter)) {
   var vote = GetWinner (votes);
   WriteLine ($"The Winner is {vote.Candidate} with {vote.Votes} vote(s)");
} else Write ("Enter a valid vote");

///<summary>Function getWinner to return the winner with number of votes </summary>
///<param name="votes">votes given as string</param>
(char Candidate, int Votes) GetWinner (string votes) {
   var vote = votes.GroupBy (x => x).Select (x => (candidate: x.Key, votes: x.Count ())).OrderByDescending (x => x.votes).FirstOrDefault ();
   return (vote.candidate, vote.votes);
}
