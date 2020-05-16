using PearlsOfWisdom.Domain.Entities;
using PearlsOfWisdom.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace PearlsOfWisdom.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.PearlLists.Any())
            {
                context.PearlLists.Add(new PearlList
                {
                    Title = "Some title",
                    Items =
                    {
                        new PearlItem
                        {
                            Title = "Some pearl item",
                            Note = "Some note"
                        },
                        new PearlItem
                        {
                            Title = "Some other pearl item",
                            Note = "Some other note",
                        }
                    }
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
