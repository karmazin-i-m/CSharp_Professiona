using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using ITVDN_Task_2;

namespace ITVDN_AdditionTask_1
{
    class Reflector
    {
        private readonly Assembly assembly;
        private List<Type> types;
        private List<MethodInfo> methods;
        private List<FieldInfo> fields;
        private List<EventInfo> events;


        public Reflector(String path)
        {
            this.assembly = Assembly.Load(path);
            this.GetTypes();
        }
        public Reflector(Assembly assembly)
        {
            this.assembly = assembly;
            this.GetTypes();
        }

        public IEnumerable<String> Types
        {
            get
            {
                foreach (var item in this.types)
                    yield return item.Name;
                yield break;
            }
        }
        public IEnumerable<String> Methods
        {
            get
            {
                foreach (var item in this.methods)
                    yield return item.Name;
                yield break;
            }
        }
        public IEnumerable<String> Fields
        {
            get
            {
                foreach (var item in this.fields)
                    yield return item.Name;
                yield break;
            }
        }
        public IEnumerable<String> Events
        {
            get
            {
                foreach (var item in this.events)
                    yield return item.Name;
                yield break;
            }
        }

        public void TypeInfo(String str)
        {
            foreach (var item in Types)
                if (item.Equals(str))
                {
                    Type type = types.Find((Type t) => { if (t.Name == str) return true; return false; });
                    GetFields(type);
                    GetMethods(type);
                    GetEvent(type);
                }
        }

        private void GetTypes()
        {
            this.types = new List<Type>();
            foreach (Type item in this.assembly.GetTypes())
                this.types.Add(item);
        }

        private void GetMethods(Type type)
        {
            this.methods = new List<MethodInfo>();
            foreach (MethodInfo item in type.GetMethods())
                this.methods.Add(item);
        }

        private void GetFields(Type type)
        {
            this.fields = new List<FieldInfo>();
            foreach (FieldInfo item in type.GetFields())
                this.fields.Add(item);
        }

        private void GetEvent(Type type)
        {
            this.events = new List<EventInfo>();
            foreach (EventInfo item in type.GetEvents())
                this.events.Add(item);
        }
    }
}
