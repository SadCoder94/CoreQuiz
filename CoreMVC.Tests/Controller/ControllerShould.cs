using CoreMVC.Controllers;
using CoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using QuizLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoreMVC.Tests.Controller
{
    public class ControllerShould
    {
        private readonly QuizController _controller;

        public ControllerShould()
        {
            _controller = new QuizController();
        }

        [Fact]
        public void CheckViewReturn()
        {
            dynamic sut =  _controller.Index() as Task<ActionResult>;

            var result = sut.Result;
            IEnumerable<Question> model = (IEnumerable<Question>)(result.Model);
            foreach (var item in model)
            {
                if (item.Question_statement == "how are you doing ?")
                {
                    Assert.Equal("how are you doing ?", item.Question_statement);
                    break;
                }
            }
            
        }
    }
}
