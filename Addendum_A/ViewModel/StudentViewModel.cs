using System;
using Addendum_A.Models;
using System.Collections.Generic;

namespace Addendum_A.ViewModel
{
    public class StudentViewModel
    {
        public List<Student> StudentList { get; set; }
        public Student SingleStudent { get; set; }
    }
}