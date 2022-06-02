using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
namespace SLCTestApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleQuestion> ScheduleQuestions { get; set; }
        public DbSet<IdentityUser> AspNetUsers { get; set; }
        public DbSet<IdentityUserRole<string>> AspNetUserRoles { get; set; }
        public DbSet<IdentityRole> AspNetRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var splitStringConverter = new ValueConverter<List<string>, string>(
                v => string.Join("`", v),
                v => new List<string>(v.Split(new[] { '`' }))
            );

            builder.Entity<Question>()
                .Property(nameof(Question.Choices))
                .HasConversion(splitStringConverter);

            builder.Entity<ScheduleQuestion>().HasKey(scheduleQuestion => new { scheduleQuestion.ScheduleId, scheduleQuestion.QuestionId });
            
            builder.Entity<Schedule>().HasKey(schedule => schedule.Id);


            builder.Entity<Answer>().HasKey(scheduleQuestion => new { scheduleQuestion.QuestionId, scheduleQuestion.UserId, scheduleQuestion.ScheduleId });



            SeedRoles(builder);
            SeedUsers(builder);
            SeedUserRoles(builder);
            
            SeedQuestions(builder);
            SeedSchedules(builder);
            SeedScheduleQuestions(builder);
            SeedAnswers(builder);

        }
        private void SeedUsers(ModelBuilder builder)
        {
            IdentityUser identityUser = new IdentityUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@gmail.com",
                NormalizedUserName= "admin@gmail.com".ToUpper(),
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                EmailConfirmed = true
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            var hashed= passwordHasher.HashPassword(identityUser, "admin");
            identityUser.PasswordHash = hashed;

            List<IdentityUser> identityUsers = new List<IdentityUser>
            {
                new IdentityUser()
                {
                    Id = "b74ddd14-6340-4840-95c2-db12554843e1",
                        UserName = "jp@gmail.com",
                    Email = "jp@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",                EmailConfirmed = true

                },
                new IdentityUser()
                {
                    Id = "b74ddd14-6340-4840-95c2-db12554843e2",
                    UserName = "ga@gmail.com",
                    Email = "ga@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",                EmailConfirmed = true

                },
                new IdentityUser()
                {
                    Id = "b74ddd14-6340-4840-95c2-db12554843a5",
                    UserName = "vn@gmail.com",
                    Email = "vn@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",                EmailConfirmed = true


                },
                new IdentityUser()
                {
                    Id = "b74ddd14-6340-4840-95c2-db12554823e9",
                    UserName = "ll@gmail.com",
                    Email = "ll@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",                EmailConfirmed = true

                },
                new IdentityUser()
                {
                    Id = "b74ddd14-6340-4840-95c2-db12555413e5",
                    UserName = "br@gmail.com",
                    Email = "br@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",                EmailConfirmed = true

                },
                new IdentityUser()
                {
                    Id = "b74ddd14-6340-4840-95c2-db12554823f5",
                    UserName = "cc@gmail.com",
                    Email = "cc@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",                EmailConfirmed = true

                },
                new IdentityUser()
                {
                    Id = "b74ddd23-6340-4840-95c2-db12554843e5",
                    UserName = "tc@gmail.com",
                    Email = "tc@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",                EmailConfirmed = true


                },
                new IdentityUser()
                {
                    Id = "b74ddd14-6340-4840-95c2-db12554543r5",
                    UserName = "st@gmail.com",
                    Email = "st@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",                EmailConfirmed = true


                },
            };
            foreach (var user in identityUsers)
            {

                passwordHasher = new PasswordHasher<IdentityUser>();
                var hashedLoop = passwordHasher.HashPassword(user, "pass99");
                user.PasswordHash = hashedLoop;
                user.NormalizedEmail = user.Email.ToUpper();
                user.NormalizedUserName = user.UserName.ToUpper();
                
            }

            identityUsers.Add(identityUser);

            builder.Entity<IdentityUser>().HasData(identityUsers);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "cff8b0b4-d86f-4457-a813-b552ad43c959"},
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Participant", NormalizedName = "PARTICIPANT" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { 
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", 
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5" 
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e1"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e2"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843a5"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    UserId = "b74ddd14-6340-4840-95c2-db12554823e9"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    UserId = "b74ddd14-6340-4840-95c2-db12555413e5"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    UserId = "b74ddd14-6340-4840-95c2-db12554823f5"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    UserId = "b74ddd23-6340-4840-95c2-db12554843e5"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    UserId = "b74ddd14-6340-4840-95c2-db12554543r5"
                }
                );

        }


        private void SeedQuestions(ModelBuilder builder)
        {
            builder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Body = "This is an essay.",
                    QuestionType = Question.Essay

                }, new Question
                {
                    Id = 2,
                    Choices = GetChoicesBasedOnType(Question.TrueOrFalse),
                    AnswerIndex = 1,
                    Body = "The answer is false.",
                    QuestionType = Question.TrueOrFalse,

                }, new Question
                {
                    Id = 3,
                    Body = "The Answer is choice number 6",
                    QuestionType = Question.ChooseOne,

                    Choices = GetChoicesBasedOnType(Question.ChooseOne),
                    AnswerIndex = 6


                }, new Question
                {
                    Id = 4,
                    Body = "The answer is C.",
                    QuestionType = Question.MultipleChoice,
                    Choices = GetChoicesBasedOnType(Question.MultipleChoice),
                    AnswerIndex = 3
                }, new Question
                {
                    Id = 5,
                    Body = "Upload a file.",
                    QuestionType = Question.SubmitFile,

                },new Question
                {
                    Id = 6,
                    Body = "The answer is true.",
                    QuestionType = Question.TrueOrFalse,
                    Choices = GetChoicesBasedOnType(Question.TrueOrFalse),
                    AnswerIndex = 2

                }
                );

        }

        private List<String> GetChoicesBasedOnType(string questionType)
        {

            if(questionType== Question.TrueOrFalse)
            {
                return new List<string> { "True", "False" };
            }
            else if (questionType == Question.MultipleChoice)
            {
                return new List<string> { "a. Answer A", "b. Answer B", "C. Answer C", "d. Answer D" };
            }
            else if (questionType == Question.ChooseOne)
            {
                return new List<string> {
                    "Choice 1",
                    "Choice 2",
                    "Choice 3",
                    "Choice 4",
                    "Choice 5",
                    "Choice 6",
                };
            }
            return new List<string> {  };    
        }

        private void SeedAnswers(ModelBuilder builder)
        {
            builder.Entity<Answer>().HasData(
                new Answer
                {
                    ScheduleId = 1,
                    QuestionId = 1,
                    AnswerString = "1",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e1"
                }, new Answer
                {
                    ScheduleId = 1,
                    QuestionId = 2,
                    AnswerString = "1",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e1"
                }, new Answer
                {
                    ScheduleId = 1,
                    QuestionId = 3,
                    AnswerString = "1",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e1"
                }
            );
        }


        private void SeedSchedules(ModelBuilder builder)
        {
            builder.Entity<Schedule>().HasData(
              new Schedule
              {
                  Id = 1, 
                  Title = "NAR Early Schedule",
                  Description = "Schedule to determine if u are worthy",
                  StartTime = DateTime.Now.AddHours(5),
                  EndTime = DateTime.Now,
              }
            );
        }

        private void SeedScheduleQuestions(ModelBuilder builder)
        {
            builder.Entity<ScheduleQuestion>().HasData(
                new ScheduleQuestion
                {
                    
                    ScheduleId = 1,
                    QuestionId = 1
                },
                new ScheduleQuestion
                {
                    ScheduleId = 1,
                    QuestionId = 2
                },
                new ScheduleQuestion
                {
                    ScheduleId = 1,
                    QuestionId = 3
                },
                new ScheduleQuestion
                {
                    ScheduleId = 1,
                    QuestionId = 5
                }
            );
        }

    }
}