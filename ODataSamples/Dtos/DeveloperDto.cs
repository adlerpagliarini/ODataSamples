using ODataSamples.Domain;
using ODataSamples.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ODataSamples.Dtos
{
    public class DeveloperDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DevType DevType { get; set; }
        public List<TaskToDoDto> TasksToDo { get; set; }        

        public DeveloperDto()
        {
            TasksToDo = new List<TaskToDoDto>();
        }

        public DeveloperDto(int id, string name, DevType devType, List<TaskToDoDto> tasksToDo)
        {
            Id = id;
            Name = name;
            DevType = devType;
            TasksToDo = tasksToDo;
        }

        public static DeveloperDto Map(Developer domain) => domain is null ? default :
            new DeveloperDto(domain.Id, domain.Name, domain.DevType, domain.TasksToDo.Select(e => TaskToDoDto.Map(e)).ToList());

    }
}
