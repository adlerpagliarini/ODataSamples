using ODataSamples.Domain;
using ODataSamples.Domain.Enums;
using System;
using System.Linq;

namespace ODataSamples.Infrastructure
{
    public static class SeedData
    {
        public static void SeedDatabase(DatabaseContext context)
        {
            try
            {
                if (context.Developer.Any()) return;

                var frontendTask = new TaskToDo()
                {
                    Title = "Dev HTML page",
                    Start = DateTime.Now,
                    DeadLine = DateTime.Now.AddDays(15),
                    Status = false
                };

                var backendTask = new TaskToDo()
                {
                    Title = "Dev C# code",
                    Start = DateTime.Now,
                    DeadLine = DateTime.Now.AddDays(15),
                    Status = false
                };

                var frontend = new Developer()
                {
                    Name = "Adler Pagliarini",
                    DevType = DevType.FrontEnd
                };
                frontend.AddItemToDo(frontendTask);

                var backend = new Developer()
                {
                    Name = "Pagliarini Nascimento",
                    DevType = DevType.BackEnd
                };
                backend.AddItemToDo(backendTask);

                var fullstack = new Developer()
                {
                    Name = "Adler Nascimento",
                    DevType = DevType.Fullstack
                };
                fullstack.AddItemToDo(frontendTask);
                fullstack.AddItemToDo(backendTask);

                context.Developer.AddRange(frontend, backend, fullstack);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: {ex.Message}");
            }
        }

    }
}
