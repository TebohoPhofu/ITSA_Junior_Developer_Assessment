using System;
using System.Collections.Generic;
using Addendum_A.Models;
using System.ComponentModel.DataAnnotations;

namespace Addendum_A.ViewModel
{
    public class AdminViewModel
    {
        public Student SingleStudent { get; set; }
        public List<Mark> MarkList { get; set; }
        public List<Class> ClassList { get; set; }
        public bool Show { get; set; }
        public bool Submited { get; set; }
    }
}