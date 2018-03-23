using System;

namespace LINQ{
    public delegate int d1(int a1);
    public static class FindStudents
    {
        public static Student[] FindingStudents(Student[] studs, Del del)
        {
            Student[] students = new Student[studs.Length];
            int i = 0;
            foreach (var student in studs)
            {
                if (del(student))
                {
                    students[i] = student;
                    i++;
                }
            }

            Array.Resize(ref students,i);

            return students;
        }


        public static void demodelegate()
        {
            
            
           d1 obj= (a) => (a + 5);

            
            Console.WriteLine(obj(5));
        }
    }
}