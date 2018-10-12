using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreEFQuiz.Models
{
    public partial class CoreMVCCOntext : DbContext
    {
        public CoreMVCCOntext()
        {
        }

        public CoreMVCCOntext(DbContextOptions<CoreMVCCOntext> options)
            : base(options)
        {
        }

        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=CoreMVCContext-5b8305ab-3112-4c42-9cfc-002aa7078f8e;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionId).ValueGeneratedNever();

                entity.Property(e => e.QuestionStatement).HasColumnName("Question_statement");

                entity.Property(e => e.QuestionType).HasColumnName("Question_type");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PK_Quiz");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.QuizId).ValueGeneratedNever();

                entity.Property(e => e.QuizName).HasMaxLength(20);
            });
        }
    }
}
