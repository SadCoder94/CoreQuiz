using System.Collections.Generic;

namespace QuizLibrary
{
    public interface IQuiz
    {
        List<Question> GetAllQuestions();
        Question GetQuestionById(string questionId);
        bool AddQuestions();
        bool DeleteQuestion(string questionId);
        Question UpdateQuestion(string questionId);
        void Initiate();
        void DisplayQuizQuestions();
    }
}
