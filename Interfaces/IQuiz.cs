using System.Collections.Generic;

namespace QuizLibrary
{
    public interface IQuiz
    {
        List<Question> GetAllQuestions();
        Question GetQuestionById(string questionId);
        bool AddQuestion(Question new_q);
        bool DeleteQuestion(string questionId);
        bool UpdateQuestion(Question question,string new_ques,int index);
        void Initiate();
        void DisplayQuizQuestions();
    }
}
