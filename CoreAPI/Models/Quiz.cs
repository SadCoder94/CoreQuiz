using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI
{
    public partial class Quiz
    {
        public Quiz()
        {
            Question = new HashSet<Question>();
        }
        [Key]
        public int QuizId { get; set; }
        public string QuizName { get; set; }

        public ICollection<Question> Question { get; set; }
    }
}
