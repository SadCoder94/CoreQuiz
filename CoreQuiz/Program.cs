using System;
using System.Collections.Generic;

namespace CoreQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            QuestionList questionList = program.Initiate();
            program.DisplayQuestions(questionList);
            
            program.SortQuestions("asc", questionList);
            Console.WriteLine("-----in ascending order-----");
            program.DisplayQuestions(questionList);

            program.SortQuestions("desc", questionList);
            Console.WriteLine("-----in descending order-----");
            program.DisplayQuestions(questionList);

            Console.ReadKey();
        }

        public QuestionList Initiate()
        {
            QuestionList questions = new QuestionList();
            bool choice = true;
            int q_no = 0;
            string temp_ques = String.Empty;

            Console.WriteLine("Welcome to quiz maker");

            do
            {
                Question new_ques = new Question();

                do
                {
                    Console.WriteLine("Enter Question");
                    temp_ques = Console.ReadLine();
                } while (!temp_ques.EndsWith("?"));
                
                new_ques.question = temp_ques;

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Enter option {0}", i + 1);
                    new_ques.options[i] = Console.ReadLine();
                }

                questions[q_no] = new_ques;
                q_no ++;
                Console.WriteLine("Do you want to enter another question ? y/n");
                choice = Console.ReadLine() == "y" ? true : false;

            } while (choice);

            return questions;
        }

        //public string GetQuestion()
        //{
        //    Console.WriteLine("Enter Question");
        //    return Console.ReadLine();
        //}
        public void DisplayQuestions(QuestionList questions)
        {
            for (int i = 0; i < questions.length(); i++)
            {
                questions[i].GetQuestion(i + 1);
            }
        }

        public void SortQuestions(string option,QuestionList questions)
        {
           switch(option)
            {
                case "asc":
                    questions.Sort();
                    break;
                case "desc":
                    questions.SortDesc();
                    break;
            }
        }
    }
    
}
