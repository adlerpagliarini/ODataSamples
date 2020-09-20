namespace ODataSamples.Domain
{
    public class GoalDto
    {
        public GoalDto(string title)
        {
            Title = title;
        }

        public string Title { get; set; }

        public static GoalDto Map(Goal domain) => domain is null ? default :
            new GoalDto(domain.Title);
    }
}
