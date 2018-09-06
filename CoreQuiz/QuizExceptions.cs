using System;
using System.Collections.Generic;
using System.Text;

namespace CoreQuiz
{
    public class InvalidQuestionFormatException : Exception
    {
        public InvalidQuestionFormatException()
        {

        }

        public InvalidQuestionFormatException(string message) : base(message)
        {

        }
    }

    public class InvalidOptionsException : Exception
    {
        public InvalidOptionsException()
        {

        }

        public InvalidOptionsException(string message) : base(message)
        {

        }
    }
}
