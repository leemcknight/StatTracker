using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McKnight.StatTracker.Model;

namespace McKnight.StatTracker.Services
{
    public class BallparkReader : CsvReader<Ballpark>
    {        
        public BallparkReader()
        {
            TransformFunc = (arr => new Ballpark
            {
                BallparkId = arr[0],
                Name = arr[1],
                Alias = arr[2],
                City = arr[3],
                State = arr[4],
                StartDate = DateTime.Parse(arr[5]),
                EndDate = DateTime.Parse(arr[6]),
                League = arr[5],
                Notes = arr[6]
            });

            Path = "Data/ballparks/ballparks.txt";
        }        
    }
}
