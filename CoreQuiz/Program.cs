using System;
using QuizLibrary;

namespace CoreQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            QuizManager quizManager = new QuizManager();
            quizManager.Initiate();
            //Console.ReadKey();
        }
    }
    
}
