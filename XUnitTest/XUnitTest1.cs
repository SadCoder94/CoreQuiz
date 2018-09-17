using Xunit;
using QuizLibrary;
using System.Collections.Generic;
using System;

namespace XUnitTest
{
    public class XUnitTest1 : IDisposable
    {
        QuizManager quizManager;
        public List<Question> list;
        DataSourceLinker dataSourceLinker;

        public XUnitTest1()
        {
            quizManager = new QuizManager();
            list = new List<Question>();
            dataSourceLinker = new DataSourceLinker();
        }
        
        [Fact]
        public void TestAddQuestion()
        {
            Question trial = new Question
            {
                CorrectAnswer = "a",
                Question_statement = "asd ?",
                Id = "Q_11",
                Question_type = "Subjective",
                Time = DateTime.UtcNow
            };

            list.Add(trial);
            Assert.True(quizManager.AddQuestion(trial));
        }

        [Fact]
        public void TestDeleteQuestion()
        {
            Question trial = new Question
            {
                CorrectAnswer = "a",
                Question_statement = "asd ?",
                Id = "Q_13",
                Question_type = "Subjective",
                Time = DateTime.UtcNow
            };

            list.Add(trial);
            quizManager.PutList(list);
            string id = "Q_13";

            Assert.True(quizManager.DeleteQuestion(id));
        }

        [Fact]
        public void TestUpdateQuestions()
        {
            
            list.AddRange(new List<Question>
            { new Question {
                CorrectAnswer = "a",
                Question_statement = "asd ?",
                Id = "Q_13",
                Question_type = "Subjective",
                Time = DateTime.UtcNow
                },
              new Question {
                CorrectAnswer = "b",
                Question_statement = "nsd ?",
                Id = "Q_15",
                Question_type = "Subjective",
                Time = DateTime.UtcNow
                },
              new Question {
                CorrectAnswer = "c",
                Question_statement = "msd ?",
                Id = "Q_16",
                Question_type = "Subjective",
                Time = DateTime.UtcNow
                }
            });
            quizManager.PutList(list);
            quizManager.UpdateQuestion(list[1],"fgd?");
            Assert.Equal("fgd?", list[1].Question_statement);
        }


        public void Dispose()
        {
            
        }
    }
}
