using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Position
    {
        public decimal Salary { get; }
        public string Title { get; }
        public string PositionName { get; set; }
        public Position() { }

        public Position(decimal salary, string title)
        {
            Salary = salary;
            Title = title;
        }
    }
}