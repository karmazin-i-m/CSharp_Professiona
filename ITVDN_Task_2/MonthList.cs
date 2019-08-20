using System;
using System.Collections;
using System.Linq;

namespace ITVDN_Task_2
{
    class MonthList : IEnumerator, IEnumerable
    {
        Month current;
        int position = -1;

        Month[] months = new Month[12]
        {
            new Month((Months)1),
            new Month((Months)2),
            new Month((Months)3),
            new Month((Months)4),
            new Month((Months)5),
            new Month((Months)6),
            new Month((Months)7),
            new Month((Months)8),
            new Month((Months)9),
            new Month((Months)10),
            new Month((Months)11),
            new Month((Months)12)
        };

        public Month this[int index]
        {
            get
            {
                if (index <= 0 && index >= 12)
                    throw new IndexOutOfRangeException("Недопустимое начение для индекса масива.");

                return months[index];
            }
        }

        public IEnumerable GetMonthsOnDays(int days)
        {
            return months.Where<Month>(T => T.Days == days).Select(T => T);
        }

        public object Current => current;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            position++;
            if (position < months.Length)
            {
                current = months[position];
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {

            position = -1;
        }
    }
}

