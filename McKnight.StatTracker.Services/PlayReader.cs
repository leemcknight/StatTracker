using McKnight.StatTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Services
{
    public class PlayReader : CsvReader<Play>
    {
        public Play Read(string[] array)
        {
            Play play = new Play();
            return play;
        }
    }
}
