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
        private T[] planes; 

        private Service help = new Service();

        public Airport()
        {
            planes = new T[planes.Length];
        }
        
        public void Add(T plane)
        {
            Array.Resize(ref planes, planes.Length + 1);
            planes[planes.Length - 1] = plane;

            Service.QSort<T>(Service.ConvertTo<T>(planes), 0, planes.Length);
        }

        public void Remove(int fnum)
        {
            if (planes.Length == 0 )
                throw new Exception("Airport is EMPTY");
            try
            {
                if (planes.Length == 0)
                    throw new Exception();
                    int tmp;
                FindPlane(fnum, out tmp);
                planes[tmp] = planes[planes.Length - 1];
                Array.Resize(ref planes, planes.Length - 1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
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
            return planes.FirstOrDefault(t => t.FNum == fnum);
        }

        private T FindPlane(int fnum, out int indx)
        {
            for (int i = 0; i < planes.Length; i++)
            {
                if (planes.All(t => planes[i].FNum == fnum))
                {
                    indx = i;
                    return planes[i];
                }
            }
            indx = -1;
            return null;
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new AirpEnum<T>(planes);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }

        protected internal T this[int index]
        {
            get { return planes[index]; }
            set { planes[index] = value; }
        }

        
    }
}
