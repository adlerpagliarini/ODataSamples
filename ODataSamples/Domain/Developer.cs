using ODataSamples.Domain.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ODataSamples.Domain
{
    public class Developer : Identity<Developer>
    {
        public string Name { get; set; }
        public DevType DevType { get; set; }
        private ICollection<TaskToDo> _tasksToDo { get; set; }
        public virtual IReadOnlyCollection<TaskToDo> TasksToDo { get { return _tasksToDo as Collection<TaskToDo>; } }

        public Developer()
        {
            _tasksToDo = new Collection<TaskToDo>();
        }

        public void AddItemToDo(TaskToDo todo)
        {
            var _todo = new TaskToDo()
            {
                Start = todo.Start,
                DeadLine = todo.DeadLine,
                Title = todo.Title,
                Status = todo.Status,
                Id = this.Id
            };
            _tasksToDo.Add(_todo);
        }
    }
}
