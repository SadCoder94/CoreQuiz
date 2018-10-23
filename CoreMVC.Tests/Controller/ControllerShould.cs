using CoreMVC.Controllers;
using CoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using QuizLibrary;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace CoreMVC.Tests.Controller
{
    public class ControllerShould
    {

        DBQuizController testcontroller;

        public ControllerShould()
        {
            TestClient testclient = new TestClient()
            {
                res = "[{\"questionId\": 3,\"quizId\": 1,\"question_statement\": \"Question 2 ?\",\"time\": \"2018-10-09T16:25:40.227\",\"correctAnswer\": \"Answer 20\",\"options\": null,\"question_type\": \"Subjective\",\"quiz\": null}]"
            };

            testcontroller = new DBQuizController(testclient);
        }
        
        [Fact]
        public async Task CheckIndexReturn()
        {
            //Arrange
            

            //Act
            var result =await testcontroller.Index();
            ViewResult viewResult = (ViewResult)result;

            //Assert
            //Assert.Equal(200, viewResult.StatusCode);
            Assert.NotNull(viewResult.ViewData.Model);
            Assert.NotEmpty(viewResult.ViewData);
            //var viewResult=Assert.IsType<ViewResult>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<Question>>(viewResult.ViewData.Model);
            //Assert.NotEmpty(model);



        }
    }
}
