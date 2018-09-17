using System;
using System.Collections.Generic;

namespace QuizLibrary
{
    public class QuizManager : IQuiz
    {
        private List<Question> _questionList=new List<Question>();
        public static int id_no = 0;
        //bool choice = true;
        //int q_no = 0;
        string temp_ques = String.Empty, c_ans = String.Empty, ques_id = String.Empty, ques_type = String.Empty;
        string[] temp_ops = new string[4];
        DataSourceLinker dataSourceLinker;

        
        public bool AddQuestion(Question new_q)
        {
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
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error in deleting question");
                return false;
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

        public Question UpdateQuestion(Question question)
        {
            if (question.Question_type == "MCQ")
                Console.WriteLine("Question: {0}\nOptions: {1}\nCorrect Answer: {2}", question.Question_statement, string.Join(',', question.Options), question.CorrectAnswer);
            else
                Console.WriteLine("Question: {0}\nCorrect Answer: {1}", question.Question_statement, question.CorrectAnswer);

            Console.WriteLine("Enter new question");
            question.Question_statement = Console.ReadLine();

            return question;
        }

        public void DisplayQuizQuestions()
        {
            Console.WriteLine("Quiz:-");
            foreach (Question item in _questionList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void Initiate()
        {
            int choice = 0;
            Console.WriteLine("Welcome to quiz maker");
            _questionList = GetAllQuestions();
            if(_questionList.Count !=0)
            id_no = Convert.ToInt32(_questionList[_questionList.Count -1].Id.Substring(2));

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
                        dataSourceLinker.AddData(_questionList);
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
                        dataSourceLinker.AddData(_questionList);
                        break;
                    case 3:
                        DisplayQuizQuestions();
                        break;
                    case 4:
                        Console.WriteLine("Enter question id to update");
                        temp_ques = Console.ReadLine();
                        Question updated_ques = new Question();

                        foreach (var item in _questionList)
                        {
                            if(item.Id==temp_ques)
                            {
                                updated_ques = UpdateQuestion(item);
                                int index=_questionList.IndexOf(item);
                                _questionList.Remove(item);
                                _questionList.Insert(index, item);
                            }
                               
                        }
                        dataSourceLinker.AddData(_questionList);
                        break;
                    default:
                        break;
                }
            } while (choice<4);

            //dataSourceLinker.AddData(_questionList);
        }

        //public void CreateQuiz()
        //{
        //    Console.WriteLine("Welcome to quiz maker");
        //    do
        //    {                
        //        AddQuestions();
        //        q_no++;
        //        Console.WriteLine("Do you want to enter another question ? y/n");
        //        choice = Console.ReadLine() == "y" ? true : false;

        //    } while (choice);
        //}

        private string GetVerifiedQuestion()
        {
            do
            {
                Console.WriteLine("Enter Question (end with ?)");
                temp_ques = Console.ReadLine();
            } while (!temp_ques.EndsWith("?"));

            return temp_ques;
        }

        public List<Question> GetList()
        {
            return _questionList;
        }

        public void PutList()
        {
            _questionList = GetAllQuestions();
        }

        public int Count()
        {
            return _questionList.Count;
        }
    }
}
