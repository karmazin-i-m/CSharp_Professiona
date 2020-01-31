using System;

namespace ITVDN_AdditionTask_1
{
    class Employe
    {
        private readonly String  name;

        public  String Name => name;

        public Employe(String name)
        {
            this.name = name;
        }

        public virtual void Work()
        {
            Console.WriteLine($"{Name} работает как Employe");
        }
    }


}
