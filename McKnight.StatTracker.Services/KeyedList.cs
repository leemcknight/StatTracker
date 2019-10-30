using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Services
{
    public class KeyedList<T> : IEnumerable<T>
    {
        private IDictionary<string, T> backingDictionary;

        public KeyedList(IDictionary<string, T> dictionary) 
        {
            this.backingDictionary = dictionary;
        }


        public T this[string key]
        {
            get { return backingDictionary[key]; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return backingDictionary.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return backingDictionary.Values.GetEnumerator();
        }
    }
}
