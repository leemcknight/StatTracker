using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace McKnight.StatTracker.Services
{
    public abstract class CsvReader<T>
    {                

        public string Path { get; protected set; }
        public Func<string[], T> TransformFunc { get; protected set; }
        
        
        public virtual IEnumerable<T> Read()
        {            
            return File.ReadLines(Path)                
                .Select(line => line.Split(','))                
                .Select(arr => TransformFunc(arr));
        }

        protected DateTime? GetSafeDate(string dateString)
        {
            DateTime date;
            bool ok = DateTime.TryParseExact(dateString, "yyyyMMdd", CultureInfo.CurrentCulture, DateTimeStyles.None, out date);
            return ok ? (DateTime?)date : null;                        
        }

        protected int? GetSafeInt(string intString)
        {
            if(intString == null || intString.Trim().Length == 0)
            {
                return null;
            }
            return int.Parse(intString);
        }

        protected string UnQuote(string quotedString)
        {
            return quotedString.Replace('"', ' ').Trim();            
        }
    }
}
