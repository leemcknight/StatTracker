using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    public class PlayModifier
    {
        public string ModifierId { get; set; }
        public string ModifierText { get; set; }

        public string ModifierString { get; set; }

        public FieldLocation FieldLocation { get; set; }

        public PlayModifier WithLocation(FieldLocation fieldLocation)
        {
            return new PlayModifier
            {
                FieldLocation = fieldLocation,
                ModifierId = this.ModifierId,
                ModifierText = this.ModifierText
            };
        }
    }
}
