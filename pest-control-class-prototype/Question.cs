using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public abstract class Question
    {
        public int Id { get; set; }
        public CourseSection Section { get; set; }
        public abstract IEnumerable<Answer> Answers { get; set; }
        public abstract Answer CorrectAnswer { get; }
        public string CorrectAnswerExplanation { get; set; }
    }
