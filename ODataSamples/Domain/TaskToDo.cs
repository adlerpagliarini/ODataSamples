using System;

namespace ODataSamples.Domain
{
    public class TaskToDo : Identity<TaskToDo>
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime DeadLine { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
    }
}
