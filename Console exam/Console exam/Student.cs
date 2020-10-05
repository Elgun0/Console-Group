using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console_lesson
{
    class Student
    {
        public int Id { get; private set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public static int StuId = 1;
        public Student(string Fullname,string Email,string Phone)
        {
            this.Id = StuId;
            this.Fullname = Fullname;
            this.Email = Email;
            this.Phone = Phone;
            StuId++;
        }
        public static void AddStudent()
        {
            FullInfo:
            Console.ResetColor();
            Console.WriteLine("Please enter fullname: ");
            string flname = Console.ReadLine();

            Console.WriteLine("Please enter email: ");
            string email = Console.ReadLine();

            StuPhone:

            Console.WriteLine("Please enter phone number: ");
            string phone = Console.ReadLine();

            if(flname!="" && email!="" && phone != "")
            {
                if (long.TryParse(phone, out long phInt) && phone.Length==10)
                {
                    Student stu = new Student(flname, email, phone);
                    MyList.Student.Add(stu);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nSuccess, {stu.Fullname} created successfully \n");
                    Console.WriteLine($"Name: {stu.Fullname}");
                    Console.WriteLine($"Email: {stu.Email}");
                    Console.WriteLine($"Phone Number: {stu.Phone}\n");
                }
                else if (phone.Length != 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nthe number of digits must be 10\n");
                    goto StuPhone;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Warning, Phone should be numeric number\n");
                    goto StuPhone;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fill all cells \n");
                goto FullInfo;
            }

        }
        public static void ShowStudent()
        {
            Console.ResetColor();
            if(MyList.Student.Count > 0)
            {
                foreach (var stu in MyList.Student)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nStudents ID: {stu.Id} Students name: {stu.Fullname}\n");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nTelebe yoxdur");
                AddStudent();
            }
            
        }

    }
}
