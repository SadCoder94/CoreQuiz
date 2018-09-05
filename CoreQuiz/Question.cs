using System;
using System.Collections.Generic;
using System.Text;

namespace CoreQuiz
{
    class Question
    {
        private string question;
        private string[] options = new string[4];
        private DateTime time;

        public Question()
        {
            this.question = String.Empty;
            for (int i = 0; i < 4; i++)
            {
                this.options[i] = String.Empty;
            }
        }

        public Question(string question, string[] options)
        {
            this.question = question;
            this.options = options;
            this.time = DateTime.Now;
        }

        public void GetQuestion(int i)
        {
            Console.WriteLine("Question {0} {1}", i, this.question);
            Console.WriteLine("Options " + string.Join(",", this.options));
        }
    }
}
