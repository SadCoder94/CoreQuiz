using System;
using System.Collections.Generic;
using System.Text;

namespace CoreQuiz
{
    class QuestionList
    {
        private List<Question> _list = new List<Question>();

        public Question this[int i]
        {
            get
            {
                return _list[i];
            }
            set
            {
                _list.Add(value);
            }
        }

        public int length()
        {
            return this._list.Count;
        }
        
    }
}
