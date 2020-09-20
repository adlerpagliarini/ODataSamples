using ODataSamples.Domain.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ODataSamples.Domain
{
    public class Developer : Identity<Developer>
    {
        public Developer(string name, DevType devType)
        {
            Name = name;
            DevType = devType;
            _tasksToDo = new Collection<TaskToDo>();
        }

        public string Name { get; protected set; }
        public DevType DevType { get; protected set; }
        public Goal Goal { get; protected set; }
        private ICollection<TaskToDo> _tasksToDo { get; set; }
        public virtual IReadOnlyCollection<TaskToDo> TasksToDo { get { return _tasksToDo as Collection<TaskToDo>; } }

        protected Developer()
        {
            _tasksToDo = new Collection<TaskToDo>();
        }

        public void AddItemToDo(TaskToDo todo)
        {
            var _todo = new TaskToDo(todo.Title, todo.Start, todo.DeadLine, todo.Status, todo.UserId);
            _tasksToDo.Add(_todo);
        }

        public void SetGoal(Goal goal)
        {
            var _goal = new Goal(goal.Title, goal.UserId);
            Goal = _goal;
        }
    }
}
