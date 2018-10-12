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

namespace CoreMVC.Tests.Controller
{
    public class ControllerShould
    {
        private readonly QuizController _controller;

        //public ControllerShould()
        //{
        //    _controller = new QuizController(IQuiz quiz);
        //}

        [Fact]
        public void CheckIndexReturn()
        {
            //var sut =  _controller.Index();
            //var result = sut.Wait();
            //IEnumerable<Question> model = (IEnumerable<Question>)(result);
            //foreach (var item in model)
            //{
            //    if (item.Question_statement == "how are you doing ?")
            //    {
            //        Assert.Equal("how are you doing ?", item.Question_statement);
            //        break;
            //    }
            //}
            //Assert.True(result.ToString().Equals(HttpStatusCode.OK));
            var QuizRepository = new Mock<IQuiz>();
            var QuizController = new QuizController(QuizRepository.Object);
        }
    }
}
