using System.Collections.Generic;

namespace PostseasonPickEmScorer
{
    public class GauntletResult
    {
        public GauntletResult()
        {
            SurvivingTeams = new List<string>();
        }

        public int Round;
        public List<string> SurvivingTeams;
    }
}