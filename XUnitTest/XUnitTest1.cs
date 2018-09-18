using Xunit;
using QuizLibrary;
using System.Collections.Generic;
using System;
using Xunit.Abstractions;

namespace XUnitTest
{
    public class XUnitTest1 : IClassFixture<QuizManagerFixture>
    {
        //QuizManager quizManager;
        //public List<Question> list;
        //readonly DataSourceLinker dataSourceLinker;
        private readonly ITestOutputHelper _testOutputHelper;

        private readonly QuizManagerFixture _fixture;

        public XUnitTest1(ITestOutputHelper helper, QuizManagerFixture fixture)
        {
            _testOutputHelper = helper;
            _fixture = fixture;

            //quizManager = new QuizManager();
            //list = new List<Question>();
            //dataSourceLinker = new DataSourceLinker();
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
            
            Assert.True(_fixture.Sut.AddQuestion(trial));
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

            _fixture.Sut.AddQuestion(trial);
            //quizManager.PutList(list);
            string id = "Q_13";

            Assert.True(_fixture.Sut.DeleteQuestion(id));
        }

        [Fact]
        public void TestDeleteQuestionwhenListEmpty()
        {
            string id = "Q_14";
            Assert.False(_fixture.Sut.DeleteQuestion(id));
        }

        [Fact]
        public void TestUpdateQuestions()
        {
            
            Question new_q = new Question
            {
                CorrectAnswer = "c",
                Question_statement = "msd ?",
                Id = "Q_16",
                Question_type = "Subjective",
                Time = DateTime.UtcNow
            };

            _fixture.Sut.UpdateQuestion(new_q, "fgd?");
            _testOutputHelper.WriteLine(new_q.ToString());
            Assert.Equal("fgd?", new_q.Question_statement);
            
        }
    }
}
