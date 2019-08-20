namespace ITVDN_Task_2
{
    class Month
    {
        Months number;
        string name;
        int days;

        public Month(Months number)
            :this(number,false) 
        {

        }

        public Month(Months number, bool IsLeap)
        {
            this.number = number;
            this.name = ((Months)number).ToString();

            switch (number)
            {
                case Months.January:
                    this.days = 31;
                    break;
                case Months.February:
                    this.days = IsLeap ? 29 : 28;
                    break;
                case Months.March:
                    this.days = 31;
                    break;
                case Months.April:
                    this.days = 30;
                    break;
                case Months.May:
                    this.days = 31;
                    break;
                case Months.June:
                    this.days = 30;
                    break;
                case Months.July:
                    this.days = 31;
                    break;
                case Months.August:
                    this.days = 31;
                    break;
                case Months.September:
                    this.days = 30;
                    break;
                case Months.October:
                    this.days = 31;
                    break;
                case Months.November:
                    this.days = 30;
                    break;
                case Months.December:
                    this.days = 31;
                    break;
            }

        }

        public int Days => days;
        public string Name => name;
        internal Months Number => number;
    }
}
