using FluentValidation;

namespace ODataSamples.Domain
{
    public class IdentityValidator<TEntity>: AbstractValidator<TEntity> 
        where TEntity : Identity<TEntity>
    {

    }
}
