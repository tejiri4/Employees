using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using EmployeeApp;
using System;

namespace EmployeeAppTest
{
    [TestClass]
    public class EmployeeTest
    {
        private Employee employee;

        [TestMethod]
        public void TestValidSalaries()
        {
            String CSV = "Emplyee4,Employee2,500 Employee3,Employee1,800 Employee1,,1000 Employee5,Employee1,500 Employee2,Employee1,500";
            Employee employee = new Employee(CSV);
            string expected = "Salaries are valid.";
            string result = employee.validateSalary();
 
            Assert.AreEqual(expected, result, "Should return valid salary string");
        }

        [TestMethod]
        public void TestInvalidSalaries()
        {
            String CSV = "Emplyee4,Employee2,500 Employee3,Employee1,800T Employee1,,1000 Employee5,Employee1,500 Employee2,Employee1,500";
            Employee employee = new Employee(CSV);
            string expected = "Wrong Salary Value: 800T";
            string result = employee.validateSalary();

            Assert.AreEqual(expected, result, "Should return invalid salary string");
        }

        [TestMethod]
        public void TestValidEmployee()
        {
            String CSV = "Emplyee4,Employee2,500 Employee3,Employee1,800 Employee1,,1000 Employee5,Employee1,500 Employee2,Employee1,500";
            Employee employee = new Employee(CSV);
            string expected = "No employee report to multiple manager.";
            string result = employee.ValidateEmployee();

            Assert.AreEqual(expected, result, "Should not find an employee who report to multiple manager");
        }

        [TestMethod]
        public void TestInvalidEmployee()
        {
            String CSV = "Emplyee4,Employee2,500 Emplyee4,Employee1,800 Employee1,,1000 Employee5,Employee1,500 Employee2,Employee1,500";
            Employee employee = new Employee(CSV);
            string expected = "An employee which report to multiple manager is found.";
            string result = employee.ValidateEmployee();

            Assert.AreEqual(expected, result, "Should find an employee who report to multiple manager");
        }


        [TestMethod]
        public void TestOnlyOneManager()
        {
            String CSV = "Emplyee4,Employee2,500 Employee3,Employee1,800 Employee1,,1000 Employee5,Employee1,500 Employee2,Employee1,500";
            Employee employee = new Employee(CSV);
            string expected = "One CEO was found.";
            string result = employee.ValidateOnlyOneManager();

            Assert.AreEqual(expected, result, "Should find only one CEO");
        }

        [TestMethod]
        public void TestMultipleManager()
        {
            String CSV = "Emplyee4,Employee2,500 Employee3,,800 Employee1,,1000 Employee5,Employee1,500 Employee2,Employee1,500";
            Employee employee = new Employee(CSV);
            string expected = "More than one CEO was found.";
            string result = employee.ValidateOnlyOneManager();

            Assert.AreEqual(expected, result, "Should find multiple CEO");
        }

        [TestMethod]
        public void TestNoManager()
        {
            String CSV = "Emplyee4,Employee2,500 Employee3,Employee1,800 Employee1,Employee3,1000 Employee5,Employee1,500 Employee2,Employee1,500";
            Employee employee = new Employee(CSV);
            string expected = "No CEO was found.";
            string result = employee.ValidateOnlyOneManager();

            Assert.AreEqual(expected, result, "Should find no CEO");
        }


        [TestMethod]
        public void TestNoCicularRef()
        {
            String CSV = "Emplyee4,Employee2,500 Employee3,Employee1,800 Employee1,,1000 Employee5,Employee1,500 Employee2,Employee1,500";
            Employee employee = new Employee(CSV);
            string expected = "No circular refence found.";
            string result = employee.ValidateNoCicularRef();

            Assert.AreEqual(expected, result, "Should find no circular reference.");
        }

        [TestMethod]
        public void TestCicularRefExist()
        {
            String CSV = "Emplyee4,Employee2,500 Employee3,Employee1,800 Employee1,,1000 Employee5,Employee1,500 Employee2,Emplyee4,500";
            Employee employee = new Employee(CSV);
            string expected = "Circular reference was found for Emplyee4";
            string result = employee.ValidateNoCicularRef();

            Assert.AreEqual(expected, result, "Should find an employee which report to the second employee that is under the first employee");
        }


        [TestMethod]
        public void TestManagerIsEmployee()
        {
            String CSV = "Emplyee4,Employee2,500 Employee3,Employee1,800 Employee1,,1000 Employee5,Employee1,500 Employee2,Employee1,500";
            Employee employee = new Employee(CSV);
            string expected = "All manager are employee.";
            string result = employee.ValidateManagerIsEmployee();

            Assert.AreEqual(expected, result, "Should return a string showing all manager are employee");
        }

        [TestMethod]
        public void TestManagerIsNotEmployee()
        {
            String CSV = "Emplyee4,Employee2,500 Employee3,Employee1,800 Employee1,,1000 Employee5,Employee6,500 Employee2,Employee1,500";
            Employee employee = new Employee(CSV);
            string expected = "Employee6 is not an employee but hold a manager role.";
            string result = employee.ValidateManagerIsEmployee();

            Assert.AreEqual(expected, result, "Should return a string showing Employee6 which is a manager is not an employee");
        }

        [TestMethod]
        public void TestCalculateSalary()
        {
            String CSV = "Emplyee4,Employee2,500 Employee3,Employee1,800 Employee1,,1000 Employee5,Employee1,500 Employee2,Employee1,500";
            Employee employee = new Employee(CSV);
            int expected = 2800;
            long result = employee.CalculateSalary("Employee1");

            Assert.AreEqual(expected, result, "Should Return 2800 expected salary");
        }
    }
}
