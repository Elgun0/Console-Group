using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInp;
            do
            {
                Console.ResetColor();
                Console.WriteLine("Aşağıdakılardan birini seçin");
                Console.WriteLine("1.Qrup yaradın");
                Console.WriteLine("2.Telebe yaradın");
                Console.WriteLine("3.Müellim yaradın");
                Console.WriteLine("4.Qrup seçin ve telebe daxil edin");
                Console.WriteLine("5.Qrupdaki telebeler");
                Console.WriteLine("6.Qrup seçin ve muellim daxil edin");
                Console.WriteLine("7.Qrupdaki muellimler");
                Console.WriteLine("8.Exit");
                string userInput = Console.ReadLine();
                if(int.TryParse(userInput, out userInp))
                {
                    switch (userInp)
                    {
                        case 1:
                            Console.Clear();
                            Group.AddGruop();
                            break;
                        case 2:
                            Console.Clear();
                            Student.AddStudent();
                            break;
                        case 3:
                            Console.Clear();
                            Teacher.AddTeacher();
                            break;
                        case 4:
                            Console.Clear();
                            Group.ShowGroupandAdd();
                            break;
                        case 5:
                            Group.ShowGroups();
                            break;
                        case 6:
                            Group.ShowGroupandAddTeacher();
                            break;
                        case 7:
                            Group.ShowGropsTch();
                            break;
                        case 8:
                            break;
                        default:
                            Console.WriteLine("Please enter only above number");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**************");
                    Console.WriteLine("Please enter only numeric number! \n");
                    Console.WriteLine("**************");
                }

            } while (userInp!=8);

        }
    }
}
