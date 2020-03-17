using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp
{
    public class Employee
    {
        private List<String> Employees;
        private List<String> Salaries;
        private List<String> Managers;



        public Employee(String csv) 
        {
            String[] rows = csv.Split(" ");
            Employees = new List<string>();
            Salaries = new List<string>();
            Managers = new List<string>();


            // check if string is empty or null
            if (!String.IsNullOrEmpty(csv))
            {

                // split csv into managers, employees and salaries array
                for (int index = 0; index < rows.Length; index++)
                {
                    String[] row = rows[index].Split(',');
                    Employees.Add(row[0]);
                    Managers.Add(row[1]);
                    Salaries.Add(row[2]);
                }

                // validate all salaries in CSV are valid integer
                validateSalary();

                // validate one employee does not report to more than one manager
                ValidateEmployee();

                // validate if only one manager exist
                ValidateOnlyOneManager();

                // check for circular reference
                ValidateNoCicularRef();
            }
            else
            {
                Console.WriteLine("Parameter must be a string");
            }
        }



        public String validateSalary()
        {
            foreach (String salary in Salaries)
            {
                try
                {
                    Int64.Parse(salary);
                }
                catch (Exception e)
                {
                    return "Wrong Salary Value: " + salary;
                }
            }
            return "Salaries are valid.";
        }



        public String ValidateEmployee()
        {
            HashSet<string> uniqueEmployees = new HashSet<String>();

            // add unique employees to hashset
            for (int index = 0; index < Employees.Count; index++)
            {
                string employee = Employees[index];

                    uniqueEmployees.Add(employee);
            }

            // checks if duplicate exist if count are not equal
            if (uniqueEmployees.Count != Employees.Count)
            {
                return "An employee which report to multiple manager is found.";
            }

            return "No employee report to multiple manager.";
        }



        public String ValidateOnlyOneManager()
        {
            HashSet<string> uniqueEmployees = new HashSet<String>();
            int count = 0;

            foreach (String manager in Managers)
            {
                if (String.IsNullOrEmpty(manager))
                {
                    count++;
                }
            }

            // we have more than one manager
            switch (count)
            {
                case 1:
                    return "One CEO was found.";
                case 0:
                    return "No CEO was found.";
                default:
                    return "More than one CEO was found.";
            }
        }



        public String ValidateNoCicularRef()
        {
            for (int index = 0; index < Managers.Count; index++)
            {



                int managerIndex = index;



                for (int x = 0; x < Employees.Count; x++)
                {
                    int employeeIndex = x;



                    if (Managers[managerIndex].Equals(Employees[employeeIndex]) && Managers[employeeIndex].Equals(Employees[managerIndex]))
                    {
                        return "Circular reference was found for " + Employees[managerIndex];
                    }
                }
            }



            return "No circular refence found.";
        }



        public String ValidateManagerIsEmployee()
        {



            foreach (String manager in Managers)
            {
                if (!Employees.Contains(manager) && !String.IsNullOrEmpty(manager))
                {
                    return manager + " is not an employee but hold a manager role.";
                }
            }

            return "All manager are employee.";
        }



        public long CalculateSalary(String empId)
        {
            if (!Employees.Contains(empId))
            {
                return -1;
            }

            long sum = 0;

            for (int i = 0; i < Employees.Count; i++)
            {
                if (empId.Equals(Employees[i]))
                {
                    sum += Int64.Parse(Salaries[i]);
                }

            }


            for (int j = 0; j < Managers.Count; j++)
            {
                if (empId.Equals(Managers[j]))
                {
                    sum += Int64.Parse(Salaries[j]);
                }
            }

            return sum;
        }
    }
}
