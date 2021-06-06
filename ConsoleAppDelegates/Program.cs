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

        //Implementing multicast delegates
        public static void SampleMethod1()
        {
            Console.WriteLine("Sample Method1 is invoked.");
        }
        public static void SampleMethod2()
        {
            Console.WriteLine("Sample Method2 is invoked.");
        }
        public static void SampleMethod3()
        {
            Console.WriteLine("Sample Method3 is invoked.");
        }
        public delegate void SampleDelegate();  //Delegate

        //Multi cast delegate to demostrate delegate return only the last added invoked delegate
        public static int Add(int fn,int sn)
        {
            return fn + sn;
        }
        public static int Multiply(int fn,int sn)
        {
            return fn * sn;
        }
        public delegate int DelCalculate(int fn, int sn);   //Delegate
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

            //Impementing multi cast delegate
            Console.WriteLine();
            Console.WriteLine("Multi cast Delegates.");
            SampleDelegate sd1, sd2, sd3,sd4;
            sd1 = new SampleDelegate(SampleMethod1);
            sd2 = new SampleDelegate(SampleMethod2);
            sd3 = new SampleDelegate(SampleMethod3);

            sd4 = sd1 + sd2 + sd3;  //Multi cast delegate
            sd4.Invoke();

            Console.WriteLine();
            sd4 = sd1 - sd2 + sd3;  //Multi cast delegate removing sd2 delegate reference
            sd4.Invoke();

            //another way to do add and remove
            Console.WriteLine();
            sd1 = new SampleDelegate(SampleMethod1);
            sd1 += SampleMethod2;
            sd1 += SampleMethod3;
            sd1.Invoke();

            Console.WriteLine();            
            sd1 -= SampleMethod2;
            sd1.Invoke();

            //Multi cast delegate to demostrate delegate return only the last added invoked delegate
            Console.WriteLine();
            Console.WriteLine("Multi cast delegate to demostrate delegate return only the last added invoked delegate");
            DelCalculate delcal = new DelCalculate(Add);
            int result = delcal.Invoke(10, 20);
            Console.WriteLine(result);

            DelCalculate myDel = new DelCalculate(Add);
            delcal += Multiply;
            result = delcal.Invoke(10, 20);
            Console.WriteLine(result);
        }       
    }
}
