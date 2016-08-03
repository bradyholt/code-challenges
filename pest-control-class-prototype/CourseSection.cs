using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class CourseSection
    {
        public string Name { get; set; }
        public string DocumentUri { get; set; }
        public IEnumerable<Question> Questions { get; set; } 
    }
