<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyFacultyWebApplication.Models;
=======
﻿using Microsoft.EntityFrameworkCore;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6

namespace MyFacultyWebApplication.Models;

public partial class MyFacultyDbContext : DbContext
{
    public MyFacultyDbContext()
    {
    }

    public MyFacultyDbContext(DbContextOptions<MyFacultyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Degree> Degrees { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupToSpecialtyRelation> GroupToSpecialtyRelations { get; set; }

    public virtual DbSet<GroupToSubjectRelation> GroupToSubjectRelations { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentToStatusRelation> StudentToStatusRelations { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherToDegreeRelation> TeacherToDegreeRelations { get; set; }

    public virtual DbSet<TeacherToSubjectRelation> TeacherToSubjectRelations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=PC-Vanyatko\\SQLEXPRESS;Database=MyFacultyDB; Trusted_Connection=True;Trust Server Certificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Degree>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(10);

            entity.HasOne(s => s.Specialty).WithMany()
                .HasForeignKey(g => g.SpecialtyId);
        });

        modelBuilder.Entity<GroupToSpecialtyRelation>(entity =>
        {
            entity.ToTable("GroupToSpecialtyRelation");

            /*entity.HasOne(d => d.Group).WithMany(p => p.GroupToSpecialtyRelations)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupToSpecialtyRelation_Groups");

            entity.HasOne(d => d.Specialty).WithMany(p => p.GroupToSpecialtyRelations)
                .HasForeignKey(d => d.SpecialtyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupToSpecialtyRelation_Specialties");*/
        });

        modelBuilder.Entity<GroupToSubjectRelation>(entity =>
        {
            entity.ToTable("GroupToSubjectRelation");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupToSubjectRelations)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupToSubjectRelation_Groups");

            entity.HasOne(d => d.Subject).WithMany(p => p.GroupToSubjectRelations)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupToSubjectRelation_Subjects");
        });

        modelBuilder.Entity<Material>(entity =>
        {
<<<<<<< HEAD
=======
            //entity.HasNoKey();
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(50);

            entity.Property(e => e.Url)
                .HasMaxLength(100);


            entity.HasOne(d => d.Subject).WithMany()
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_Subjects");
        });

        modelBuilder.Entity<Specialty>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Statuse");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Student");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(s => s.Status).WithMany()
                .HasForeignKey(s => s.StatusId)
                .HasConstraintName("FK_Student_Statuses");

            entity.HasOne(d => d.Group).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Student_Groups");
        });

        modelBuilder.Entity<StudentToStatusRelation>(entity =>
        {
            entity.ToTable("StudentToStatusRelation");

            /*entity.HasOne(d => d.Status).WithMany(p => p.StudentToStatusRelations)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentToStatusRelation_Statuses");

            entity.HasOne(d => d.StudentId).WithMany(p => p.StudentToStatusRelations)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentToStatusRelation_Students");*/
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.Property(e => e.Abbreviation).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<TeacherToDegreeRelation>(entity =>
        {
            entity.ToTable("TeacherToDegreeRelation");

            entity.HasOne(d => d.Degree).WithMany(p => p.TeacherToDegreeRelations)
                .HasForeignKey(d => d.DegreeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherToDegreeRelation_Degrees");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherToDegreeRelations)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherToDegreeRelation_Teachers");
        });

        modelBuilder.Entity<TeacherToSubjectRelation>(entity =>
        {
            entity.ToTable("TeacherToSubjectRelation");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeacherToSubjectRelations)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherToSubjectRelation_Subjects");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherToSubjectRelations)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherToSubjectRelation_Teachers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
