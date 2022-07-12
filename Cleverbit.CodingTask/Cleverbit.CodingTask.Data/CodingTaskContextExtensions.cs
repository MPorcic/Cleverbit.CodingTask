using Cleverbit.CodingTask.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data
{
    public static class CodingTaskContextExtensions
    {
        public static async Task Initialize(this CodingTaskContext context, IHashService hashService)
        {
            await context.Database.EnsureCreatedAsync();

            var currentUsers = await context.Users.ToListAsync();

            bool anyNewUser = false;

            if (!currentUsers.Any(u => u.UserName == "User1"))
            {
                context.Users.Add(new Models.User
                {
                    UserName = "User1",
                    Password = await hashService.HashText("Password1")
                });

                anyNewUser = true;
            }

            if (!currentUsers.Any(u => u.UserName == "User2"))
            {
                context.Users.Add(new Models.User
                {
                    UserName = "User2",
                    Password = await hashService.HashText("Password2")
                });

                anyNewUser = true;
            }

            if (!currentUsers.Any(u => u.UserName == "User3"))
            {
                context.Users.Add(new Models.User
                {
                    UserName = "User3",
                    Password = await hashService.HashText("Password3")
                });

                anyNewUser = true;
            }

            if (!currentUsers.Any(u => u.UserName == "User4"))
            {
                context.Users.Add(new Models.User
                {
                    UserName = "User4",
                    Password = await hashService.HashText("Password4")
                });

                anyNewUser = true;
            }

            if (anyNewUser)
            {
                await context.SaveChangesAsync(); 
            }

            //seed for matches
            var currentMatches = await context.Matches.ToListAsync();
            if(currentMatches.Any())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Match");
            }
            context.Matches.Add(new Models.Match
            {
                Name="Match1",
                ExpiryDate = DateTime.Now.AddMinutes(1)
            });
            context.Matches.Add(new Models.Match
            {
                Name = "Match2",
                ExpiryDate = DateTime.Now.AddMinutes(2)
            });
            context.Matches.Add(new Models.Match
            {
                Name = "Match3",
                ExpiryDate = DateTime.Now.AddMinutes(3)
            });
            await context.SaveChangesAsync();
        }
    }
}
