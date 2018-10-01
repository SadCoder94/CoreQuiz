using System;
using System.ComponentModel.DataAnnotations;

namespace QuizLibrary
{
    public interface IQuestion
    {
        [MaxLength(4)]
        string Id { get; set; }
        string Question_statement { get; set; }
        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        DateTime Time { get; set; }
        string CorrectAnswer { get; set; }
        string Options { get; set; }
        string Question_type { get; set; }

        string GetOptions();
        string ToString();
    }
}