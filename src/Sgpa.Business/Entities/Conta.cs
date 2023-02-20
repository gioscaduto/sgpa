namespace Sgpa.Business.Entities
{
    public class Conta : Entidade
    {
        public Guid TenantId { get; private set; }
        public Guid EmpresaId { get; private set; }
        public Guid PlanoDeContaId { get; private set; }
        public string Descricao { get; private set; }
        public string Moeda { get; private set; }

        /// <summary>
        /// Se a conta é do tipo Sintética, a conta é um agrupamento de contas analíticas ou outras contas sintéticas
        /// Somente são permitidas operações com contas analíticas, de modo que contas sintéticas (agrupamentode várias contas Análíticas ou outros subgrupos)
        /// server apenas para compor o somatório do saldo das contas analíticas ou subgrupos.
        /// </summary>
        public bool IsSintetica { get; private set; }
        public Guid? ContaPaiId { get; private set; }

        public Conta ContaPai { get; private set; }
        public IReadOnlyList<Conta> ContasFilhas { get; private set; }
        public IReadOnlyList<Operacao> Operacoes { get; private set; }

        public void AdicionarContaPai(Conta conta)
        {
            if(conta.EmpresaId != EmpresaId)
            {
                throw new ArgumentException("As contas devem pertencer a mesma empresa");
            }

            ContaPai = conta;
            ContaPaiId = conta.Id;
        }
    }
}
