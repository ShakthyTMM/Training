// Program for Voting Contest
using System.Diagnostics.Metrics;
using static System.Console;
WriteLine ("Give your vote(s): ");
string votes = ReadLine ().ToLower ().Replace (" ", "");
if (votes.All (Char.IsLetter)) {
   var vote = getWinner (votes);
   string key = vote.Char.ToString ();
   WriteLine ((vote.Char != ' ' ? $"The Winner is ({key} or {key.ToUpper ()}) with {vote.Counter} vote(s)" : "No votes were counted"));
} else Write ("Enter a valid vote");

(char Char, int Counter) getWinner (string votes) {
   if (votes != "") {
      var vote = votes.GroupBy (x => x)
            .Select (x => new { Char = x.Key, counter = x.Count () })
            .OrderByDescending (x => x.counter).FirstOrDefault ();
      return (vote.Char, vote.counter);
   } else return (' ', 0);
}
