using System;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String CSV = "Emplyee4,Employee2,500 Employee3,Employee1,800 Employee1,,1000 Employee5,Employee1,500 Employee2,Employee1,500";
            Employee employee = new Employee(CSV);

            Console.WriteLine("Salary Valid:" + employee.validateSalary());
            Console.WriteLine("Employess Valid: " + employee.ValidateEmployee());
            Console.WriteLine("No Circular: " + employee.ValidateNoCicularRef());
            Console.WriteLine("Salary for employee one : " + employee.CalculateSalary("Employee1"));
        }
    }
}
