﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizMaker.Data;

#nullable disable

namespace QuizMaker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221026221049_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuizMaker.Identity.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("QuizMaker.Identity.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("QuizMaker.Models.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("QuizMaker.Models.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("QText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("QuizMaker.Models.Quiz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Quiz");
                });

            modelBuilder.Entity("QuizMaker.Models.RequiredStudent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeacherQuizId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeacherQuizId");

                    b.ToTable("RequiredStudent");
                });

            modelBuilder.Entity("QuizMaker.Models.TestedStudent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Mark")
                        .HasColumnType("float");

                    b.Property<string>("QuizId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeacherQuizId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeacherQuizId");

                    b.ToTable("TestedStudent");
                });

            modelBuilder.Entity("QuizMaker.Models.StudentQuiz", b =>
                {
                    b.HasBaseType("QuizMaker.Models.Quiz");

                    b.Property<double>("Mark")
                        .HasColumnType("float");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("StudentId");

                    b.HasDiscriminator().HasValue("StudentQuiz");
                });

            modelBuilder.Entity("QuizMaker.Models.TeacherQuiz", b =>
                {
                    b.HasBaseType("QuizMaker.Models.Quiz");

                    b.Property<Guid?>("TeacherId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("TeacherId1");

                    b.HasDiscriminator().HasValue("TeacherQuiz");
                });

            modelBuilder.Entity("QuizMaker.Models.Answer", b =>
                {
                    b.HasOne("QuizMaker.Models.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("QuizMaker.Models.Question", b =>
                {
                    b.HasOne("QuizMaker.Models.Quiz", null)
                        .WithMany("Questions")
                        .HasForeignKey("QuizId");
                });

            modelBuilder.Entity("QuizMaker.Models.RequiredStudent", b =>
                {
                    b.HasOne("QuizMaker.Models.TeacherQuiz", null)
                        .WithMany("RequiredStudents")
                        .HasForeignKey("TeacherQuizId");
                });

            modelBuilder.Entity("QuizMaker.Models.TestedStudent", b =>
                {
                    b.HasOne("QuizMaker.Models.TeacherQuiz", null)
                        .WithMany("TestedStudents")
                        .HasForeignKey("TeacherQuizId");
                });

            modelBuilder.Entity("QuizMaker.Models.StudentQuiz", b =>
                {
                    b.HasOne("QuizMaker.Identity.Student", null)
                        .WithMany("Quizzes")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("QuizMaker.Models.TeacherQuiz", b =>
                {
                    b.HasOne("QuizMaker.Identity.Teacher", null)
                        .WithMany("Quizzes")
                        .HasForeignKey("TeacherId1");
                });

            modelBuilder.Entity("QuizMaker.Identity.Student", b =>
                {
                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("QuizMaker.Identity.Teacher", b =>
                {
                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("QuizMaker.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("QuizMaker.Models.Quiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("QuizMaker.Models.TeacherQuiz", b =>
                {
                    b.Navigation("RequiredStudents");

                    b.Navigation("TestedStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
