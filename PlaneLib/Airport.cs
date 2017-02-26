using System;
using System.Linq;

namespace PlaneLib
{
    public class Airport<T> where T : Plane, new()
    {
        T[] planes;
        Service help = new Service();


        public Airport()
        {
            planes = new T[0];
        }


        public void Add(T plane)
        {
            Array.Resize(ref planes, planes.Length + 1);
            planes[planes.Length - 1] = plane;
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

        //todo!!!
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

        public T FindPlane(int fnum)
        {
            return planes.FirstOrDefault(t => t.FNum == fnum);
        }
        public T FindPlane(int fnum, out int indx)
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

    }
}
