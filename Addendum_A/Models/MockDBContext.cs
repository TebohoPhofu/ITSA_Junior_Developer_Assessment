using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Addendum_A.Models
{
    public partial class MockDBContext : DbContext
    {
        public MockDBContext()
        {
        }

        public MockDBContext(DbContextOptions<MockDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlite(@"DataSource=C:\Users\Teboho Phofu\source\repos\ITSA_Junior_Developer_Assessment\Addendum_A\Data\MockDB.db");
                optionsBuilder.UseSqlite(@$"DataSource={Startup.ContentRoot}\Data\MockDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Student)
                    .WithOne(p => p.Class)
                    .HasForeignKey<Class>(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Student)
                    .WithOne(p => p.Mark)
                    .HasForeignKey<Mark>(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //private partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}