using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLibrary;

namespace CoreEFQuiz.Data
{

    public class QuizContext: DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Question;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<QuizManager>()
            //    .HasKey(c => c.QuizId);

            //modelBuilder.Entity<Question>()
            //    .HasKey(c => c.QuestionId);

            modelBuilder.Entity<QuizManager>(entity =>
            {
                entity.Property(e => e.QuizId).IsRequired();
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionId).IsRequired();
                //entity.HasOne(e => e.QuestionId).WithOne(q => q.)
            });
        }

        public DbSet<QuizManager> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
    } 
}
