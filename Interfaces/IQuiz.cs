using System.Collections.Generic;

namespace QuizLibrary
{
    public interface IQuiz
    {
        List<Question> GetAllQuestions();
        Question GetQuestionById(string questionId);
        bool AddQuestion(Question new_q);
        bool DeleteQuestion(string questionId);
        Question UpdateQuestion(Question question);
        void Initiate();
        void DisplayQuizQuestions();
    }
}
