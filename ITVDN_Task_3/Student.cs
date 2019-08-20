using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVDN_Task_3
{
    public class Student : Citizen
    {
        public Student(string name, int age) : base(name, age, "student")
        {
        }
    }
}