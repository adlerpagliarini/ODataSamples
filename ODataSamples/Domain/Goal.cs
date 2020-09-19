using FluentValidation;
using System;

namespace ODataSamples.Domain
{
    public class Goal : Identity<Goal>
    {
        public string Title { get; set; }
        public int UserId { get; set; }

        public override bool IsValid()
        {
            Validator.RuleFor(e => e.Title).NotEmpty();
            return Validator.Validate(this).IsValid;
        }
    }
}
