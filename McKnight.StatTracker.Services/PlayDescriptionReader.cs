using McKnight.StatTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Services
{
    public class PlayDescriptionReader : CsvReader<PlayDescription>
    {
        public PlayDescriptionReader()
        {
            Path = "Data/lookups/play_descriptions.csv";
            TransformFunc = (arr => new PlayDescription { Code = arr[0], Description = arr[1], Summary = arr[2] });
        }
    }
}
