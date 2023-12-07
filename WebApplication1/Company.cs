using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Company
    {
        public DateTime CreationDate { get; }
        public Position[] Positions { get; }
        public List<Employee> Employees { get; }

        public Company(DateTime creationDate, Position[] positions)
        {
            CreationDate = creationDate;
            Positions = positions;
            Employees = new List<Employee>();
        }

        public Position GetPositionByTitle(string title)
        {
            foreach (Position position in Positions)
            {
                if (position.Title == title)
                {
                    return position;
                }
            }
            return null;
        }
    }
}