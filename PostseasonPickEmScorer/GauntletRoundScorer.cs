using System.Collections.Generic;

namespace PostseasonPickEmScorer
{
    public class GauntletRoundScorer
    {
        private readonly List<string> _survivingTeams;

        public GauntletRoundScorer(List<string> survivingTeams)
        {
            _survivingTeams = survivingTeams;
        }

        public int ScoreFor(List<string> pickedTeams)
        {
            var score = 0;
            foreach (var survivingTeam in _survivingTeams)
            {
                if (pickedTeams.Contains(survivingTeam))
                    score += 4;
            }

            return score;
        }
    }
}
