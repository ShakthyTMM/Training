//Program.cs
//VOTING CONTEST
//Program to get votes in a string and return the winner with maximum number of votes
//Sample Input :Helloworld
//Sample Output :L, 3 => Winner and votes 
using static System.Console;
while (true) {
   Write ("Give your vote(s): ");
   string votes = ReadLine ().ToLower ().Replace (" ", "");
   if (!string.IsNullOrEmpty (votes) && votes.All (Char.IsLetter)) {
      var (c, v) = GetWinner (votes);
      WriteLine ($"The Winner is {c} with {v} vote(s)");
      break;
   } else Write ("Enter a valid vote\n");
}

///<summary>Function getWinner to return the winner with number of votes </summary>
///<param name="votes">votes given as string</param>
(char Candidate, int Votes) GetWinner (string votes)
   => votes.GroupBy (x => x)
          .Select (x => (candidate: x.Key, votes: x.Count ()))
          .OrderByDescending (x => x.votes)
          .FirstOrDefault ();

