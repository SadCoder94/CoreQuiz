using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using QuizLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =new CoreMVCContext(
                serviceProvider.GetRequiredService<DbContextOptions<CoreMVCContext>>()))
            {
                if(context.Question.Any())
                {
                    return;
                }
                context.Question.AddRange(
                    new Question {
                        Question_statement="qwer?",
                        Time=DateTime.Parse("4:30 PM"),
                        CorrectAnswer="ty",
                        Question_type="Subjective"
                    },
                    new Question
                    {
                        Question_statement = "asd?",
                        Time = DateTime.Parse("4:30 PM"),
                        CorrectAnswer = "d",
                        Options="d,f,g,h",
                        Question_type = "MCQ"
                    },
                    new Question
                    {
                        Question_statement = "fgh?",
                        Time = DateTime.Parse("4:30 PM"),
                        CorrectAnswer = "g",
                        Options = "d,f,g,h",
                        Question_type = "MCQ"
                    },
                    new Question
                    {
                        Question_statement = "sdf?",
                        Time = DateTime.Parse("4:30 PM"),
                        CorrectAnswer = "f",
                        Options = "d,f,g,h",
                        Question_type = "MCQ"
                    },
                    new Question
                    {
                        Question_statement = "zxc?",
                        Time = DateTime.Parse("4:30 PM"),
                        CorrectAnswer = "xc",
                        Question_type = "Subjective"
                    }
                    );
                    context.SaveChanges();
            }
        }
    }
}
