using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITVDN_AdditionTask_1.Employes;
using ITVDN_AdditionTask_1.Atributes;
using System.Reflection;

namespace ITVDN_AdditionTask_1
{
    class Company
    {
        public void GetAccess(Employe employe)
        {
            object[] attributes  = employe.GetType().GetCustomAttributes(false);

            foreach(AccessLevelAttribute attribute in attributes)
            {
                if(attribute.LevelAccess)
                    Console.WriteLine("Доступ есть");
                else
                    Console.WriteLine("Доступа нет");
            }
        }
    }
}
