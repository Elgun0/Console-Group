using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_lesson
{
    class Teacher
    {
        public int Id { get; private set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public static int TeachId = 1;
        public Teacher(string Fullname, string Email, string Phone)
        {
            this.Id = TeachId;
            this.Fullname = Fullname;
            this.Email = Email;
            this.Phone = Phone;
            TeachId++;
        }
        public static void AddTeacher()
        {
        FullInfot:
            Console.ResetColor();
            Console.WriteLine("Please enter fullname: ");
            string flnamet = Console.ReadLine();

            Console.WriteLine("Please enter email: ");
            string emailt = Console.ReadLine();

            TchPhone:

            Console.WriteLine("Please enter phone number: ");
            string phonet = Console.ReadLine();

            if(flnamet !="" && emailt !="" && phonet !="")
            {
                if(long.TryParse(phonet, out long phInt) && phonet.Length == 10)
                {
                    Teacher tch = new Teacher(flnamet, emailt, phonet);
                    MyList.Teacher.Add(tch);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nSuccess, {tch.Fullname} created successfully \n");
                    Console.WriteLine($"Name: {tch.Fullname}");
                    Console.WriteLine($"Email: {tch.Email}");
                    Console.WriteLine($"Phone Number: {tch.Phone}\n");
                }
                else if (phonet.Length != 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nthe number of digits must be 10\n");
                    goto TchPhone;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Warning, Phone should be numeric number\n");
                    goto TchPhone;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fill all cells \n");
                goto FullInfot;
            }
        }

        public static void ShowTeacher()
        {
            Console.ResetColor();
            if (MyList.Teacher.Count > 0)
            {
                foreach (var tch in MyList.Teacher)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nTeacher ID: {tch.Id} Teacher name: {tch.Fullname}\n");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nMuellim yoxdur");
                AddTeacher();
            }

        }
    }
}
