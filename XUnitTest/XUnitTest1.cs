using System;
using Xunit;
using CoreQuiz;

namespace XUnitTest
{
    public class XUnitTest1
    {
        [Fact]
        public void PassContainsQMark()
        {
            string[] ops = { "qw", "we", "er", "rt" };
            var obj = new Question("ques ?", ops);
            Assert.Contains("?",obj.question);
        }

        [Fact]
        public void FailContainsQMark()
        {
            string[] ops = { "qw", "we", "er", "rt" };
            var obj = new Question("ques", ops);
            Assert.DoesNotContain("?", obj.question);
        }
    }
}
