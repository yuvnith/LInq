using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public delegate bool Del(Student stud);
    class Program
    {
        static void Main(string[] args)
        {

            Student[] studentArray = {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 21 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 } ,
                new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 } ,
                new Student() { StudentID = 7, StudentName = "Rob",Age = 19  } ,
            };

            string[] abc = { "abcd", "efgh", "easdfasd", "sa" };

            var res = from v in abc
                      where v.Length == 2
                      select v;

            var res2 = from v2 in studentArray
                       where v2.StudentID == 2
                       select v2.Age;


            //var res3 = studentArray.Where(s=>s.Age.Equals(18));
            //else
            //var res3 = studentArray.Where(StudentFind);
            //foreach (var re in res3)
            //{
            //    Console.WriteLine(re.StudentName);
            //}

            var res4 = abc.Where(s => s.Contains('a'));

            var res5 = studentArray.Select(v => v.StudentName);

            var res6 = studentArray.Average(v => v.Age);
        
            //Console.WriteLine(res6);

            var res7 = studentArray.First(v => v.StudentName.Contains('a'));
            //Console.WriteLine(res7.StudentName);

            var res8 = from v2 in studentArray
                where v2.Age == 21
                select v2.StudentName;



            var res9 = from s7 in studentArray
                where s7.StudentID == 1
                select s7.StudentName;
                       

            foreach (var re in res9)
            {
                Console.WriteLine(re);
            }

            Console.ReadKey();
        }

        public static bool StudentFind(Student s)
        {
            return s.Age.Equals(21);
        }

       // public static 

      
    }



}
