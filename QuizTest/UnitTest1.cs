using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreQuiz;

namespace QuizTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] ops = {"qw", "we", "er", "rt"};
            var val1 = new Question("ques",ops);

            Assert.AreEqual(System.DateTime.Now,val1.time);

            //string[] ops2 = { "qw", "we", "er", "rt" };
            //Question val2 = new Question("asdf",ops2);



        }
    }
}
