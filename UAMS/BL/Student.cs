using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    internal class Student
    {
        public string name;
        public int age;
        public float ecat;
        public float fsc;
        public float merit;
        public float fee;

        public List<Programs> preference=new List<Programs>();
        public Programs program;
        public List<Subjects> subjects = new List<Subjects>(); 
        public Student() { }
        public Student(string name,int age,float fsc,float ecat)
        {
            this.name = name;
            this.age = age;
            this.fsc = fsc;
            this.ecat = ecat;
        }
        public float cal_merit()
        {
            float merit = fsc / 1100 * 60 + ecat / 400 * 40;
            return merit;
        }
        public float cal_fee()
        {
            float count = 0;
            for (int i = 0; i < subjects.Count; i++)
            {
                count = count + subjects[i].fee;
            }
            return count;
        }
    }
}
