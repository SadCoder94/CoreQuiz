using System.Collections.Generic;

namespace QuizLibrary
{
    public interface IQuiz
    {
        int QuizId { get; set; }
        //ICollection<Question> Question_List { get; set; }
        List<Question> GetAllQuestions();
        Question GetQuestionById(string questionId);
        bool AddQuestion(Question new_q);
        bool DeleteQuestion(string questionId);
        bool UpdateQuestion(Question new_ques);
        void Initiate();
        void DisplayQuizQuestions();
    }
}
