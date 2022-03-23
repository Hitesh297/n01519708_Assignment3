using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01519708_assignment3_w2022.Models
{
    public class Subject
    {
        public int ClassId { get; set; }
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime StartDate { get; set; }
        public int TeacherId { get; set; }

    }
}