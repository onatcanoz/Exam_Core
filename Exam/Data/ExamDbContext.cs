using Exam.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Data
{
    public class ExamDbContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Paragraph> Paragraphs { get; set; }


        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paragraph>()
              .HasMany(x => x.Questions)
              .WithOne(x => x.Paragraph);


            modelBuilder.Entity<Paragraph>().HasData(
                new Paragraph
                {
                    Id = 1,
                    Title = "To Study the Next Earth, NASA May Need to Throw Some Shade to Throw Some Shade",
                    Content = "Hello, I don't know much about C#. I'm trying to pull data from the internet, but xpathin already has double quotes in it, so it doesn't detect it as text.Hello, I don't know much about C#. I'm trying to pull data from the internet, but xpathin already has double quotes in it, so it doesn't detect it as text.",
                    CreatedAt = DateTime.Now
                },
                 new Paragraph
                 {
                     Id = 2,
                     Title = "The Elizabeth Holmes Verdict and the Legal Loophole for 'Disruption",
                     Content = "WHEN YOU FIRST heard the story of the smoke-and-mirrors health care startup Theranos—whether through John Carreyrou’s Wall Street Journal exposés, his best-selling book Bad Blood, or the many podcasts and documentaries that followed—was your thought, “Gee, I hope at last there will be justice for the wealthy folks misled into investing a slice of their fortunes by Theranos’ charismatic founder, Elizabeth Holmes?",
                     CreatedAt = DateTime.Now
                 },
                  new Paragraph
                  {
                      Id = 3,
                      Title = "In Praise of Unglamorous American Invention",
                      Content = "Finding green energy when the winds are calm and the skies are cloudy has been a challenge. Storing it in giant concrete blocks could be the answer.",
                      CreatedAt = DateTime.Now
                  },
                   new Paragraph
                   {
                       Id = 4,
                       Title = "Hackers Are Exploiting a Flaw Microsoft Fixed 9 Years Ago",
                       Content = "Swiss forensic geneticists analyzed DNA recovered from postage stamps dating back to World War I and solved a century-old paternity puzzle.",
                       CreatedAt = DateTime.Now
                   },
                    new Paragraph
                    {
                        Id = 5,
                        Title = "The Best TV Shows You Missed in 2021—and How to Watch Them",
                        Content = "WITH SO MANY streaming networks creating so much original content, not to mention the imported series that are regularly streaming on Netflix and beyond, there aren’t enough hours in the day to keep up with every new (or new-to-you) TV series. But here are five shows you might have missed that are worth your time.",
                        CreatedAt = DateTime.Now
                    }
                );

            //modelBuilder.Entity<Question>().HasData(
            //   new Question
            //   {
            //       Id = 1,
            //       QuestionDescription = "To Study the Next Earth, NASA May Need to Throw Some Shade to Throw Some Shade",
            //       OptionA = "To Study the",
            //       OptionB = "Earth, NASA ",
            //       OptionC = " Need to Throw",
            //       OptionD = "e Shade to The",
            //       TrueOption = "B",
            //       ParagraphId = 1,
            //   },
            //    new Question
            //    {
            //        Id = 2,
            //        QuestionDescription = "Hello, I don't know much about C#. I'm trying to pull data from the internet,",
            //        OptionA = "I'm trying to pull",
            //        OptionB = "e Shade to The",
            //        OptionC = "NASA May Need to",
            //        OptionD = "much about C#",
            //        TrueOption = "C",
            //        ParagraphId = 1,
            //    },
            //    new Question
            //    {
            //        Id = 3,
            //        QuestionDescription = "To Study the Next Earth, NASA May Need to Throw Some Shade to Throw Some Shade",
            //        OptionA = "I'm trying to pull",
            //        OptionB = "e Shade to The",
            //        OptionC = "NASA May Need to",
            //        OptionD = "much about C#",
            //        TrueOption = "C",
            //        ParagraphId = 1,
            //    },
            //    new Question
            //    {
            //        Id = 4,
            //        QuestionDescription = "Hello, I don't know much about C#. I'm trying to pull data from the internet,",
            //        OptionA = "I'm trying to pull",
            //        OptionB = "e Shade to The",
            //        OptionC = "NASA May Need to",
            //        OptionD = "much about C#",
            //        TrueOption = "C",
            //        ParagraphId = 1,
            //    });
        }

    }
}
