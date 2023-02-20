namespace Sgpa.Business.Entities
{
    public class PlanoDeConta : Entidade
    {
        public Guid TenantId { get; private set; }
        public Guid EmpresaId { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public IReadOnlyList<Conta> Contas { get; private set; }
    }
}
