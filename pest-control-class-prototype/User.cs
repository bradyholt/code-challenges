using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public abstract class User
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        public IEnumerable<UserCourse> Courses { get; set; }
    }
