using System;
using System.Collections.Generic;

namespace CoreEFM.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        public string QuestionStatement { get; set; }
        public DateTime? Time { get; set; }
        public string CorrectAnswer { get; set; }
        public string Options { get; set; }
        public string QuestionType { get; set; }

        public Quiz Quiz { get; set; }
    }
}
