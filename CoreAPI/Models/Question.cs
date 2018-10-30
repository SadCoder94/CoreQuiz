using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI
{
    public partial class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        public string Question_statement { get; set; }
        public DateTime? Time { get; set; }
        public string CorrectAnswer { get; set; }
        public string Options { get; set; }
        public string Question_type { get; set; }

        public Quiz Quiz { get; set; }
    }
}
