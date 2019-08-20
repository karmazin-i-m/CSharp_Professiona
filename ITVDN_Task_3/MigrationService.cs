using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVDN_Task_3
{
    public class MigrationService : IEnumerable<Citizen>, IEnumerator<Citizen>
    {
        private Citizen[] citizens = new Citizen[4];
        private int position = -1;
        private int count = 0;
        private Citizen current;
        private int retireeNumber = 0;

        public Citizen Current => current;
        public int Count => this.count;
        public int Capacity => citizens.Length;

        object IEnumerator.Current => Current;

        public void Add(Citizen citizen)
        {
            if (Contains(citizen))
            {
                Console.WriteLine("Такой человек уже есть в базе!");
                return;
            }

            if (count < Capacity)
            {

                if (citizen is Retiree)
                {
                    Retiree retiree = (Retiree)citizen;
                    retiree.QueueNumber = retireeNumber;
                    if (++count == Capacity) Array.Resize<Citizen>(ref citizens, Capacity * 2);
                    Array.Copy(citizens, retireeNumber, citizens, ++retireeNumber, count);
                    citizens[retiree.QueueNumber] = retiree;
                }
                else
                    citizens[count++] = citizen;
            }
            else
            {
                Array.Resize<Citizen>(ref citizens, Capacity * 2);
                Add(citizen);
            }
        }

        public bool Contains(Citizen citizen)
        {
            for (int i = 0; i < Count; i++)
            {
                if (citizens[i].Equals(citizen))
                {
                    return true;
                }
            }
            return false;
        }

        public Citizen ReturnLast(out int index)
        {
            index = Count - 1;
            return citizens[index];
        }

        public void Clear()
        {
            citizens = new Citizen[4];
            count = 0;
            retireeNumber = 0;
        }

        public bool Remove()
        {
            Array.Copy(citizens, 1, citizens, 0, --count);
            citizens[count + 1] = null;
            return true;
        }
        public bool Remove(Citizen citizen)
        {
            if (Contains(citizen))
            {
                for (int i = 0; i < Count; i++)
                {
                    if (citizens[i].Equals(citizen))
                    {
                        Array.Copy(citizens, i + 1, citizens, i, --count - i);
                        citizens[count + 1] = null;
                        return true;
                    }
                }
            }
            return false;
        }

        public void Dispose()
        {
            Reset();
        }

        public IEnumerator<Citizen> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            position++;
            if (position < Count)
            {
                current = citizens[position];
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}