using MyFacultyWebApplication.Models;

namespace MyFacultyWebApplication
{
    public class StatusInitializer
    {

        public static async Task InitializeAsync(MyFacultyDbContext context)
        {
            var statuses = new Status[]
            {
                new Status { Name = "Active" },
                new Status { Name = "Inactive" },
                new Status { Name = "Academic leave" },
                new Status { Name = "Academic mobility" },
                new Status { Name = "Graduated" },
                new Status { Name = "Expelled" }
            };
            foreach (Status status in statuses)
            {
                if (context.Statuses.First(s => s.Name == status.Name) == null)
                    continue;
                await context.Statuses.AddAsync(status);
            }
            await context.SaveChangesAsync();
        }
    }
}
