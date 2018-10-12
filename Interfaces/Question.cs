using System;
using System.ComponentModel.DataAnnotations;

namespace QuizLibrary
{
    public class Question //: IQuestion
    {
        [MaxLength(4)]
        public string QuestionId { get; set; }
        public string Question_statement { get; set; }
        [DisplayFormat(DataFormatString ="{0:h:mm tt}",ApplyFormatInEditMode =true)]
        public DateTime Time { get; set; }
        public string CorrectAnswer { get; set; }  
        public string Options { get; set; }
        public string Question_type { get; set; }

        public override string ToString()
        {
            if (this.Question_type == "MCQ")
                return " Question: " + this.Question_statement + "\nOptions:-\n" + this.GetOptions();
            else
                return " Question: " + this.Question_statement;
        }

        public string GetOptions()
        {
            string[] options = this.Options.Split(',');
            string options_string=String.Empty;

            for (int i = 1; i <= options.Length; i++)
            {
                options_string += i + ". " + options[i - 1];
            }

            return options_string;
        }
        
    }
}
