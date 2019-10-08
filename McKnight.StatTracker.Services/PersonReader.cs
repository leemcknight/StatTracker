using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McKnight.StatTracker.Model;

namespace McKnight.StatTracker.Services
{
    public class PersonReader : CsvReader<Person>
    {
        public PersonReader()
        {
            TransformFunc = (arr => new Person
            {
                PersonId = arr[0],
                FirstName = UnQuote(arr[2]),
                LastName = UnQuote(arr[1]),
                PlayerDebut = GetSafeDate(arr[3]),
                ManagerDebut = GetSafeDate(arr[4]),
                UmpireDebut = GetSafeDate(arr[5])
            });

            Path = "Data/people/people.txt";
        }      
       

    }
}
