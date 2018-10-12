using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public class QuizContext
    {
        //public CoreMVCContext(DbContextOptions<CoreMVCContext> options)
        //    : base(options)
        //{
        //}

        public List<QuizLibrary.Question> Questions { get; set; }
    }
}
