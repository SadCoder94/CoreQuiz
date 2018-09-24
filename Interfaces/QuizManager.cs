﻿using System;
using System.Collections.Generic;

namespace QuizLibrary
{
    public class QuizManager : IQuiz
    {
        private List<Question> _questionList;
        public static int id_no = 0;
        string temp_ques = String.Empty, c_ans = String.Empty, ques_id = String.Empty, ques_type = String.Empty;
        readonly string[] temp_ops = new string[4];
        DataSourceLinker dataSourceLinker;

        public bool AddQuestion(Question new_q)
        {
            try
            {
                _questionList.Add(new_q);
                dataSourceLinker.AddData(_questionList);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Error in adding Question.");
                return false;
            }
            
        }

        public bool GetQuestionInformation()
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
                else if (ques_type == "2")
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

            }while (flag);

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
            new_q.Id = "Q_" + id_no.ToString();
            id_no++;

            return AddQuestion(new_q);
        }

        public bool DeleteQuestion(string questionId)
        {
            try
            {
                foreach (Question item in _questionList)
                {
                    if (item.Id == questionId)
                    {
                        _questionList.Remove(item);
                        dataSourceLinker.AddData(_questionList);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error in deleting question");
                return false;
            }

            return true;
        }

        public List<Question> GetAllQuestions()
        {
            dataSourceLinker = new DataSourceLinker();
            var data = dataSourceLinker.GetData();
            if (data!=null)
            {
                return data;
            }
            return new List<Question>();
        }

        public Question GetQuestionById(string questionId)
        {
            dataSourceLinker = new DataSourceLinker();
            return dataSourceLinker.GetData(questionId);
        }

        public bool UpdateQuestion(Question question,string new_ques,int index)
        {
            try
            {
                _questionList.RemoveAt(index);
                question.Question_statement = new_ques;

                _questionList.Insert(index, question);
                return dataSourceLinker.AddData(_questionList);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            //return true;
        }

        public void DisplayQuizQuestions()
        {
            if (_questionList.Count > 0)
            {
                Console.WriteLine("Quiz:-");
                foreach (Question item in _questionList)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("No Questions found");
            }

        }

        public void Initiate()
        {
            int choice = 0;
            Console.WriteLine("Welcome to quiz maker");
            //PopulateList();
            if(_questionList.Count !=0)
            id_no = Convert.ToInt32(_questionList[_questionList.Count -1].Id.Substring(2))+1;

            do
            {
                Console.WriteLine("Press 1. To add new Question" +
                    "\nPress 2. To delete Questions" +
                    "\nPress 3. To show all Questions" +
                    "\nPress 4. To update a Question" +
                    "\nPress 5. To exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        if (GetQuestionInformation())
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
                        UpdateProcedure();
                        break;
                    default:
                        break;
                }
            } while (choice<5);

        }

        public QuizManager()
        {
            _questionList = GetAllQuestions();
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

        public void UpdateProcedure()
        {
            Console.WriteLine("Enter question id to update");
            ques_id = Console.ReadLine();
            bool found_flag = false;

            foreach (var item in _questionList)
            {
                if (item.Id == ques_id)
                {
                    do
                    {
                        Console.WriteLine("Enter new question");
                        temp_ques = Console.ReadLine();
                    } while (temp_ques.Length == 0);

                    int index = _questionList.IndexOf(item);
                    if (UpdateQuestion(item, temp_ques,index))
                    {
                        Console.WriteLine("Successfully Updated Question {0} ", item.Id);
                    } 
                    else
                    {
                        Console.WriteLine("Question was not updated, try again");
                        break;
                    }
                    found_flag = true;
                    break;
                }

            }

            if (!found_flag)
            {
                Console.WriteLine("Question not found");
            }
        }
    }
}
