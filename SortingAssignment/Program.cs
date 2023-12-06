using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoringAssessment
{
    class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }

        public override string ToString()
        {
            return $"{ID},{Name},{Class},{Section}";
        }
    }

    class Program
    {
        static List<Teacher> teachers = new List<Teacher>();
        static string filePath = "\"C:\\Users\\Boyapati Sahaja\\OneDrive\\Desktop\\Phase1\\Teachers.txt\"";

        static void Main(string[] args)
        {
            LoadData();

            while (true)
            {
                Console.WriteLine("1. Add Teacher\n2. Update Teacher\n3. Display All Teachers\n4. Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTeacher();
                        break;

                    case 2:
                        UpdateTeacher();
                        break;

                    case 3:
                        DisplayTeachers();
                        break;

                    case 4:
                        SaveData();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void AddTeacher()
        {
            Teacher newTeacher = new Teacher();

            Console.Write("Enter ID: ");
            newTeacher.ID = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            newTeacher.Name = Console.ReadLine();

            Console.Write("Enter Class: ");
            newTeacher.Class = Console.ReadLine();

            Console.Write("Enter Section: ");
            newTeacher.Section = Console.ReadLine();

            teachers.Add(newTeacher);
            Console.WriteLine("Teacher added successfully.");
        }

        static void UpdateTeacher()
        {
            Console.Write("Enter Teacher ID to update: ");
            int idToUpdate = int.Parse(Console.ReadLine());

            Teacher teacherToUpdate = teachers.Find(t => t.ID == idToUpdate);

            if (teacherToUpdate != null)
            {
                Console.Write("Enter updated Name: ");
                teacherToUpdate.Name = Console.ReadLine();

                Console.Write("Enter updated Class: ");
                teacherToUpdate.Class = Console.ReadLine();

                Console.Write("Enter updated Section: ");
                teacherToUpdate.Section = Console.ReadLine();

                Console.WriteLine("Teacher updated successfully.");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }

        static void DisplayTeachers()
        {
            Console.WriteLine("Teacher Data:");

            foreach (var teacher in teachers)
            {
                Console.WriteLine($"{teacher.ID} - {teacher.Name}, {teacher.Class}, {teacher.Section}");
            }
        }

        static void LoadData()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    string[] values = line.Split(',');
                    Teacher teacher = new Teacher
                    {
                        ID = int.Parse(values[0]),
                        Name = values[1],
                        Class = values[2],
                        Section = values[3]
                    };

                    teachers.Add(teacher);
                }
            }
        }

        static void SaveData()
        {
            List<string> lines = new List<string>();

            foreach (var teacher in teachers)
            {
                lines.Add(teacher.ToString());
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}