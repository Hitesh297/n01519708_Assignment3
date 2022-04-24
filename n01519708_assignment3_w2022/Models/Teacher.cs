using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace n01519708_assignment3_w2022.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Employee Number")]
        public string EmployeeNumber { get; set; }
        public DateTime HireDate { get; set; }
        [DisplayName("Salary")]
        public decimal Salary { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}