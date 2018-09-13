using System;

namespace QuizLibrary
{
    public class Question
    {
        public string Id { get; set; }
        public string Question_statement { get; set; }
        public DateTime Time { get; set; }
        public string CorrectAnswer { get; set; }
        public string[] Options { get; set; }
        public string Question_type { get; set; }

        public Question()
        {
            
        }

        public override string ToString()
        {
            if (this.Question_type == "MCQ")
                return " Question: " + this.Question_statement + "\nOptions:-\n1." + this.Options[0] + "\n2." + this.Options[1] + "\n3." + this.Options[2] + "\n3." + this.Options[3];
            else
                return " Question: " + this.Question_statement;
        }
        
    }
}
