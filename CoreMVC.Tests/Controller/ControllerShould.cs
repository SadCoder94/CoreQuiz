using CoreMVC.Controllers;
using CoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using CoreAPI;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace CoreMVC.Tests.Controller
{
    public class TestControllers
    {

        DBQuizController testcontroller;
        private List<Question> newQuesList=new List<Question>();
        Question newQues;

        public TestControllers()
        {
            newQues = new Question() {
                QuestionId = 3,
                Question_statement = "suup ?",
                Time = DateTime.UtcNow,
                CorrectAnswer="rt",
                Options= "qw,we,er,rt",
                Question_type="Objective",
                Quiz=null,
                QuizId=2
            };

            newQuesList.Add(newQues);

            TestClient testclient = new TestClient()
            {
                res = JsonConvert.SerializeObject(newQuesList)
            };

            testcontroller = new DBQuizController(testclient);
        }
        
        [Fact]
        public async Task CheckIndex()
        {
            //Arrange

            //Act
            var result =await testcontroller.Index();
            ViewResult viewResult = result as ViewResult;
            List<Question> questions = (List<Question>)viewResult.Model;

            //Assert
            Assert.True(questions[0].QuestionId==newQues.QuestionId);      
        }
    }
}
