using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneLib
{
    class AirpEnum<T> : IEnumerator<T> where T : Plane, new()
    {
        private T[] _planes;

        private int pos = -1;

        public AirpEnum(T[] planes)
        {
            _planes = planes;
        }  

        public T Current => _planes[pos];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
            pos++;
            return (pos < _planes.Count());
        }

        public void Reset()
        {
            pos = -1;
        }
    }
}
