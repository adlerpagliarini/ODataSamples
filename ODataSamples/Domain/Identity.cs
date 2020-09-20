namespace ODataSamples.Domain
{
    public abstract class Identity<TEntity>
        where TEntity : Identity<TEntity>
    {
        protected Identity() {
            Validator = new IdentityValidator<TEntity>();
        }
        public int Id { get; protected set; }
        protected IdentityValidator<TEntity> Validator { get; private set; }
        public virtual bool IsValid() => true;
    }
}
