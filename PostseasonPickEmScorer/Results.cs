using System.Collections.Generic;

namespace PostseasonPickEmScorer
{
    public class Results
    {
        public Results()
        {
            Gauntlet = new List<GauntletResult>();
            WildCardRound = new List<WildcardRoundResult>();
            Playoff = new List<PlayoffResult>();
        }

        public string Name;
        public List<GauntletResult> Gauntlet;
        public List<WildcardRoundResult> WildCardRound;
        public List<PlayoffResult> Playoff;
    }
}
