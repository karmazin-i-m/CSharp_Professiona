using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVDN_Task_3
{
    public class Retiree : Citizen
    {
        private int queueNumber;

        public Retiree(string name, int age) : base(name, age, "retiree")
        {
        }

        public int QueueNumber { get => queueNumber; set => queueNumber = value; }

        public override string ToString()
        {
            return $"QueueNumber: {this.QueueNumber}, Name: {this.Name}, Age: {this.Age}, Class: {this.Class}";
        }
    }
}