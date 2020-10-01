using System;
using System.Collections;

namespace day_12
{
    abstract class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Course { get; set; }

        public Person()
        {
            Console.WriteLine("Фамилия студента");
            LastName = Check.CheckString();
            Console.WriteLine("Имя студента :");
            Name = Check.CheckString();
            Console.WriteLine("Курс :");
            Course = Check.CheckInt();
        }
        public abstract void InputData();
    }


    class Student : Person
    {

        public Student() : base()
        {
        }
        public override void InputData()
        {
            Console.WriteLine( $"Студент {LastName} {Name} учиться в {Course}ом курсе." );
        }
    }
    class Aspirant : Person
    {
        public int Diss { get; set; }
        public Aspirant()
            : base()
        {
            Console.WriteLine("Номер диссертации :");
            this.Diss = Check.CheckInt();
        }
        public override void InputData()
        {
            Console.WriteLine($"Аспирант {LastName} {Name} учиться в {Course}ом курсе. Номер диссертации : {Diss}");
        }
    }

    class Check
    {
        public static string CheckString()
        {
            bool IsIt = false;
            string name;
            do
            {
                name = Console.ReadLine();
                int count = 0;

                for (int i = 0; i < name.Length; i++)
                {

                    for (int j = 0; j <= 9; j++)
                    {
                        if (name[i] == j.ToString()[0])
                        {
                            IsIt = false;
                            count++;
                            break;
                        }
                        if (name[i] == ' ')
                        {
                            IsIt = false;
                            count++;
                            break;
                        }
                        if (count == 0)
                            IsIt = true;
                    }
                }

                if (IsIt == false)
                    Console.WriteLine("Wrong input. Enter again : ");
            } while (IsIt == false);
            return name;

        }
        public static int CheckInt()
        {
            bool IsIt = false;
            int num;
            do
            {
                string input = Console.ReadLine();

                bool result = int.TryParse(input, out num);
                if (result == false)
                    Console.WriteLine("Wrong input. Enter again : ");
                else
                    break;
            } while (IsIt == false);
            return num;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Регистрация студентов :" +
                            "\n2.Информация о студентах :" +
                            "\n3.Удаление из списка студентов :" +
                            "\n4.Выход :");

            ArrayList students = new ArrayList();
            ArrayList g_students = new ArrayList();
            
            bool b = false;
            do
            {
                bool b1 = false;

                Console.WriteLine("Выберите номер меню :");
                int menu = Check.CheckInt();
                switch (menu)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("Кого хотите зарегистрировать:" +
                                            "\n1.Студент " +
                                            "\n2.Аспирант ");

                            int m = Check.CheckInt();
                            if (m == 1)
                            {
                                Student st = new Student();
                                students.AddRange(new string[] { $"Студент {st.LastName} {st.Name} учиться в {st.Course}ом курсе." } );
                                b1 = true;
                                break;
                            }

                            if (m == 2)
                            {
                                Aspirant asp = new Aspirant();
                                g_students.AddRange(new string[] { $"Аспирант {asp.LastName} {asp.Name} учиться в {asp.Course}ом курсе. Номер диссертации : {asp.Diss}" });

                                b1 = true;
                                break;
                            }

                        } while (b1 == false);
                        break;
                    case 2:
                        foreach (object stud in students)
                        {
                            Console.WriteLine(stud);
                        }
                        foreach (object aspi in g_students)
                        {
                            Console.WriteLine(aspi);
                        }
                        break;
                    case 3:
                        int n = Check.CheckInt();
                        if (n <= students.Count) { students.RemoveAt(n - 1); }
                        else if (n <= 0) { Console.WriteLine("Nepravilniy vvod"); }
                        else { Console.WriteLine("Нет столько студентов."); }
                        break;
                    case 4:
                        Console.WriteLine("Программа завершена.");
                        b = true;
                        break;
                   
                        }
                        break;
            } while (b == false);
        }
    }
}

