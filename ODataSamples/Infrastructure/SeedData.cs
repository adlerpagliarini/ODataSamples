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

                var goalOData = new Goal("Complete o Data", 0);
                var goalValidation = new Goal("Complete Validation", 0);

                var frontendTask = new TaskToDo("Dev HTML page", DateTime.Now, DateTime.Now.AddDays(15), false, 0);
                var backendTask = new TaskToDo("Dev CSharp code", DateTime.Now, DateTime.Now.AddDays(15), false, 0);

                var frontend = new Developer("Adler Pagliarini", DevType.FrontEnd);
                frontend.AddItemToDo(frontendTask);
                frontend.SetGoal(goalOData);

                var backend = new Developer("Pagliarini Nascimento", DevType.BackEnd);
                backend.AddItemToDo(backendTask);
                backend.SetGoal(goalOData);

                var fullstack = new Developer("Adler Nascimento", DevType.Fullstack);
                fullstack.AddItemToDo(frontendTask);
                fullstack.AddItemToDo(backendTask);
                fullstack.SetGoal(goalValidation);

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
