using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace LINQ
{
    public class Expressions
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

        public void expr()
        {
            //Expression<Func<Student, bool>> isTeenExpr = s => s.Age < 20 && s.Age > 12;
            //Func<Student, bool> isTeen = isTeenExpr.Compile();

            //var stud = new Student() {Age = 14, StudentName = "Raj", StudentID = 8};
            //bool res = isTeen(stud);
            //Console.WriteLine(res);



            ParameterExpression pe = Expression.Parameter(typeof(Student), "s");

            MemberExpression me = Expression.Property(pe, "Age");

            ConstantExpression constant = Expression.Constant(18, typeof(int));

            BinaryExpression body = Expression.GreaterThanOrEqual(me, constant);

            var ExpressionTree = Expression.Lambda<Func<Student, bool>>(body, new[] { pe });

            Console.WriteLine("Expression Tree: {0}", ExpressionTree);

            Console.WriteLine("Expression Tree Body: {0}", ExpressionTree.Body);

            Console.WriteLine("Number of Parameters in Expression Tree: {0}",
                ExpressionTree.Parameters.Count);

            Console.WriteLine("Parameters in Expression Tree: {0}", ExpressionTree.Parameters[0]);

        }



    }
}