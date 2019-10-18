using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    public class Game
    {
        private IDictionary<string, string> metaData = new Dictionary<string, string>();
        private IList<AtBat> atBats = new List<AtBat>();
        public string HomeTeamId
        {
            get { return metaData["hometeam"]; }
        }

        public string VisitingTeamId
        {
            get
            {
                return metaData["visteam"];
            }
        }

        public string HomePlateUmpireId
        {
            get { return metaData["umphome"]; }
        }

        public string FirstBaseUmpireId
        {
            get { return metaData["ump1b"]; }
        }

        public string SecondBaseUmpireId
        {
            get { return metaData["ump2b"]; }
        }

        public string ThirdBaseUmpireId
        {
            get { return metaData["ump3b"]; }
        }

        public string FieldConditions
        {
            get { return metaData["fieldcond"]; }
        }

        public string Precipitation
        {
            get { return metaData["precip"]; }
        }

        public string Sky
        {
            get { return metaData["sky"]; }
        }

        public string Temperature
        {
            get { return metaData["temp"]; }
        }

        public string WindDirection
        {
            get { return metaData["winddir"]; }
        }

        public string WindSpeed
        { 
            get { return metaData["windspeed"]; }
        }

        public int GameDuration
        {
            get { return int.Parse(metaData["timeofgame"]); }
        }

        public int Attendance
        {
            get { return int.Parse(metaData["attendance"]);  }
        }

        public string BallparkId
        {
            get { return metaData["site"];  }
        }

        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool UseDH { get; set; }        
        public IList<AtBat> AtBats
        {
            get { return atBats; }
        }
        public IDictionary<string, string> MetaData { get { return metaData; } }
    }
}
