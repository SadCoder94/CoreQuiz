﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizLibrary;

namespace CoreMVC.Models
{
    public class CoreMVCContext : DbContext
    {
        public CoreMVCContext (DbContextOptions<CoreMVCContext> options)
            : base(options)
        {
        }

        public DbSet<CoreAPI.Question> Question { get; set; }
    }
}
