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
            fluentEmployee.CreateEmployee("Jason")
                .BornOn("9/4/1971")
                .HomeTown("Tacoma");
            Employee newEmployee = fluentEmployee.GetEmployee;
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
        public Employee GetEmployee { get { return employee; } }
        private Employee employee = new Employee();

        public EmployeeFluentInterface CreateEmployee(string name)
        {
            employee.NameOfEmployee = name;
            return this;
        }

        public EmployeeFluentInterface BornOn(string dob)
        {
            employee.DateOfBirth = dob;
            return this;
        }

        public EmployeeFluentInterface HomeTown(string homeTown)
        {
            employee.PlaceOfBirth = homeTown;
            return this;
        }
    }
}
