using McKnight.StatTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Services
{
    public class Context
    {
        IEnumerable<Person> people;
        IEnumerable<Franchise> franchises;
        IEnumerable<Ballpark> ballparks;
        IEnumerable<PlayModifier> playModifiers;
        IDictionary<string, string> playDescriptions;

        private static Context instance;
        public static Context Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Context();
                }
                return instance;
            }
        }

        public IEnumerable<Person> People
        {
            get
            {
                if (people == null)
                {
                    people = new PersonReader().Read();                    
                }

                return people;
            }
        }

        public IEnumerable<Franchise> Franchises
        {
            get
            {
                if(franchises == null)
                {
                    franchises = new FranchiseReader().Read();
                }
                return franchises; 
            }            
        }

        public IEnumerable<Ballpark> Ballparks
        {
            get
            {
                if(ballparks == null)
                {
                    ballparks = new BallparkReader().Read();
                }
                return ballparks;
            }
        }

        public IEnumerable<PlayModifier> PlayModifiers
        {
            get
            {
                if(playModifiers == null)
                {
                    playModifiers = new ModifierReader().Read();
                }
                return playModifiers;
            }
        }

        public IDictionary<string,string> PlayDescriptions
        {
            get
            {
                if(playDescriptions == null)
                {
                    playDescriptions = new PlayDescriptionReader()
                        .Read()
                        .ToDictionary(kv => kv.Key, kv => kv.Value);
                }
                return playDescriptions;
            }
        }

    }
}
