using Xunit;
using QuizLibrary;
using System.Collections.Generic;
using System;

namespace XUnitTest
{
    public class XUnitTest1 : IDisposable
    {
        QuizManager quizManager;
        //public List<Question> list;
        DataSourceLinker dataSourceLinker;

        public XUnitTest1()
        {
            quizManager = new QuizManager();
            //list = new List<Question>();
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

            //list.Add(trial);
            //dataSourceLinker.AddData(quizManager.GetList());
            Assert.True(quizManager.AddQuestion(trial));
        }

        [Fact]
        public void TestDeleteQuestionWhenListEmpty()
        {
            string id = "Q_11";
            if(quizManager.Count()==0)
              Assert.False(quizManager.DeleteQuestion(id));
        }

        [Fact]
        public void TestListQuestionsExist()
        {
            Assert.NotEmpty(quizManager.GetList());
        }


        public void Dispose()
        {
            
        }
    }
}
