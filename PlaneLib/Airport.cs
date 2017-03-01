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
            get
            {
                return this._planes.Length;
            }
            set
            {
                if (value < this._size)
                    throw new ArgumentOutOfRangeException();
                if (value == this._planes.Length)
                    return;
                if (value > 0)
                {
                    var objArray = new T[value];
                    if (this._size > 0)
                        Array.Copy(this._planes, 0, objArray, 0, this._size);
                    this._planes = objArray;
                }
                else
                    this._planes = _emptyMas;
            }
        }

        private void EnsureCapacity(int min)
        {
            if (this._planes.Length >= min)
                return;
            var num = this._planes.Length == 0 ? 4 : this._planes.Length * 2;
            if (num > 2146435071)
                num = 2146435071;
            if (num < min)
                num = min;
            this.Capacity = num;
        }

        public void Add(T plane)
        {
            #region old

            /*Array.Resize(ref _planes, _planes.Length + 1);
            _planes[_planes.Length - 1] = plane;*/

            #endregion

            if (this._size == this._planes.Length)
                this.EnsureCapacity(this._size + 1);
            var objArray = this._planes;
            var num = this._size;
            this._size = num + 1;
            var index = num;
            var obj = plane;
            objArray[index] = obj;
            Service.QSort(_planes, 0, _planes.Length); //Q-Sorting
        }
        
        public void RemoveByIndex(int index)
        {
            if (index >= this._size)
                throw new ArgumentOutOfRangeException();
            this._size = this._size - 1;
            if (index < this._size)
                Array.Copy(this._planes, index + 1, this._planes, index, this._size - index);
            this._planes[this._size] = default(T);
        }

        public bool RemoveByPlane(T plane)
        {
            var indx = Array.IndexOf<T>(_planes, plane, 0, _planes.Length);
            if (indx < 0)
                return false;
            this.RemoveByIndex(indx);
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

        public Airport<T>.Enumerator GetEnumerator()
        {
            
        }  

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new AirpEnum<T>(_planes);
        }

        IEnumerator IEnumerable.GetEnumerator() //
        {
            return (IEnumerator<T>) new Airport<T>.Enumerator(this);
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
