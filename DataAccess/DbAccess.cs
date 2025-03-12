using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    public class DbAccess : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbAccess(DbContextOptions<DbAccess> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CandidateMap(modelBuilder.Entity<Candidate>());
            // Настройка свойств сущности Candidate
            modelBuilder.Entity<Candidate>()
                .HasKey(u => u.Id); // Устанавливаем свойство Id как первичный ключ

            modelBuilder.Entity<Candidate>()
                .Property(u => u.Email)
                .IsRequired(); // Требуем, чтобы Email был обязательным

            base.OnModelCreating(modelBuilder);
        }

        private void CandidateMap(EntityTypeBuilder<Candidate> entityBuilder)
        {
            entityBuilder.ToTable("Candidates");
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(s => s.Email).IsRequired();
            entityBuilder.Property(s => s.Email).IsRequired();
            entityBuilder.Property(s => s.Email).IsRequired();
            entityBuilder.Property(s => s.Email).IsRequired();
            entityBuilder.Property(s => s.Email).IsRequired();
            //entityBuilder.Property(s => s.Balance).HasColumnType("numeric").IsRequired();
        }
    }
}
