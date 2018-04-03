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


            //s.Age >= 18
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


            //s=>s.age==18
            ParameterExpression pe2 = Expression.Parameter(typeof(Student), "s");
            MemberExpression me2 = Expression.Property(pe2, "Age");
            ConstantExpression constant2 = Expression.Constant(18, typeof(int));
            BinaryExpression body2 = Expression.Equal(me2, constant2);
            var ExpressionTree2 = Expression.Lambda<Func<Student, bool>>(body2, /*new[] {pe2}*/pe2);
            Console.WriteLine("Expression Tree: {0}", ExpressionTree2);

            //a,b,c=>(a*b)+c
            ParameterExpression a = Expression.Parameter(typeof(int), "a");
            ParameterExpression b = Expression.Parameter(typeof(int), "b");
            ParameterExpression c = Expression.Parameter(typeof(int), "c");
            ParameterExpression[] pe3 = new ParameterExpression[]{a,b,c};

            BinaryExpression body3 = Expression.Add(Expression.Multiply(a, b), c);
            var ExpressionTree3 = Expression.Lambda<Func<int, int,int, int>>(body3, pe3);
            Console.WriteLine("Expression Tree: {0}", ExpressionTree3);


            // s => s.Age < 20 && s.Age > 12;
            ParameterExpression pe4 = Expression.Parameter(typeof(Student), "s");
            MemberExpression me4 = Expression.Property(pe4, "Age");
            ConstantExpression ce4 = Expression.Constant(20,typeof(int));
            ConstantExpression ce42 = Expression.Constant(12, typeof(int));
            BinaryExpression left = Expression.LessThan(me4, ce4);
            BinaryExpression right = Expression.GreaterThan(me4, ce42);
            BinaryExpression Body4 = Expression.And(left, right);
            var ExpressionTree4 = Expression.Lambda<Func<Student, bool>>(Body4, pe4);
            Console.WriteLine("Expression Tree: {0}", ExpressionTree4);
            

        }



    }
}