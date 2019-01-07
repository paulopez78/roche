using System;
using System.Collections.Generic;
using System.Linq;

namespace VotingApp.Lib
{
    public class Voting
    {
        public Voting()
        {

        }

        public Dictionary<string, int> Votes { get; private set; }
        public string Winner { get; private set; }

        public void Start(params string[] options)
        {
            Votes = options.ToDictionary(option => option, value => 0);
        }

        public void Vote(string option)
        {
            Votes[option] = Votes[option] + 1;
        }

        public void Finish()
        {
            var maxVotes = Votes.Max(x => x.Value);
            Winner = Votes.First(x => x.Value == maxVotes).Key; 
        }
    }
}