using Sgpa.Business.Entities;
using Sgpa.Business.ValueObjects;

namespace Sgpa.Business.Extensions
{
    public static class OperacoesExtensions
    {
        public static decimal? SomaDebito(this IEnumerable<Operacao> operacoes) =>
            operacoes?.Where(o => o.TipoOperacao == TipoOperacao.Debito)?.Sum(o => o.Valor);

        public static decimal? SomaCredito(this IEnumerable<Operacao> operacoes) =>
            operacoes?.Where(o => o.TipoOperacao == TipoOperacao.Credito)?.Sum(o => o.Valor);
    }
}
