using ODataSamples.Domain;
using System;

namespace ODataSamples.Dtos
{
    public class TaskToDoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime DeadLine { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }

        public TaskToDoDto()
        {

        }

        public TaskToDoDto(int id, string title, DateTime start, DateTime deadLine, bool status, int userId)
        {
            Id = id;
            Title = title;
            Start = start;
            DeadLine = deadLine;
            Status = status;
            UserId = userId;
        }

        public static TaskToDoDto Map(TaskToDo domain) =>
            domain is null ? default : new TaskToDoDto(domain.Id, domain.Title, domain.Start, domain.DeadLine, domain.Status, domain.UserId);
    }
}
