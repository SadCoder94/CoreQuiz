using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace CoreAPI
{
    public partial class CoreDatabaseContext : DbContext
    {
        public CoreDatabaseContext()
        {
        }

        public CoreDatabaseContext(DbContextOptions<CoreDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Question_statement).HasColumnName("Question_statement");
                entity.Property(e => e.Question_type).HasColumnName("QuestionType");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK_QuizId");
            });

            modelBuilder.Entity<Question>()
            .HasKey(c => c.QuestionId);

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.QuizName).IsRequired();
            });
            
        }

        public DbSet<Question> Question_set { get; set; }
    }
}
