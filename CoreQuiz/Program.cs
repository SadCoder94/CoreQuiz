using System;
using System.Collections.Generic;

namespace CoreQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Initiate();
            Console.ReadKey();
        }

        public static void Initiate()
        {
            var questions = new QuestionList();
            bool choice = true;
            int q_no = 0;
            string[] temp_ops = new string[4];
            string temp_ques = String.Empty;

            Console.WriteLine("Welcome to quiz maker");

            do
            {
                Console.WriteLine("Enter question {0}", q_no + 1);
                temp_ques = Console.ReadLine();

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Enter option {0}", i + 1);
                    temp_ops[i] = Console.ReadLine();
                }

                questions[q_no] = new Question(temp_ques, temp_ops);
                q_no += 1;
                Console.WriteLine("Do you want to enter another question ? y/n");
                choice = Console.ReadLine() == "y" ? true : false;

            } while (choice);


            for (int i = 0; i < q_no; i++)
            {
                questions[i].GetQuestion(i + 1);

            }
        }

    }
    
}
