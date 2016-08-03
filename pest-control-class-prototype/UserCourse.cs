using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class UserCourse
    {
        public Course Course { get; set; }
        public UserCourseSection Sections { get; set; }
        public bool IsCourseCompleted { get; set; }
        public UserTest CourseTest { get; set; }
    }
