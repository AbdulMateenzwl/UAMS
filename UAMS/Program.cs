using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <Programs> offered_degrees = new List<Programs>();
            List <Student> students = new List<Student>();



            while (true)
            {
                header();
                char option=menu();
                header();
                if(option=='1')
                {
                    add_student(students,offered_degrees);
                }
                else if(option=='2')
                {
                    add_degree(offered_degrees);
                }
                else if(option=='3')
                {
                    generate_merit(students);
                }
                else if(option =='4')
                {
                    display_registered(students);
                }
                else if(option=='5')
                {
                    specific_degree(students);
                }
                else if(option =='6')
                {
                    register_subjects(students);
                }
                else if(option=='7')
                {
                    fee_generation(students);
                    display(students);
                    Console.ReadKey();
                }
                Console.ReadKey();
            }
        }
        static void header()
        {
            Console.Clear();
            Console.WriteLine("*************************************");
            Console.WriteLine("                UAMS                 ");
            Console.WriteLine("*************************************");
            Console.WriteLine("");
        }
        static char menu()
        {
            Console.WriteLine("1)  Add Student ");
            Console.WriteLine("2)  Add Degree Program ");
            Console.WriteLine("3)  Generate Merit ");
            Console.WriteLine("4)  View Registered Students ");
            Console.WriteLine("5)  View Students of a specific Program ");
            Console.WriteLine("6)  Register Subject for a specific Student ");
            Console.WriteLine("7)  Calculate fee of All registered Students ");
            Console.WriteLine("8)  EXIT ");
            Console.Write("Enter Your Option ...");
            char op=Console.ReadLine()[0];
            return op;
        }
        static void display(List<Student> stu_list)
        {
            Console.WriteLine("Name\tFee");
            for (int i = 0; i < stu_list.Count; i++)
            {
                if (stu_list[i].program != null)
                {
                    Console.WriteLine(stu_list[i].name+"\t"+stu_list[i].fee);
                }
            }
        }
        static void add_student(List<Student> stu_list,List<Programs> offered_degrees)
        {
            Student input = new Student();
            Console.Write("Enter the name of student : ");
            input.name=Console.ReadLine();
            Console.Write("Enter Student age : ");
            input.age =int.Parse(Console.ReadLine());
            Console.Write("Enter Student fsc marks : ");
            input.fsc = float.Parse(Console.ReadLine());
            Console.Write("Enter Student Ecat marks : ");
            input.ecat = float.Parse(Console.ReadLine());
            Console.Write("Enter number of prefrences : ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num;)
            {
                Console.Write("Enter Prefrence : ");
                string str=Console.ReadLine();
                for (int w = 0; w < offered_degrees.Count; w++)
                {
                    if(offered_degrees[w].title == str)
                    {
                        input.preference.Add(offered_degrees[w]);
                        i++;
                    }
                }
            }
            input.merit=input.cal_merit();
            stu_list.Add(input);
        }
        static void add_degree(List<Programs> program_list)
        {
            Programs input = new Programs();
            Console.Write("Enter the title of degree : ");
            input.title  = Console.ReadLine();
            Console.Write("Enter Duration of the degree : ");
            input.duration=int.Parse(Console.ReadLine());
            Console.Write("Enter the closing merit : ");
            input.merit = int.Parse(Console.ReadLine());
            Console.Write("Enter number of subjects : ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Subjects input_subject = new Subjects();
                Console.Write("Enter the Subject Code : ");
                input_subject.code=Console.ReadLine();
                Console.Write("Enter Credit hours of the subject : ");
                input_subject.credit_hours= int.Parse(Console.ReadLine());
                Console.Write("Enter the type of subject : ");
                input_subject.type=Console.ReadLine();
                Console.Write("Enter fee of the subject : ");
                input_subject.fee = int.Parse(Console.ReadLine());
                input.subjects.Add(input_subject);
            }
            program_list.Add(input);
        }
        static void generate_merit(List<Student> stu_list)
        {
            stu_list.Sort((a,b) => a.merit.CompareTo(b.merit));
            for (int i = 0; i < stu_list.Count; i++)
            {
                bool is_reg = false;
                for(int j = 0; j < stu_list[i].preference.Count; j++)
                {
                    if(stu_list[i].merit>stu_list[i].preference[j].merit)
                    {
                        stu_list[i].program = stu_list[i].preference[j];
                        Console.WriteLine(stu_list[i].name+" got addmission in "+stu_list[i].preference[j].title);
                        is_reg = true;
                        break;
                    }
                }
                if(!is_reg)
                {
                    Console.WriteLine(stu_list[i].name + " did not got addmission.");
                }
            }
        }
        static void display_registered(List<Student> stu_list)
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            for (int i = 0; i < stu_list.Count; i++)
            {
                if(stu_list[i].program!=null)
                {
                    Console.WriteLine(stu_list[i].name+"\t"+stu_list[i].fsc+"\t"+stu_list[i].ecat+"\t"+stu_list[i].age);
                }
            }
        }
        static void specific_degree(List<Student> stu_list)
        {
            Console.WriteLine("Enter the name of Degree : ");
            string str = Console.ReadLine();
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            for (int i = 0; i < stu_list.Count; i++)
            {
                if(stu_list[i].program.title==str)
                {
                    Console.WriteLine(stu_list[i].name + "\t" + stu_list[i].fsc + "\t" + stu_list[i].ecat + "\t" + stu_list[i].age);
                }
            }
        }
        static void register_subjects(List<Student> stu_list)
        {
            Console.WriteLine("Enter the name of Student : ");
            string str = Console.ReadLine();
            Console.Write("Enter the code of subject : ");
            string str2 = Console.ReadLine();
            for (int i = 0; i < stu_list.Count; i++)
            {
                if(stu_list[i].program!=null && str== stu_list[i].name)
                {
                    bool check = false;
                    for (int m = 0; m < 10; m++)
                    {
                        if (str2 == stu_list[i].program.subjects[m].code)
                        {
                            stu_list[i].subjects.Add(stu_list[i].program.subjects[m]);
                            Console.WriteLine("Registered...");
                            check= true;
                            break;
                        }
                    }
                    if(!check)
                    {
                        Console.WriteLine("Code does not exists.");
                    }
                }
            }
        }
        static void fee_generation(List<Student> stu_list)
        {
            for (int i = 0; i < stu_list.Count; i++)
            {
                if(stu_list[i].program!=null)
                {
                    stu_list[i].fee=stu_list[i].cal_fee();
                }
            }
        }
    }
}
