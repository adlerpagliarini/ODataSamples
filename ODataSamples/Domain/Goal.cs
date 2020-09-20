using FluentValidation;

namespace ODataSamples.Domain
{
    public class Goal : Identity<Goal>
    {
        public Goal(string title, int userId)
        {
            Title = title;
            UserId = userId;
        }

        protected Goal() { }
        public string Title { get; protected set; }
        public int UserId { get; protected set; }

        public override bool IsValid()
        {
            Validator.RuleFor(e => e.Title).NotEmpty();
            return Validator.Validate(this).IsValid;
        }
    }
}
