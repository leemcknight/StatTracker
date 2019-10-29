using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McKnight.StatTracker.Model;

namespace McKnight.StatTracker.Services
{
    public class FranchiseReader : CsvReader<Franchise>
    {
        public FranchiseReader()
        {
            TransformFunc = (arr => new Franchise
            {
                CurrentFranchiseId = arr[0],
                FranchiseId = arr[1],
                League = arr[2],
                Division = arr[3],
                Location = arr[4],
                Nickname = arr[5],
                AlternateNicknames = arr[6],
                FirstGame = DateTime.Parse(arr[7]),
                LastGame = string.IsNullOrEmpty(arr[8].Trim()) ? DateTime.MaxValue : DateTime.Parse(arr[8]),
                City = arr[9],
                State = arr[10]                
            });

            Path = "Data/franchises/CurrentNames.txt";
        }
    }
}
