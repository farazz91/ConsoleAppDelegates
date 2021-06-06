using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleAppDelegates.Program;

namespace ConsoleAppDelegates
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }

        public static void PromoteEmployee(List<Employee> employeeList)
        {
            foreach (var employee in employeeList)
            {
                if (employee.Experience>=5)
                {
                    Console.WriteLine(employee.Name + " is Promoted.");
                }
            }
        }
        public static void PromoteEmployeeWithDelegate(List<Employee> employeeList, IsPromoteEmp isEligibleForPromotion)
        {
            foreach (var employee in employeeList)
            {
                if (isEligibleForPromotion(employee))
                {
                    Console.WriteLine(employee.Name + " is Promoted.");
                }
            }
        }
    }
}
