using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01519708_assignment3_w2022.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentFname { get; set; }
        public string StudentLname { get; set; }
        public string StudentNumber { get; set; }
        public DateTime EnrolDate { get; set; }
    }
}