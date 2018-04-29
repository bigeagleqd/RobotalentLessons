using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RobotalentLessons.Models
{
    public partial class robotalentLessonsContext : DbContext
    {
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
        public virtual DbSet<Lessons> Lessons { get; set; }
        public virtual DbSet<LessonSchedule> LessonSchedule { get; set; }
        public virtual DbSet<PersonInLessons> PersonInLessons { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }

       public robotalentLessonsContext(DbContextOptions<robotalentLessonsContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(95);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Lessons>(entity =>
            {
                entity.ToTable("lessons");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BeginDate)
                    .HasColumnName("beginDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CurrentLessonNumber)
                    .HasColumnName("currentLessonNumber")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LessonNumbers)
                    .HasColumnName("lessonNumbers")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LessonType)
                    .HasColumnName("lessonType")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<LessonSchedule>(entity =>
            {
                entity.ToTable("lessonSchedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BeginTime).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LessonId).HasColumnName("lessonId");
            });

            modelBuilder.Entity<PersonInLessons>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.Lessonid });

                entity.ToTable("personInLessons");

                entity.HasIndex(e => e.Lessonid)
                    .HasName("fk_personInLessons_lessons");

                entity.HasIndex(e => e.PersonId)
                    .HasName("fk_persons_personInLessons");

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.Lessonid).HasColumnName("lessonid");

                entity.Property(e => e.Actor)
                    .HasColumnName("actor")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.PersonInLessons)
                    .HasForeignKey(d => d.Lessonid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_personInLessons_lessons");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonInLessons)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_persons_personInLessons");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.ToTable("persons");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasColumnName("mobile")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PersonType)
                    .HasColumnName("personType")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.Wechat)
                    .HasColumnName("wechat")
                    .HasMaxLength(30);
            });
        }
    }
}
