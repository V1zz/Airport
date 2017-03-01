using PlaneLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PlaneLib
{
    public class Airport<T> : IEnumerable<T> where T : Plane, new()
    {
        private T[] _planes;
        private static readonly T[] _emptyMas = new T[0];
        private int _size;

        private Service help = new Service();

        public Airport()
        {
            this._planes = _emptyMas;
        }

        private int Capacity
        {
            get { return _planes.Length; }
            set
            {
                if (value < _size)
                    throw new ArgumentOutOfRangeException();
                if (value != _planes.Length)
                {
                    if (value > 0)
                    {
                        var newItems = new T[value];
                        if (_size > 0)
                        {
                        Array.Copy(newItems, 0, _planes, 0, _size);
                        _planes = newItems;

                    }
                }
                    else
                        _planes = _emptyMas;
                }
            }
        }

        private void EnsureCapacity(int min)
        {
            if (_planes.Length >= min)
                return;
            var num = _planes.Length == 0 ? 4 : _planes.Length * 2;
            if ((uint)num > 2146435071)
                num = 2146435071;
            if (num < min)
                num = min;
            Capacity = num;
        }

        public void Add(T plane)
        {
            if (_size == _planes.Length)
                EnsureCapacity(++_size);
            _planes[++_size] = plane;
            Service.QSort(_planes, 0, _planes.Length - 1);
        }

        public int Count => _size;

        public void RemoveByIndex(int index)
        {
            if (index >= _size)
                throw new ArgumentOutOfRangeException();
            _size = _size - 1;
            if (index < _size)
                Array.Copy(_planes, index + 1, _planes, index, _size - index);
            _planes[_size] = default(T);
        }

        public bool RemoveByPlane(T plane)
        {
            var indx = Array.IndexOf(_planes, plane, 0, _planes.Length);
            if (indx < 0)
                return false;
            RemoveByIndex(indx);
            return true;
        }
        //todo!!! -> //DateTime
        public void Editor(int fnum)
        {
            var tmp = FindPlane(fnum);
            var t = -1;
            try
            {
                do
                {
                    switch (help.EditorPrinter())
                    {
                        case 0:
                            t = 0;
                            break;
                        case 1:                             //FNum
                            tmp = (T) help.EditFnumPlane(tmp);
                            break;
                        case 2:                             //City
                            tmp = (T) help.EditCityPlane(tmp);
                            break;
                        case 3:                             //Airline
                            tmp = (T) help.EditAirlinePlane(tmp);
                            break;
                        case 4:                             //Terminal & gate
                            tmp = (T) help.EditTermGate(tmp);
                            break;
                        case 5:                             //Date & time
                            Console.WriteLine("Expected code");
                            break;
                        default:
                            break;
                    }
                } while (t != 0);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private T FindPlane(int fnum)
        {
            return _planes.FirstOrDefault(t => t.FNum == fnum);
        }

        private T FindPlane(int fnum, out int indx)
        {
            for (var i = 0; i < _planes.Length; i++)
            {
                if (_planes.Any(t => _planes[i].FNum != fnum)) continue;
                indx = i;
                return _planes[i];
            }
            indx = -1;
            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_planes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_planes).GetEnumerator();
        }

        protected internal T this[int index]
        {
            get
            {
                if (index >= this._size)
                    throw new ArgumentOutOfRangeException();
                return this._planes[index];
            }
            set
            {
                if (index >= this._size)
                    throw new ArgumentOutOfRangeException();
                this._planes[index] = value;
            }
        }
    }

}
