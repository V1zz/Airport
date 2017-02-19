﻿using System;
using System.Linq;

namespace PlaneLib
{
    public class Airport<T> where T : Plane
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

            int tmp;
            FindPlane(fnum, out tmp);
            planes[tmp] = planes[planes.Length - 1];
            Array.Resize(ref planes, planes.Length - 1);
        }

        //todo!!!

        public void Editor(int fnum)
        {
            T tmp = FindPlane()
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
