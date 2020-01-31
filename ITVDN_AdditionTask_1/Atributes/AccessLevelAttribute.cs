using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_AdditionTask_1.Atributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class AccessLevelAttribute : Attribute
    {
        private readonly Boolean levelAccess;
        public AccessLevelAttribute(Boolean levelAccess)
        {
            this.levelAccess = levelAccess;
        }

        public Boolean LevelAccess => levelAccess;
    }
}
