namespace Desafio03
{
    public record Operacao
    {
        public Operacao(OperacaoTipo tipo, decimal valor, ContaBancaria contaOrigem, ContaBancaria? contaDestino  = null)
        {
            Tipo = tipo;
            Valor = valor;
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
        }

        public OperacaoTipo Tipo { get; } 
        public decimal Valor { get; }
        public ContaBancaria ContaOrigem { get; }
        public ContaBancaria? ContaDestino { get; }
        public DateTime Data { get; } = DateTime.Now;


    }
}
