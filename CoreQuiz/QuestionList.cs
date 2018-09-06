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
        
        public void Sort()
        {
            List<Question> questions= this._list;
            questions.Sort(
                delegate (Question o1,Question o2)
                {
                    if(o1.time.CompareTo(o2.time)>=0)
                    {
                        return 1;
                    }

                    return 0;
                });
            this._list = questions;
        }

        public void SortDesc()
        {
            List<Question> questions = this._list;
            questions.Sort(
                delegate (Question o1, Question o2)
                {
                    if (o1.time.CompareTo(o2.time) < 0)
                    {
                        return 1;
                    }

                    return 0;
                });
            this._list = questions;
        }
    }
}
