using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class UserTest
    {
        public User User { get; set; }
        public IEnumerable<UserTestQuestion> Questions { get; set; }
        public int UnsuccesfulAttempts { get; set; }
        public bool IsPassed { get; set; }
        public Certificate Certificate { get; set; }
    }
