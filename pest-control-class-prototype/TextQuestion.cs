using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class TextQuestion : Question
    {
        public string QuestionText { get; set; }
        public override IEnumerable<Answer> Answers { get; set; }
        public override Answer CorrectAnswer { get { throw new NotImplementedException(); } }
    }
