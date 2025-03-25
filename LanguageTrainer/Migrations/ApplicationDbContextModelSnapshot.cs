﻿// <auto-generated />
using LanguageTrainer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LanguageTrainer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("LanguageTrainer.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LanguageTrainer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LanguageTrainer.Models.UserWord", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WordId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "WordId");

                    b.HasIndex("WordId");

                    b.ToTable("UserWords");
                });

            modelBuilder.Entity("LanguageTrainer.Models.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("English")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Polish")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("LanguageTrainer.Models.WordCategory", b =>
                {
                    b.Property<int>("WordId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("WordId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("WordCategories");
                });

            modelBuilder.Entity("LanguageTrainer.Models.WordDifficulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WordId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.ToTable("WordDifficulties");
                });

            modelBuilder.Entity("LanguageTrainer.Models.UserWord", b =>
                {
                    b.HasOne("LanguageTrainer.Models.User", "User")
                        .WithMany("UserWords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanguageTrainer.Models.Word", "Word")
                        .WithMany("UserWords")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("LanguageTrainer.Models.WordCategory", b =>
                {
                    b.HasOne("LanguageTrainer.Models.Category", "Category")
                        .WithMany("WordCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanguageTrainer.Models.Word", "Word")
                        .WithMany("WordCategories")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("LanguageTrainer.Models.WordDifficulty", b =>
                {
                    b.HasOne("LanguageTrainer.Models.Word", "Word")
                        .WithMany("WordDifficulties")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("LanguageTrainer.Models.Category", b =>
                {
                    b.Navigation("WordCategories");
                });

            modelBuilder.Entity("LanguageTrainer.Models.User", b =>
                {
                    b.Navigation("UserWords");
                });

            modelBuilder.Entity("LanguageTrainer.Models.Word", b =>
                {
                    b.Navigation("UserWords");

                    b.Navigation("WordCategories");

                    b.Navigation("WordDifficulties");
                });
#pragma warning restore 612, 618
        }
    }
}
