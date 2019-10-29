using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Services
{
    public class PlayDescriptionReader : CsvReader<KeyValuePair<string,string>>
    {
        public PlayDescriptionReader()
        {
            Path = "Data/lookups/play_descriptions.csv";
            TransformFunc = (arr => new KeyValuePair<string, string>(arr[0], arr[1]));
        }
    }
}
