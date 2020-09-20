using System;

namespace ODataSamples.Domain
{
    public class TaskToDo : Identity<TaskToDo>
    {
        public TaskToDo(string title, DateTime start, DateTime deadLine, bool status, int userId)
        {
            Title = title;
            Start = start;
            DeadLine = deadLine;
            Status = status;
            UserId = userId;
        }

        protected TaskToDo() { }

        public string Title { get; protected set; }
        public DateTime Start { get; protected set; }
        public DateTime DeadLine { get; protected set; }
        public bool Status { get; protected set; }
        public int UserId { get; protected set; }
    }
}
