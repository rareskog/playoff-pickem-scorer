using System;
using System.Linq;

namespace PostseasonPickEmScorer
{
    class Program
    {
        static void Main(string[] args)
        {
            var overview = PickEmOverview.Load();
            var scoreboard = new Scoreboard();
            foreach (var owner in overview.Picks)
            {
                scoreboard.AddOwner(owner.Name);
            }

            foreach (var gauntletResult in overview.Results.Gauntlet)
            {
                var scorer = new GauntletRoundScorer(gauntletResult.SurvivingTeams);
                foreach (var owner in overview.Picks)
                {
                    var pick = owner.Gauntlet.SingleOrDefault(x => x.Round == gauntletResult.Round);
                    if (pick == null)
                        continue;
                    var points = scorer.ScoreFor(pick.SurvivingTeams);
                    scoreboard.AddScore(owner.Name, points);
                }
            }

            foreach (var wildcardRoundResult in overview.Results.WildCardRound)
            {
                var scorer = new WildcardRoundScorer(wildcardRoundResult.WinningTeam);
                foreach (var owner in overview.Picks)
                {
                    var pick = owner.WildCardRound.SingleOrDefault(x => x.Id == wildcardRoundResult.Id);
                    if (pick == null)
                        continue;
                    var points = scorer.ScoreFor(pick.WinningTeam);
                    scoreboard.AddScore(owner.Name, points);
                }
            }

            foreach (var playoffResult in overview.Results.Playoff)
            {
                var scorer = new PlayoffRoundScorer(playoffResult.WinningTeam, playoffResult.NumberOfGames, playoffResult.WinningScore, playoffResult.LosingScore);
                foreach (var owner in overview.Picks)
                {
                    var pick = owner.Playoff.SingleOrDefault(x => x.Id == playoffResult.Id);
                    if (pick == null)
                        continue;
                    var points = scorer.ScoreFor(pick.WinningTeam, pick.NumberOfGames, pick.WinningScore, pick.LosingScore);
                    scoreboard.AddScore(owner.Name, points);
                }
            }

            var results = scoreboard.Publish();
            results.ForEach(Console.WriteLine);
        }
    }
}
