using Sgpa.Business.ValueObjects;

namespace Sgpa.Business.Entities
{
    public class Operacao : Entidade
    {
        public Operacao()
        {
            DataOperacao = DateTime.Now;
        }

        public Guid TenantId { get; private set; }
        public Guid EmpresaId { get; private set; }
        public Guid TransacaoId { get; private set; }
        public Guid ContaId { get; private set; }
        public int NumeroLinha { get; private set; }
        public decimal Valor { get; private set; }
        public string CentroCusto { get; private set; }
        public TipoOperacao TipoOperacao { get; private set; }
        public DateTime DataOperacao { get; private set; }
    }
}
