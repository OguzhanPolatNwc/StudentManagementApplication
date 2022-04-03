using System;
using System.Collections.Generic;

namespace OgrenciYonetimUygulamasi_G020
{
    class Program
    {
        static List<Student> Students = new List<Student>();
        static bool Continue = true;
        static void Main(string[] args)
        {
            //Test();
            Application();

        }

        static void Test()
        {
            Student ogr1 = new Student(12, "Aylin", "Ayça");
            //ogr1.Nr = 12;
            //ogr1.Name = "Aylin";
            //ogr1.Surname = "Ayça";

            ogr1.Class = "A";
            ogr1.MathGrade = 65;
            ogr1.PhysicGrade = 34;
            ogr1.HistoryGrade = 74;
            ogr1.SocialGrade = 32;

            float ava1 = ogr1.AverageFetch("verbal");
            Console.WriteLine(ava1);

            Student ogr2 = new Student();
            ogr2.Nr = 80;
            ogr2.Class = "A";
            ogr2.Name = "Berna";
            ogr2.Surname = "Beril";
            ogr2.MathGrade = 35;
            ogr2.PhysicGrade = 54;
            ogr2.HistoryGrade = 67;
            ogr2.SocialGrade = 89;

            ogr2.PrintAvarage();



        }

        static void Application()
        {
            EnterFakeData();
            Menu();
            while (Continue)
            {
                Console.WriteLine();

                string input = MakeAChoice();
                Console.WriteLine();
                switch (input)
                {
                    case "1":
                    case "E":
                        AddStudent();
                        break;
                    case "2":
                    case "S":
                        DeleteStudent();
                        break;
                    case "3":
                    case "L":
                        ListStudent();
                        break;
                    case "4":
                    case "X":
                        Continue = false;
                        //Environment.Exit(0);
                        break;
                        //return;
                }
            }
        }

        //  <---What we want to do --->
        //Make a method named GetChoose().
        //This method will allow to receive user input on the "Your selection:" line.
        // If the user has not entered one of the desired characters in the menu
        //bottom line "Incorrect entry." give the message
        // and ask for the "Your Choice:" entry again on a lower line.

        //If the above operation repeats 10 times,
        // that is, if the user logs in incorrectly in all 10 attempts,
        //“Sorry I can't understand you. The program is being terminated.”
        // terminate the program by giving the message.

        static string MakeAChoice()
        {
            int counter = 0;
            while (true)
            {
                counter++;
                Console.Write("Your Choice: ");
                string input = Console.ReadLine().ToUpper();

                string characters = "1234ESLX";

                if (characters.IndexOf(input) == -1 || input.Length != 1)
                {
                    if (counter < 10)
                    {
                        Console.WriteLine("Incorrect entry made.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry I can't understand you. The program is being terminated.");
                        Environment.Exit(0);
                        //Continue = false;
                        //return "";
                    }
                }
                else
                {
                    return input;
                }
            }
        }



        static void Menu()
        {
            Console.WriteLine("Student Management Application");
            Console.WriteLine("1 - Add Student(E)            ");
            Console.WriteLine("2 - Delete Student(S)         ");
            Console.WriteLine("3 - List Student(L)           ");
            Console.WriteLine("4 - Output(X)                 ");
        }


        static void AddStudent()
        {
            Student o = new Student();
            Console.WriteLine("1- Add Student------");

            //How many students are added to the list in this addition?
            // of the "Student" line written before the "No" entry
            // write the serial number at the beginning.
            int row = Students.Count + 1;
            Console.WriteLine(row + ". Student");

            int nr;

            do
            {
                Console.Write("Nr:");
                nr = int.Parse(Console.ReadLine());
                if (IsNrExists(nr) == true)
                {
                    Console.WriteLine("There is such a student, try again.");
                    continue;
                }
                break;

            } while (true);


            o.Nr = nr;
            Console.WriteLine("Name: ");
            o.Name = CapFirstLetter(Console.ReadLine());
            Console.Write("Surname: ");
            o.Surname = CapFirstLetter(Console.ReadLine());
            Console.Write("Class: ");
            o.Class = CapFirstLetter(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Are you sure you want to enroll the student? (Y/N)");
            string input = Console.ReadLine();

            if (input.ToLower() == "Y")
            {
                Students.Add(o);
                Console.WriteLine("Student added.");
            }
            else
            {
                Console.WriteLine("Nr student has been added.");
            }

        }

        //If the number entered for the new student already exists, let the Nr: entry be made again.

        static bool IsNrExists(int nr)
        {
            foreach (Student item in Students)
            {
                if (item.Nr == nr)
                {
                    return true;
                }
            }
            return false;
        }
        
        // All names and surnames for newly added students,
        //add to the list with the first letter capitalized and the other letters lowercase.
        
        static string CapFirstLetter(string data)
        {
            return data.Substring(0, 1).ToUpper() + data.Substring(1).ToLower();
        }
        
        static void EnterFakeData()
        {
            Student ogr1 = new Student();
            ogr1.Name = "Aylin";
            ogr1.Surname = "Ayça";
            ogr1.Nr = 12;
            ogr1.Class = "A";
            Student ogr2 = new Student();
            ogr2.Nr = 80;
            ogr2.Class = "A";
            ogr2.Name = "Berna";
            ogr2.Surname = "Beril";
            Student ogr3 = new Student();
            ogr3.Class = "C";
            ogr3.Name = "Cemil";
            ogr3.Surname = "Ceren";
            ogr3.Nr = 52;


            Students.Add(ogr1);
            Students.Add(ogr2);
            Students.Add(ogr3);
        }


        static void ListStudent()
        {
            // If there is no data to display in the list, without printing the header lines,
            //“There are no students to display.” print it.


            Console.WriteLine("3- List student------");

            if (Students.Count == 0)
            {
                Console.WriteLine("There are no students to display.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Class".PadRight(8) + "Nr".PadRight(8) + "Name Surname");
            Console.WriteLine("----------------------------");

            // Using the PadLeft(), PadRihgt() methods while printing the data inside the foreach
            // ensure that the data is written aligned.

            foreach (Student item in Students)
            {
                Console.WriteLine(item.Class.PadRight(8, ' ') + item.Nr.ToString().PadRight(8, ' ') + item.Name + " " + item.Surname);
            }


        }
        // Edit the Delete Student() method.
        //If there are no students in the list, "The student you want to delete"
        // without printing the line,
        //“There are no students in the list to delete.” give your message.

        static void DeleteStudent()
        {
            Console.WriteLine("2- Delete Student-------");

            if (Students.Count == 0)
            {
                Console.WriteLine("There are no students in the list to delete");
                return;
            }

            Console.WriteLine("The student you want to delete ?");
            Console.Write("Nr: ");
            int nr = int.Parse(Console.ReadLine());

            Student ogr = null;

            foreach (Student item in Students)
            {
                if (item.Nr == nr)
                {
                    ogr = item;
                    break;
                }
            }

            if (ogr != null)
            {
                Console.WriteLine("Name: " + ogr.Name);
                Console.WriteLine("Surname: " + ogr.Surname);
                Console.WriteLine("Class: " + ogr.Class);


                Console.Write("Are you sure you want to delete the student? (Y/N)");
                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "y":
                        Students.Remove(ogr);
                        Console.WriteLine("Student deleted.");
                        break;
                    default:
                        Console.WriteLine("The student is not deleted.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("There is no such student on the list.");
            }

        }


    }
}
