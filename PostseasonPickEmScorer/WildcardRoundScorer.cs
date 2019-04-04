namespace PostseasonPickEmScorer
{
    public class WildcardRoundScorer
    {
        private readonly string _winningTeam;

        public WildcardRoundScorer(string winningTeam)
        {
            _winningTeam = winningTeam;
        }

        public int ScoreFor(string pickedTeam)
        {
            return pickedTeam == _winningTeam ? 2 : 0;
        }
    }
}
