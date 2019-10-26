using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McKnight.StatTracker.Model;

namespace McKnight.StatTracker.Services
{
    public class AtBatReader
    {
        public AtBat Read(string[] arr)
        {
            PlayReader playReader = new PlayReader();
            AtBat atBat = new AtBat();

            atBat.Inning = int.Parse(arr[1]);
            atBat.BatterId = arr[3];
            atBat.FinalCount = arr[4];
            atBat.Pitches = ParsePitchString(arr[5]);
            atBat.Play = ParsePlay(arr[6]);
            return atBat;
        }

        private List<Pitch> ParsePitchString(string pitchString)
        {

            List<Pitch> pitches = new List<Pitch>();
            foreach (char c in pitchString)
            {
                string name = Enum.GetName(typeof(PitchResult), c);
                Pitch pitch = null;
                if (null != name)
                {
                    if(pitch == null)
                    {
                        pitch = new Pitch();
                    }
                    pitch.PitchResult = (PitchResult)Enum.Parse(typeof(PitchResult), name);
                    pitches.Add(pitch);
                    pitch = null;
                }
                else
                {
                    name = Enum.GetName(typeof(AfterPitchEvent), c);
                    pitch = new Pitch();
                    pitch.AfterPitchEvent = (AfterPitchEvent)Enum.Parse(typeof(AfterPitchEvent), name);
                }
                
            }
            return pitches;
        }

        private Play ParsePlay(string playString)
        {
            string[] rightTwo = playString.Split('.');
            string baseAdvanceString = rightTwo.Length > 1 ? rightTwo[1] : "";
            string[] modifierParts = rightTwo[0].Split('/');
            string playDescription = modifierParts[0];  //first part                                                
            Play play = new Play();
            play.PlayDescription = playDescription;
            play.BaseAdvanceString = baseAdvanceString;
            for(int i = 1; i < modifierParts.Length; i++)
            {
                play.Modifiers.Add(modifierParts[i]);
            }
            return play;
        }
    }
}
