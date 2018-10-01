using Microsoft.AspNetCore.Mvc.Rendering;
using QuizLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public class MVCQTypeViewModel
    {
        public List<Question> questions;
        public SelectList Types;
        public string QType { get; set; }
    }
}
