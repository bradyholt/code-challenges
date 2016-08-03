using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class UserTestQuestion
    {
        public UserTest Test { get; set; }
        public Question Question { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public Answer UserResponse { get; set; }
        public bool IsVisible { get; set; }
    }
