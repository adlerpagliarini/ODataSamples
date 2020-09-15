using FluentValidation;

namespace ODataSamples.Domain
{
    public abstract class Identity<TEntity> : AbstractValidator<TEntity>
    {
        protected Identity() { }
        public int Id { get; set; }
        // public bool CascadeMode { get; set; }
    }
}
