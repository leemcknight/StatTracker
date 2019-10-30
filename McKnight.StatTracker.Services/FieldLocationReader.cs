using McKnight.StatTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Services
{
    public class FieldLocationReader : CsvReader<FieldLocation>
    {
        public FieldLocationReader()
        {
            Path = "Data/lookups/field_locations.csv";
            TransformFunc = (arr => new FieldLocation { LocationCode = arr[0], LocationText = arr[1] });
        }
    }
}
