using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public partial class Quiz
    {
        public Quiz()
        {
            Question = new HashSet<Question>();
        }

        public int QuizId { get; set; }
        public string QuizName { get; set; }

        public ICollection<Question> Question { get; set; }
    }
}
