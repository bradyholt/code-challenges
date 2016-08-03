using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class VideoQuestion : MediaQuestion 
    {
        public override string MediaUri
        {
            get { throw new NotImplementedException(); }
        }

        public override IEnumerable<Answer> Answers { get; set; }
        public override Answer CorrectAnswer { get { throw new NotImplementedException(); } }
    }
