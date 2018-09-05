using System;
using System.Collections.Generic;
using System.Text;

namespace CoreQuiz
{
    class QuestionList
    {
        private List<Question> list = new List<Question>();

        public Question this[int i]
        {
            get
            {
                return list[i];
            }
            set
            {
                list.Add(value);
            }
        }
        
    }
}
