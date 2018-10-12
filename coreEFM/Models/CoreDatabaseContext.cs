using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace CoreEFM.Models
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
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionStatement).HasColumnName("Question_statement");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK_QuizId");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.QuizName).IsRequired();
            });
        }
    }
}
