using System;
using System.Collections.Generic;

namespace ConsoleAppDelegates
{
    class Program
    {
        public static void HelloMethod(string message)
        {
            Console.WriteLine(message);
        }

        public delegate void HelloMethodDelegate(string message);   //Delegate

        //Implementing with Delegate
        public static bool IsPromateEmployee(Employee emp)
        {
            if (emp.Experience >= 5)
                return true;
            else
                return false;
        }
        public delegate bool IsPromoteEmp(Employee emply);  //Delegate

        static void Main(string[] args)
        {
            HelloMethodDelegate del = new HelloMethodDelegate(HelloMethod);
            del.Invoke("Hello from delegate.");

            //Implementing without delegates
            Console.WriteLine();
            Console.WriteLine("Without Delegate:");
            List<Employee> employee = new List<Employee>();
            employee.Add(new Employee { Id = 101, Name = "Sarfaraz", Salary = 1000, Experience = 7 });
            employee.Add(new Employee { Id = 102, Name = "Ahmed", Salary = 2000, Experience = 5 });
            employee.Add(new Employee { Id = 103, Name = "Faraz", Salary = 3000, Experience = 6 });
            employee.Add(new Employee { Id = 104, Name = "Tom", Salary = 4000, Experience = 10 });
            employee.Add(new Employee { Id = 105, Name = "Jerry", Salary = 5000, Experience = 3 });
            employee.Add(new Employee { Id = 106, Name = "Sam", Salary = 6000, Experience = 2 });
            employee.Add(new Employee { Id = 107, Name = "Rose", Salary = 7000, Experience = 4 });
            Employee.PromoteEmployee(employee);

            //Implementing with Delegate           
            Console.WriteLine();
            Console.WriteLine("With Delegate");
            IsPromoteEmp empDel = new IsPromoteEmp(IsPromateEmployee);
            Employee.PromoteEmployeeWithDelegate(employee, empDel);
            Console.WriteLine();
            Employee.PromoteEmployeeWithDelegate(employee, emp => emp.Salary >= 2000);  //can also do using lambda
        }       
    }
}
