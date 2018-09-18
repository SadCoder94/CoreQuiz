using System;
using System.Collections.Generic;
using System.Text;
using QuizLibrary;
using Xunit;

namespace XUnitTest
{
    public class QuizManagerFixture
    {
        public QuizManager Sut { get; private set; }
        public QuizManagerFixture()
        {
            Sut = new QuizManager();
        }
    }
}
