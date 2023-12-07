using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace WebApplication1
{
    public class Employee
    {
        public string EmployeeId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime RecruitmentDate { get; }
        public string Sexe { get; }
        public decimal Salary { get; }

        public Employee(string employeeId, string firstName, string lastName, String Sexe, DateTime recruitmentDate, decimal salary)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            RecruitmentDate = recruitmentDate;
            Salary = salary;
            this.Sexe = Sexe;
        }
    }
}