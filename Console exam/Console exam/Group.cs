using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console_lesson
{
    class Group
    {
        public string GroupName { get; set; }
        public List<Student> Students;
        public List<Teacher> Teachers;

        public Group(string GroupName)
        {
            this.GroupName = GroupName;
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }
        public static void AddGruop()
        {
        startgroupname:
            Console.ResetColor();
            Console.Write("Please write group name: ");
            string grpname = Console.ReadLine();
            if(grpname != "")
            {
                Group gr = new Group(grpname);
                MyList.Groups.Add(gr);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nGroup {gr.GroupName} create successfully\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPlease enter group name\n");
                goto startgroupname;
            }
        }

        public static void ShowGroupandAdd()
        {
            Console.ResetColor();
            if(MyList.Groups.Count > 0)
            {
                foreach (var group in MyList.Groups)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Group Name: {group.GroupName}\n");
                }
                groupadd:
                Group SelectedGroup = null;
                Console.WriteLine("Please select Group name for List: ");
                string grpname = Console.ReadLine();
                bool isCorrectGroupName = false;
                foreach (var group in MyList.Groups)
                {
                    if(group.GroupName == grpname)
                    {
                        SelectedGroup = group;
                        isCorrectGroupName = true;
                        break;
                    }
                }
                if (isCorrectGroupName)
                {
                    Student SelectedStudent = null;
                    Student.ShowStudent();
                    WriteStuId:
                    Console.Write("Please select student Id: \n");
                    string stuId = Console.ReadLine();
                    bool correctStuId = false;
                    if(int.TryParse(stuId, out int stuIdInt))
                    {
                        foreach (var student in MyList.Student)
                        {
                            if (student.Id == stuIdInt)
                            {
                                correctStuId = true;
                                SelectedStudent = student;
                                break;
                            }
                        }
                        if (correctStuId)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            SelectedGroup.Students.Add(SelectedStudent);
                            Console.WriteLine($"Group: {SelectedGroup.GroupName}\nStudent: {SelectedStudent.Fullname}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nStudent Id doesn't correct\n");
                            goto WriteStuId;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPlease write numeric number\n");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThere is not a group\n");
                    goto groupadd;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThere is not a group\n");
                AddGruop();
            }

        }

        public static void ShowGropsTch()
        {
                Console.ResetColor();
                Group SelectedGroup = null;
                bool isCorrectGroupName = false;
                groupadd:
                Console.Write("Please write group name\n");
                string grpname = Console.ReadLine();
                foreach (var group in MyList.Groups)
                {
                    if (group.GroupName == grpname)
                    {
                        SelectedGroup = group;
                        isCorrectGroupName = true;
                        break;
                    }
                }
                if (isCorrectGroupName)
                {
                    if (SelectedGroup.Teachers.Count > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nGroup: {SelectedGroup.GroupName}\n");
                        foreach (var teacher in SelectedGroup.Teachers)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"Teacher: {teacher.Fullname}\n");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nTeacher was not found\n");
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nGroup name doesn't correct\n");
                    goto groupadd;
                }
            }


        public static void ShowGroupandAddTeacher()
        {
            Console.ResetColor();
            if (MyList.Groups.Count > 0)
            {
                foreach (var group in MyList.Groups)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Group Name: {group.GroupName}\n");
                }
                groupadd:
                Group SelectedGroup = null;
                Console.WriteLine("Please select Group name for List: ");
                string grpname = Console.ReadLine();
                bool isCorrectGroupName = false;
                foreach (var group in MyList.Groups)
                {
                    if (group.GroupName == grpname)
                    {
                        SelectedGroup = group;
                        isCorrectGroupName = true;
                        break;
                    }
                }
                if (isCorrectGroupName)
                {
                    Teacher SelectedTeacher = null;
                    Teacher.ShowTeacher();
                    WriteTchId:
                    Console.Write("Please select teacher Id: \n");
                    string tchId = Console.ReadLine();
                    bool correctTchId = false;
                    if (int.TryParse(tchId, out int tchIdInt))
                    {
                        foreach (var teacher in MyList.Teacher)
                        {
                            if (teacher.Id == tchIdInt)
                            {
                                correctTchId = true;
                                SelectedTeacher = teacher;
                                break;
                            }
                        }
                        if (correctTchId)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            SelectedGroup.Teachers.Add(SelectedTeacher);
                            Console.WriteLine($"Group: {SelectedGroup.GroupName}\n: {SelectedTeacher.Fullname}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nTeacher Id doesn't correct\n");
                            goto WriteTchId;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPlease write numeric number\n");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThere is not a group\n");
                    goto groupadd;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThere is not a group\n");
                AddGruop();
            }
        }

        public static void ShowGroups()
        {
            Console.ResetColor();
            Group SelectedGroup = null;
            bool isCorrectGroupName = false;
            groupadd:
            Console.Write("Please write group name\n");
            string grpname = Console.ReadLine();
            foreach (var group in MyList.Groups)
            {
                if(group.GroupName == grpname)
                {
                    SelectedGroup = group;
                    isCorrectGroupName = true;
                    break;
                }
            }
            if (isCorrectGroupName)
            {
                if (SelectedGroup.Students.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nGroup: {SelectedGroup.GroupName}\n");
                    foreach (var student in SelectedGroup.Students)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Student: {student.Fullname}\n");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nStudent was not found\n");
                }
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nGroup name doesn't correct\n");
                goto groupadd;
            }
        }
    }
}
