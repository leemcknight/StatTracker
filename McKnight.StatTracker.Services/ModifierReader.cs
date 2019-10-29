using McKnight.StatTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Services
{
    public class ModifierReader : CsvReader<PlayModifier>
    {
        public ModifierReader()
        {
            Path = "Data/lookups/modifiers.csv";
            TransformFunc = (arr => new PlayModifier { ModifierId = arr[0], ModifierText = arr[1] });
        }
    }
}
