using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCDC_Sandbox
{
    class FluentInterfaces
    {
        void GetEmployees()
        {
            Employee oldEmployee = new Employee()
            {
                NameOfEmployee = "Jason",
                DateOfBirth = "9/4/1971",
                PlaceOfBirth = "Tacoma"
            };

            EmployeeFluentInterface fluentEmployee = new EmployeeFluentInterface();
            var employeeFluent = fluentEmployee.NameOfEmployee("Jason")
                .DateOfBirth("9/4/1971")
                .PlaceOfBirth("Tacoma");
        }
    }

    class Employee
    {
        public string NameOfEmployee { get; set; }
        public string DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
    }

    class EmployeeFluentInterface
    {
        private Employee employee = new Employee();

        public EmployeeFluentInterface NameOfEmployee(string name)
        {
            employee.NameOfEmployee = name;
            return this;
        }

        public EmployeeFluentInterface DateOfBirth(string dob)
        {
            employee.DateOfBirth = dob;
            return this;
        }

        public EmployeeFluentInterface PlaceOfBirth(string homeTown)
        {
            employee.PlaceOfBirth = homeTown;
            return this;
        }
    }
}
