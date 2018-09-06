using System;
using System.Collections.Generic;
using System.Text;

namespace CoreQuiz
{
    public class Question
    {
        private string _question;
        private string[] _options = new string[4];
        private DateTime _time;

        public Question()
        {
            this._question = String.Empty;
            for (int i = 0; i < 4; i++)
            {
                this._options[i] = String.Empty;
            }
        }

        public Question(string question, string[] options)
        {
            this._question = question;
            this._options = options;
            this._time = DateTime.Now;
        }

        public void GetQuestion(int i)
        {
            if(i < 0)
            {
                Console.WriteLine("No elements in list");
            }
            else
            {
                Console.WriteLine("Question {0} {1}", i, this._question);
                Console.WriteLine("Options " + string.Join(",", this._options));
            }
        }
        
        public string question
        {
            get
            {
                return this._question;
            }
            set
            {
                if (value.Contains('?') == false)
                {
                    throw new InvalidQuestionFormatException("enter a valid question ending with \"?\"");
                }
                else
                    this._question = value;
            }
        }

        public string[] options
        {
            get
            {
                return this._options;
            }
            set
            {
                if (value.Length <=0)
                {
                    throw new InvalidOptionsException("enter valid options ");
                }
                else
                    this._options = value;
            }
        }

        public DateTime time
        {
            get
            {
                return this._time;
            }
            set
            {
                if (!DateTime.TryParse(value.ToString(),out this._time ))
                {
                    throw new InvalidOptionsException("enter a valid time ");
                }
            }
        }
    }
}
