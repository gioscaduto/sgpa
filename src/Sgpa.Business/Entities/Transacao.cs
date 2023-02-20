using Sgpa.Business.Extensions;

namespace Sgpa.Business.Entities
{
    public class Transacao : Entidade
    {
        public Transacao()
        {
            DataTransacao = DateTime.Now;
        }

        public Guid TenantId { get; private set; }
        public Guid EmpresaId { get; private set; }
        public string Historico { get; private set; }
        public DateTime DataTransacao { get; private set; }

        private List<Operacao> _operacoes;
        public IReadOnlyList<Operacao> Operacoes => _operacoes;

        public void AdicionarOperacoes(IEnumerable<Operacao> operacoes)
        {
            if (operacoes == null || operacoes.Count() < 2)
            {
                throw new ArgumentException("Uma transação deverá ter no mínimo 2 operações");
            }

            if (operacoes.SomaDebito() != operacoes.SomaCredito())
            {
                throw new ArgumentException("A soma das operações de débito deve ser igual a soma das operações de crédito");
            }

            _operacoes = operacoes?.ToList();
        }
    }
}
