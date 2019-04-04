using System.Collections.Generic;
using System.Linq;

namespace PostseasonPickEmScorer
{
    public class Scoreboard
    {
        public Scoreboard()
        {
            _scoreboard = new Dictionary<string, int>();
        }

        private Dictionary<string, int> _scoreboard;

        public void AddOwner(string ownerName)
        {
            _scoreboard[ownerName] = 0;
        }

        public void AddScore(string owner, int points)
        {
            _scoreboard[owner] += points;
        }

        public List<string> Publish()
        {
            var lines = new List<string>();
            var sortedScoreboard = _scoreboard.OrderByDescending(x => x.Value);
            foreach (var owner in sortedScoreboard)
            {
                lines.Add($"{owner.Key}: {owner.Value}");
            }

            return lines;
        }
    }
}
