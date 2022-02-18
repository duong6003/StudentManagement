using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StudentManagement.Models
{
    public partial class StudentManageContext : DbContext
    {
        public StudentManageContext()
        {
        }

        public StudentManageContext(DbContextOptions<StudentManageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ExamResult> ExamResults { get; set; }
        public virtual DbSet<Gift> Gifts { get; set; }
        public virtual DbSet<GiftItem> GiftItems { get; set; }
        public virtual DbSet<GiftType> GiftTypes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HomeroomTeacherCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.HomeroomTeacherCodeNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.HomeroomTeacherCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Classes__Homeroo__1273C1CD");
            });

            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ExamResults)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExamResults__Students");

                entity.HasOne(d => d.SubjectCodeNavigation)
                    .WithMany(p => p.ExamResults)
                    .HasForeignKey(d => d.SubjectCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExamResul__Subje__1DE57479");
            });

            modelBuilder.Entity<Gift>(entity =>
            {
                entity.Property(e => e.AwardDay).HasColumnType("date");

                entity.Property(e => e.GiftCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

            });

            modelBuilder.Entity<GiftItem>(entity =>
            {
                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.GiftType)
                    .WithMany(p => p.GiftItems)
                    .HasForeignKey(d => d.GiftTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GiftItem__GiftType");
            });

            modelBuilder.Entity<GiftType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Address).HasMaxLength(128);

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.ClassCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.ClassCodeNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students__ClassC__1920BF5C");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.Degree)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
