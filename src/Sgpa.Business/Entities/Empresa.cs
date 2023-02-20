namespace Sgpa.Business.Entities
{
    public class Empresa : Entidade
    {
        public Empresa(Guid tenantId, string nome, bool ativo)
        {
            TenantId = tenantId;
            Nome = nome;
            Ativo = ativo;
        }

        public Guid TenantId { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public IReadOnlyList<Operacao> Operacoes { get; private set; }
        public IReadOnlyList<PlanoDeConta> PlanosDeConta { get; private set; }
        public IReadOnlyList<Conta> Contas { get; private set; }
    }
}
