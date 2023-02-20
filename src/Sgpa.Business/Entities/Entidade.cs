namespace Sgpa.Business.Entities
{
    public abstract class Entidade
    {
        public Guid Id { get; private set; }

        public Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
