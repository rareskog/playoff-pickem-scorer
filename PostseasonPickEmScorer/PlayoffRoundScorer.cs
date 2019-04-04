using System;

namespace PostseasonPickEmScorer
{
    public class PlayoffRoundScorer
    {
        private readonly string _winningTeam;
        private readonly int _numberOfGames;
        private readonly int _winningScore;
        private readonly int _losingScore;

        public PlayoffRoundScorer(string winningTeam, int numberOfGames, int winningScore, int losingScore)
        {
            _winningTeam = winningTeam;
            _numberOfGames = numberOfGames;
            _winningScore = winningScore;
            _losingScore = losingScore;
        }

        public int ScoreFor(string pickedTeam, int pickedNumberOfGames, int pickedWinningScore, int pickedLosingScore)
        {
            var score = 0;
            if (pickedTeam != _winningTeam)
                return score;
            score += 1;

            if (pickedNumberOfGames == _numberOfGames)
                score += 3;

            if (pickedWinningScore == _winningScore && pickedLosingScore == _losingScore)
            {
                score += 10;
            }
            else if (WithinOne(pickedWinningScore, _winningScore) && WithinOne(pickedLosingScore, _losingScore))
            {
                score += 4;
            }

            return score;
        }

        private bool WithinOne(int a, int b)
        {
            return Math.Abs(a - b) <= 1;
        }
    }
}
