using System;
using Xunit;
using CoreQuiz;

namespace XUnitTest
{
    public class XUnitTest1
    {
        [Theory]
        [InlineData("ques")]
        [InlineData("ques?")]
        public void PassContainsQMark(string ques)
        {
            string[] ops = { "qw", "we", "er", "rt" };
            var obj = new Question(ques, ops);
            Assert.Contains("?",obj.question);
        }


        
    }
}
