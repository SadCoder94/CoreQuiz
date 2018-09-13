﻿using System;
using System.Collections.Generic;

namespace QuizLibrary
{
    public class QuizManager : IQuiz
    {
        private List<Question> _questionList;
        public static int id_no = 0;
        bool choice = true;
        int q_no = 0;
        string temp_ques = String.Empty, c_ans = String.Empty, ques_id = String.Empty, ques_type = String.Empty;
        string[] temp_ops = new string[4];
        DataSourceLinker dataSourceLinker;


        public bool AddQuestions()
        {
            Question new_q = new Question();
            bool flag = true;
            new_q.Question_statement = GetVerifiedQuestion();

            do
            {
                Console.WriteLine("Enter type of question\nPress 1. for MCQ\nPress 2. for Subjective");
                ques_type = Console.ReadLine();
                if (ques_type == "1")
                {
                    new_q.Question_type = "MCQ";
                }
                else if(ques_type=="2")
                {
                    new_q.Question_type = "Subjective";
                }
                else
                {
                    Console.WriteLine("Wrong choice, try again");
                    continue;
                }

                if (ques_type == "1")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine("Enter option {0}", i + 1);
                        temp_ops[i] = Console.ReadLine();
                    }

                    new_q.Options = temp_ops;
                }

                flag = false;
            } while (flag);

            if (ques_type == "1")
            {
                flag = true;
                do
                {
                    Console.WriteLine("Enter correct answer");
                    c_ans = Console.ReadLine();
                    if (Array.IndexOf(temp_ops, c_ans) == -1)
                        Console.WriteLine("answer not among options");
                    else
                        flag = false;

                } while (flag);
            }
            else
            {
                Console.WriteLine("Enter correct answer");
                c_ans = Console.ReadLine();
            }

            new_q.CorrectAnswer = c_ans;

            new_q.Time = DateTime.UtcNow;
            new_q.Id = "Q_"+id_no.ToString();
            id_no++;

            try
            {
                _questionList.Add(new_q);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Error in adding Question.");
                return false;
            }
            
        }

        public bool DeleteQuestion(string questionId)
        {
            foreach (Question item in _questionList)
            {
                if (item.Id==questionId)
                {
                    _questionList.Remove(item);
                    return true;
                }
            }

            return false;

        }

        public List<Question> GetAllQuestions()
        {
            dataSourceLinker = new DataSourceLinker();
            return dataSourceLinker.GetData();                                   
        }

        public Question GetQuestionById(string questionId)
        {
            dataSourceLinker = new DataSourceLinker();
            return dataSourceLinker.GetData(questionId);
        }

        public Question UpdateQuestion(string questionId)
        {
            
            foreach (Question item in _questionList)
            {
                if(item.Id==questionId)
                    return Update(item);
            }
            return null;
        }

        public Question Update(Question param_question)
        { 
            if(param_question.Question_type=="MCQ")
                Console.WriteLine("Question: {0}\nOptions: {1}\nCorrect Answer: {2}",param_question.Question_statement,string.Join(',',param_question.Options),param_question.CorrectAnswer);
            else
                Console.WriteLine("Question: {0}\nCorrect Answer: {1}", param_question.Question_statement, param_question.CorrectAnswer);

            Console.WriteLine("Enter new question");
            param_question.Question_statement = Console.ReadLine();
            
            return param_question;
        }

        public void Initiate()
        {
            int choice = 0;
            Console.WriteLine("Welcome to quiz maker");
            _questionList = GetAllQuestions();
            do
            {
                Console.WriteLine("Press 1. To add new Question\nPress 2. To delete Questions\nPress 3. To show all Questions\nPress 4. To update a Question\nPress 5. To exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        if (AddQuestions())
                        {
                            Console.WriteLine("Successfully added question");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter id of question to delete");
                        ques_id = Console.ReadLine();
                        if(DeleteQuestion(ques_id))
                        {
                            Console.WriteLine("Question successfully deleted");
                        }
                        else
                        {
                            Console.WriteLine("Question not found");
                        }
                        break;
                    case 3:
                        DisplayQuizQuestions();
                        break;
                    case 4:
                        Console.WriteLine("Enter question to update");
                        temp_ques = Console.ReadLine();
                        UpdateQuestion(temp_ques);
                        break;
                    default:
                        break;
                }
            } while (choice<4);

            dataSourceLinker.AddData(_questionList);
        }

        public void CreateQuiz()
        {
            Console.WriteLine("Welcome to quiz maker");
            do
            {                
                AddQuestions();
                q_no++;
                Console.WriteLine("Do you want to enter another question ? y/n");
                choice = Console.ReadLine() == "y" ? true : false;

            } while (choice);
        }

        private string GetVerifiedQuestion()
        {
            do
            {
                Console.WriteLine("Enter Question (end with ?)");
                temp_ques = Console.ReadLine();
            } while (!temp_ques.EndsWith("?"));

            return temp_ques;
        }

        public void DisplayQuizQuestions()
        {
            Console.WriteLine("Quiz:-");
            foreach (Question item in _questionList)
            {
                item.ToString();
            }
        }
    }
}
