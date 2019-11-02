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
        private IDictionary<string, PlayModifier> modifiers;
        
        public AtBatReader()
        {
            var mods = new ModifierReader().Read();
            modifiers = mods.ToDictionary(mod => mod.ModifierId, mod => mod);
        }

        public AtBat Read(string[] arr)
        {                        
            AtBat atBat = new AtBat();
            atBat.Inning = int.Parse(arr[1]);
            atBat.BatterId = arr[3];
            atBat.FinalCount = arr[4];
            atBat.Pitches = ParsePitchString(arr[5]);
            atBat.Play = ParsePlay(arr[6]);
            atBat.Batter = Context.Instance.People.Where(person => person.PersonId == atBat.BatterId).FirstOrDefault();
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
            string playDescription = modifierParts[0];
            Play play = new Play();
            
            play.BaseAdvanceString = baseAdvanceString;

            if (modifierParts.Length > 1) { 
                for (int i = 1; i < modifierParts.Length; i++)
                {
                    play.Modifiers.Add(BuildPlayModifier(modifierParts[i]));
                }
            }
            play.PlayDescription = GetPlayDescription(playDescription, play.Modifiers);
            
            return play;
        }

        private Tuple<string, string> SplitModifier(string modifierString)
        {
            return Tuple.Create<string, string>("", "");
        }

        private PlayDescription GetPlayDescription(string descriptionString, IList<PlayModifier> modifiers)
        {
            Context context = Context.Instance;
            if (context.PlayDescriptions.ContainsKey(descriptionString))
            {
                //straight lookup.  map it and shortcut return.
                return context.PlayDescriptions[descriptionString];
            } 
            else
            {
                if(descriptionString.All(ch => Char.IsDigit(ch)))
                {
                    //ground out involving multiple players
                    string sequence = "";
                    foreach(char loc in descriptionString)
                    {                        
                        sequence += GetLocationText(loc.ToString()) + " ";
                        
                    }
                    return new PlayDescription { Description = "grounds out, " + sequence, Summary = "Ground Out" };
                } 
                else if(descriptionString.StartsWith("SB"))
                {
                    //stolen base
                    return new PlayDescription
                    {
                        Description = "runner steals " + GetLocationText(descriptionString.Substring(2, 1)),
                        Summary = "Stolen Base"
                    };
                }
                else if(descriptionString.StartsWith("S"))
                {
                    //single
                    return new PlayDescription
                    {
                        Description = "singles to " + GetLocationText(descriptionString.Substring(1, 1)),
                        Summary = "Single"
                    };
                } 
                else if(descriptionString.StartsWith("D"))
                {
                    //double
                    return new PlayDescription
                    {
                        Description = "doubles to " + GetLocationText(descriptionString.Substring(1, 1)),
                        Summary = "Double"
                    };
                }
                else if(descriptionString.StartsWith("T"))
                {
                    //triple
                    return new PlayDescription
                    {
                        Description = "triples to " + GetLocationText(descriptionString.Substring(1, 1)),
                        Summary = "Triple"
                    };
                }
                
                return new PlayDescription { Summary = descriptionString, Description = descriptionString };
            }
        }

        private string GetLocationText(string locationCode)
        {
            var locs = Context.Instance.FieldLocations.Where(loc => loc.LocationCode == locationCode);
            return locs.FirstOrDefault().LocationText;
        }

        private PlayModifier BuildPlayModifier(string modifierString)
        {
            return Context.Instance.PlayModifiers.Where(modifier => modifierString == modifier.ModifierId).FirstOrDefault();            
        }
    }
}
