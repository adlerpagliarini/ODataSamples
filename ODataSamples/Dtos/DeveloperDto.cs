using ODataSamples.Domain;
using ODataSamples.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ODataSamples.Dtos
{
    public class DeveloperDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DevType DevType { get; set; }
        public GoalDto Goal { get; set; }
        public List<TaskToDoDto> TasksToDo { get; set; }

        public static Func<Developer, DeveloperDto> MapDomainToDto = (developer) => Map(developer);

        public DeveloperDto()
        {
            TasksToDo = new List<TaskToDoDto>();
        }

        public DeveloperDto(int id, string name, DevType devType, GoalDto goal, List<TaskToDoDto> tasksToDo)
        {
            Id = id;
            Name = name;
            DevType = devType;
            Goal = goal;
            TasksToDo = tasksToDo;
        }

        public static DeveloperDto Map(Developer domain) => domain is null ? default :
            new DeveloperDto(domain.Id, domain.Name, domain.DevType, GoalDto.Map(domain.Goal), domain.TasksToDo.Select(e => TaskToDoDto.Map(e)).ToList());

    }
}
