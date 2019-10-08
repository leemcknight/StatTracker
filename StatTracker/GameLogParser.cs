using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McKnight.StatTracker.Model;

namespace McKnight.StatTracker
{
    public class GameLogParser
    {
        public AtBat ParsePlay(string[] vals)
        {
            AtBat play = new AtBat();
            play.Inning = int.Parse(vals[1]);
            play.BatterId = vals[3];
            play.FinalCount = vals[4];
            string pitchString = vals[5];
            foreach(char c in pitchString)
            {
                play.Pitches.Add(PitchType.Ball);
            }
            return play;
        }

        public void ReadLog(string file)
        {
            StreamReader reader = File.OpenText(file);
            string line;
            Game game = new Game();
            while((line = reader.ReadLine()) != null)
            {
                string[] vals = line.Split(',');
                switch(vals.First())
                {
                    case "Info":
                        game.MetaData.Add(vals[1], vals[2]);
                        break;
                    case "play":
                        AtBat atBat = new AtBat();
                        atBat.Inning = int.Parse(vals[1]);
                        atBat.BatterId = vals[3];
                        atBat.FinalCount = vals[4];
                        atBat.Play = Play.create(vals[6]);
                        game.AtBats.Add(atBat);
                        
                        break;
                }
            }
        }
    }
}
