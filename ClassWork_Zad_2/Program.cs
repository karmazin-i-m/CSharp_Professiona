using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_Zad_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Вася");
            SchoolСhild сhild = new SchoolСhild("Петя");
            ExtramuralStudent extramuralStudent = new ExtramuralStudent("Толя");

            student.ToStudy();
            сhild.ToStudy();
            extramuralStudent.ToStudy();

            Console.ReadKey();
        }
    }

    class Persone
    {
        private string name;

        public Persone(string name)
        {
            this.name = name;
        }

        public string Name => name;
    }

    interface IStudy
    {
        void ToStudy();
    }

    class Student : Persone, IStudy
    {
        public Student(string name) : base(name)
        {
        }

        public void ToStudy()
        {
            for (int i = 0; i < 5; i++)
            {
                GoToUniversity();
                Study();
                GoToHome();
            }
            Console.WriteLine(new string('-', 80));
        }

        protected virtual void GoToUniversity()
        {
            Console.WriteLine("Приехал в универ.");
        }

        protected virtual void GoToHome()
        {
            Console.WriteLine("Поехал домой.");
        }

        protected virtual void Study()
        {
            Console.WriteLine("Отсидел 3 пары.");
        }
    }

    class SchoolСhild : Persone, IStudy
    {
        public SchoolСhild(string name) : base(name)
        {
        }

        public void ToStudy()
        {
            for (int i = 0; i < 5; i++)
            {
                GoToUniversity();
                Study();
                GoToHome();
            }
            Console.WriteLine(new string('-', 80));
        }

        protected virtual void GoToUniversity()
        {
            Console.WriteLine("Приехал в школу.");
        }

        protected virtual void GoToHome()
        {
            Console.WriteLine("Поехал домой.");
        }

        protected virtual void Study()
        {
            Console.WriteLine("Поситил 6 уроков.");
        }
    }

    class ExtramuralStudent : Student, IStudy
    {
        public ExtramuralStudent(string name) : base(name)
        {
        }
        public new void ToStudy()
        {
            GoToUniversity();
            Study();
            GoToHome();
            Console.WriteLine(new string('-', 80));
        }

        protected override void GoToUniversity()
        {
            Console.WriteLine("Приехал в универ.");
        }

        protected override void GoToHome()
        {
            Console.WriteLine("Поехал домой.");
        }

        protected override void Study()
        {
            Console.WriteLine("Отсидел 5 пар.");
        }
    }
}
