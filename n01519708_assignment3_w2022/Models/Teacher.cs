using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01519708_assignment3_w2022.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public Subject Subject { get; set; }
    }
}