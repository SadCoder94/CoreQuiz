using System;
using System.Collections.Generic;
using System.Text;

namespace CoreQuiz
{
    class QuestionList
    {
        private List<MCQQuestion> _list = new List<MCQQuestion>();

        public MCQQuestion this[int i]
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
            List<MCQQuestion> questions= this._list;
            questions.Sort(
                delegate (MCQQuestion o1,MCQQuestion o2)
                {
                    if(o1.GetTime().CompareTo(o2.GetTime()) >=0)
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
