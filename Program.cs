using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public delegate bool Del(Student stud);

    public delegate bool Del2(Student stud, int age);
    class Program
    {
        static void Main(string[] args)
        {

            Student[] studentArray = {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Ram",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 23 } ,
                new Student() { StudentID = 5, StudentName = "Ram" , Age = 21 } ,
                new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 } ,
                new Student() { StudentID = 7, StudentName = "Rob",Age = 18  } ,
            };

            Student2[] studentArray2 = {
                new Student2() { StudentID = 1, Marks = 12 } ,
                new Student2() { StudentID = 2,  Marks = 25 } ,
                new Student2() { StudentID = 3,Marks = 6 } ,
                new Student2() { StudentID = 4,Marks = 20 } ,
                new Student2() { StudentID = 5,  Marks = 21 } ,
                new Student2() { StudentID = 6,  Marks = 7 } ,
                new Student2() { StudentID = 7, Marks = 19  } ,
            };

            var aList = new ArrayList(){1,"a",'d',233,'s',"asdsa",'a',"fdsa"};
            

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

            var res10 = from v2 in studentArray
                where v2.StudentName == "John"
                select v2.Age;


            Del2 del2 = (Student s, int age) => s.Age < age; 
            //Console.WriteLine(del2(studentArray[0],20));

            var res11 = studentArray.Where((s ) => s.Age == 18);

            Func<Student, bool> func1 = s => s.Age > 18;

            var res12 = studentArray.Where(func1);


            var res13 = from s in studentArray
                where func1(s)
                select s;


            var res14 = studentArray.Where((s, i) => i == 1 );


            var res15 = studentArray.Where(s => s.Age > 18).Where(a => a.Age < 25);

            var res16 = from s in aList.OfType<int>()
                        select s;

            var res17 = from s in studentArray
                orderby s.StudentName descending 
                select s;

            var res18 = studentArray.OrderBy(s => s.Age);
            var res19 = studentArray.OrderByDescending(s => s.Age).Where(s=>s.Age==21);

            var res20 = from s in studentArray
                orderby s.Age
                where s.Age == 21
                select new { s.Age, s.StudentName };

            var res21 = studentArray.OrderBy(s => s.StudentName).ThenBy(s => s.Age);

            var res22 = from s9 in studentArray
                group s9 by s9.Age;

            var res23 = studentArray.GroupBy(s => s.Age);
            
            //foreach (var re in res23)
            //{
            //    Console.WriteLine(re.Key);
            //    foreach (var student in re)
            //    {
            //        Console.WriteLine(student.StudentName+" "+student.Age);
            //    }
            //}



            var res24 = studentArray.Join(studentArray2, student => student.StudentID, student2 => student2.StudentID,
                (student, student2) => new {student.StudentName, student2.Marks});



            var res25 = from s in studentArray
                join s2 in studentArray2 on s.StudentID equals s2.StudentID
                select new
                {
                    s.StudentName,
                    s2.Marks
                };

            foreach (var re in res25)
            {
                //Console.WriteLine(re.StudentName+" "+re.Marks);
              
            }


            //Console.WriteLine(studentArray.All(s=>s.Age<100));

            //Console.WriteLine(studentArray.Any(s => s.Age < 10));


            var std = new Student() {Age = 12, StudentID = 1, StudentName = "Bill"};

            //Console.WriteLine(studentArray.Contains(std));

            string temp = "asfas";
            //Console.WriteLine(temp.MyExtensionMeth());

            var e = new Expressions();
            e.expr();


            Console.ReadKey();
        }

        public static bool StudentFind(Student s)
        {
            return s.Age.Equals(21);
        }

       // public static 

      
    }



}
