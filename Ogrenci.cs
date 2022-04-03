using System;
using System.Collections.Generic;
using System.Text;

namespace OgrenciYonetimUygulamasi_G020
{
    class Student
    {
        public int Nr;
        public string Name;
        public string Surname;
        public string Class;

        public int MathGrade;
        public int PhysicGrade;
        public int SocialGrade;
        public int HistoryGrade;
        //classes have methods
        //We use these methods to change the properties of the class and to generate new data using these properties.       

        public Student()
        {

        }
        public Student(int nr, string name)
        {
            Nr = nr;
            Name = name;
        }
        public Student(int nr, string name, string surname)
        {
            Nr = nr;
            Name = name;
            Name = surname;
        }
        
        public float AverageFetch()
        {
            int sum = MathGrade + PhysicGrade + SocialGrade + HistoryGrade;
            return (float)sum / 4;

        }

        public float AverageFetch(string tip)
        {
            int sum = 0;
            float avarage = -1;
            if (tip == "verbal")
            {
                sum = SocialGrade + HistoryGrade;
                avarage = (float)sum / 2;
            }
            else if (tip == "numerical")
            {
                sum = MathGrade + PhysicGrade;
                avarage = (float)sum / 2;
            }

            return avarage;
        }

        public void PrintAvarage()
        {
            //int total = MathGrade + PhysicsGrade + SocialGrade + DateGrade;
            float avarage = AverageFetch(); //(float)sum / 4;
            Console.WriteLine(Nr + " numbered student's Average :" + avarage);
        }
    }
}
