using System;

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

    
}
