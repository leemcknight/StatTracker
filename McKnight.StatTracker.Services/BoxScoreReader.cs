using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McKnight.StatTracker.Model;

namespace McKnight.StatTracker.Services
{
    public class BoxScoreReader : CsvReader<BoxScore>
    {
        private DateTime date;
        private string teamId;
        private int gameNumber = 1;

        public BoxScoreReader()
        {
            this.TransformFunc = (arr =>
            {
                var date = GetSafeDate(UnQuote(arr[0]));
                return new BoxScore
                {
                    DateString = UnQuote(arr[0]),
                    Date = date,
                    GameNumber = int.Parse(UnQuote(arr[1])),
                    DayOfWeek = UnQuote(arr[2]),
                    VisitingTeamId = UnQuote(arr[3]),
                    VisitingTeamLeague = UnQuote(arr[4]),
                    VisitingTeamGameNumber = int.Parse(UnQuote(arr[5])),
                    HomeTeamId = UnQuote(arr[6]),
                    HomeTeamLeague = UnQuote(arr[7]),
                    HomeTeamGameNumber = int.Parse(UnQuote(arr[8])),
                    VisitingScore = int.Parse(arr[9]),
                    HomeScore = int.Parse(arr[10]),
                    TotalOuts = int.Parse(arr[11]),
                    DayNightIndicator = UnQuote(arr[12]),
                    CompletionInformation = UnQuote(arr[13]),
                    ForfeitInformation = UnQuote(arr[14]),
                    ProtestInformation = UnQuote(arr[15]),
                    ParkId = UnQuote(arr[16]),
                    Ballpark = Context.Instance.Ballparks[UnQuote(arr[16])],
                    Attendance = GetSafeInt(arr[17]),
                    TimeOfGame = int.Parse(arr[18]),
                    VisitingLineScore = BuildLineScore(UnQuote(arr[19])),
                    HomeLineScore = BuildLineScore(UnQuote(arr[20])),
                    HomeStartingPlayerIds = new string[]
                    {
                        UnQuote(arr[132]),
                        UnQuote(arr[135]),
                        UnQuote(arr[138]),
                        UnQuote(arr[141]),
                        UnQuote(arr[144]),
                        UnQuote(arr[147]),
                        UnQuote(arr[150]),
                        UnQuote(arr[153]),
                        UnQuote(arr[156]),
                    },
                    HomeStartingPlayerPositions = new string[]
                    {
                        UnQuote(arr[134]),
                        UnQuote(arr[137]),
                        UnQuote(arr[140]),
                        UnQuote(arr[143]),
                        UnQuote(arr[146]),
                        UnQuote(arr[149]),
                        UnQuote(arr[152]),
                        UnQuote(arr[155]),
                        UnQuote(arr[158]),
                    },
                    HomeStartingPlayers = new Person[]
                    {
                        Context.Instance.People[UnQuote(arr[132])],
                        Context.Instance.People[UnQuote(arr[135])],
                        Context.Instance.People[UnQuote(arr[138])],
                        Context.Instance.People[UnQuote(arr[141])],
                        Context.Instance.People[UnQuote(arr[144])],
                        Context.Instance.People[UnQuote(arr[147])],
                        Context.Instance.People[UnQuote(arr[150])],
                        Context.Instance.People[UnQuote(arr[153])],
                        Context.Instance.People[UnQuote(arr[156])],
                    },
                    VisitingStartingPlayerIds = new string[]
                    {
                        UnQuote(arr[105]),
                        UnQuote(arr[108]),
                        UnQuote(arr[111]),
                        UnQuote(arr[114]),
                        UnQuote(arr[117]),
                        UnQuote(arr[120]),
                        UnQuote(arr[123]),
                        UnQuote(arr[126]),
                        UnQuote(arr[129]),
                    },
                    VisitingStartingPlayers = new Person[]
                    {
                        Context.Instance.People[UnQuote(arr[105])],
                        Context.Instance.People[UnQuote(arr[108])],
                        Context.Instance.People[UnQuote(arr[111])],
                        Context.Instance.People[UnQuote(arr[114])],
                        Context.Instance.People[UnQuote(arr[117])],
                        Context.Instance.People[UnQuote(arr[120])],
                        Context.Instance.People[UnQuote(arr[123])],
                        Context.Instance.People[UnQuote(arr[126])],
                        Context.Instance.People[UnQuote(arr[129])]
                    },
                    HomeTeam = Context.Instance.Franchises
                                    .Where(team => team.FranchiseId == UnQuote(arr[6]))
                                    .Where(team => date >= team.FirstGame)
                                    .Where(team => date <= team.LastGame)
                                    .FirstOrDefault(),
                    VisitingTeam = Context.Instance.Franchises
                                .Where(team => team.FranchiseId == UnQuote(arr[3]))
                                .Where(team => date >= team.FirstGame)
                                .Where(team => date <= team.LastGame)
                                .FirstOrDefault()
                };
            }

           );
        }

        private IEnumerable<string> BuildLineScore(string lineScore)
        {
            IList<string> score = new List<string>();
            string numString = "";
            bool doubleDigit = false;
            bool closeIt = false;
            foreach (char c in lineScore)
            {
                if (c.Equals('('))
                {
                    doubleDigit = true;
                }
                else if (c.Equals(')'))
                {
                    closeIt = true;
                    doubleDigit = false;
                }
                else
                {
                    numString += c;
                    if (closeIt)
                    {
                        closeIt = false;
                        score.Add(numString);
                        numString = "";
                    }
                    else if (!doubleDigit)
                    {
                        score.Add(numString);
                        numString = "";
                    }
                }

            }

            return score;
        }

        public BoxScoreReader ForDate(DateTime date)
        {
            this.date = date;
            Path = "Data/gamelogs/GL" + date.Year.ToString() + ".TXT";
            return this;
        }

        public BoxScoreReader ForTeam(string teamId)
        {
            this.teamId = teamId;
            return this;
        }

        public BoxScoreReader ForGameNumber(int gameNumber)
        {
            this.gameNumber = gameNumber;
            return this;
        }

        public override IEnumerable<BoxScore> Read()
        {
            return from game in base.Read()
                   where game.GameNumber == gameNumber
                   where game.DateString == date.ToString("yyyyMMdd")
                   where (game.HomeTeamId == teamId || game.VisitingTeamId == teamId)
                   select game;

        }
    }
}
