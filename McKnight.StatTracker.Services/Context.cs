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
        KeyedList<Person> people;
        IEnumerable<Franchise> franchises;
        KeyedList<Ballpark> ballparks;
        IEnumerable<PlayModifier> playModifiers;
        IDictionary<string, string> playDescriptions;
        IEnumerable<FieldLocation> fieldLocations;

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

        public KeyedList<Person> People
        {
            get
            {
                if (people == null)
                {
                    people = new KeyedList<Person>(
                        new PersonReader().Read()
                        .ToDictionary(person => person.PersonId, person => person));
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

        public KeyedList<Ballpark> Ballparks
        {
            get
            {
                if(ballparks == null)
                {
                    ballparks = new KeyedList<Ballpark>(new BallparkReader()
                        .Read()
                        .ToDictionary(park => park.BallparkId, park => park));
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

        public IEnumerable<FieldLocation> FieldLocations
        {
            get
            {
                if(fieldLocations == null)
                {
                    fieldLocations = new FieldLocationReader().Read();                        
                }
                return fieldLocations;
            }
        }
        

    }
}
