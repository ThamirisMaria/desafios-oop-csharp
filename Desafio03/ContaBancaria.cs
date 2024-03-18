namespace Desafio03
{
    public class ContaBancaria
    {
        public ContaBancaria(int numeroConta, Titular titular)
        {
            NumeroConta = numeroConta;
            Titular = titular;
        }

        public int NumeroConta { get; }
        public Titular Titular { get; }
        public List<Operacao> Operacoes { get; set; } = [];
        public bool Negativada { get; private set; } = false;

        public void Sacar(decimal valor)
        {
            Operacoes.Add(new(OperacaoTipo.Saque, valor, this));
            AtualizarSituacao();
        }

        public void Depositar(decimal valor)
        {
            Operacoes.Add(new(OperacaoTipo.Deposito, valor, this));
            AtualizarSituacao();
        }

        public void RealizarTransferencia(decimal valor, ContaBancaria contaDestino)
        {
            if(valor <= 0)
            {
                throw new ArgumentException("Não foi possível realizar a transferência. Valor inválido!");
            }else if (GetSaldo() - valor < 0)
            {
                throw new ArgumentException("Não foi possível realizar a transferência. Saldo insuficiente!");
            }else if(contaDestino.NumeroConta == this.NumeroConta)
            {
                throw new ArgumentException("Não foi possível realizar a transferência. Conta de destino não pode ser igual a conta de origem!");
            }
            Operacao transferencia = new(OperacaoTipo.Transferencia, valor, this, contaDestino);
            contaDestino.ReceberTransferencia(transferencia);
            Operacoes.Add(transferencia);
        }

        private void ReceberTransferencia(Operacao transferencia)
        {
            Operacoes.Add(transferencia);
            AtualizarSituacao();
        }

        public void ExibirExtrato(ExtratoPeriodo extratoPeriodo)
        {
            DateTime dataInicial = DateTime.Now.Date.AddDays(-(double)extratoPeriodo);
            DateTime dataFinal = DateTime.Now;

            Console.WriteLine($"--------------------- Extrato conta nº{NumeroConta} ---------------------" +
                $"\n ---------- Período: {dataInicial} à {dataFinal} ---------- \n");

            foreach(Operacao operacao in Operacoes)
            {
                if(operacao.Data >= dataInicial && operacao.Data <= dataFinal)
                {
                    switch (operacao.Tipo)
                    {
                        case OperacaoTipo.Saque:
                            Console.WriteLine($"{operacao.Tipo}: -R${operacao.Valor} ---------- {operacao.Data}");
                            break;
                        case OperacaoTipo.Deposito:
                            Console.WriteLine($"{operacao.Tipo}: +R${operacao.Valor} ---------- {operacao.Data}");
                            break;
                        case OperacaoTipo.Transferencia:
                            if(operacao.ContaDestino == this)
                            {
                                Console.WriteLine($"{operacao.Tipo} Recebida de {operacao.ContaOrigem.Titular.Nome}: " +
                                    $"+R${operacao.Valor} ---------- {operacao.Data}");
                            }else if(operacao.ContaOrigem == this)
                            {
                                Console.WriteLine($"{operacao.Tipo} Efetuada para {operacao.ContaDestino!.Titular.Nome}: " +
                                    $"-R${operacao.Valor} ---------- {operacao.Data}");
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine($"Saldo atual: R${GetSaldo()}");

        }

        public decimal GetSaldo()
        {
            decimal entradas = GetDepositos().Sum(deposito => deposito.Valor) + GetTransferenciasRecebidas().Sum(transferencia => transferencia.Valor);
            decimal saidas = GetSaques().Sum(saque => saque.Valor) + GetTransferenciasEfetuadas().Sum(transferencia => transferencia.Valor);

            decimal saldo = entradas - saidas;
            return saldo;
        }

        public List<Operacao> GetDepositos()
        {
            return Operacoes.FindAll(operacao => operacao.Tipo == OperacaoTipo.Deposito);
        }

        public List<Operacao> GetSaques()
        {
            return Operacoes.FindAll(operacao => operacao.Tipo == OperacaoTipo.Saque);
        }

        public List<Operacao> GetTransferenciasRecebidas()
        {
            return Operacoes.FindAll(operacao => operacao.Tipo == OperacaoTipo.Transferencia && operacao.ContaDestino == this);
        }

        public List<Operacao> GetTransferenciasEfetuadas()
        {
            return Operacoes.FindAll(operacao => operacao.Tipo == OperacaoTipo.Transferencia && operacao.ContaOrigem == this);
        }

        private void AtualizarSituacao()
        {
            if (GetSaldo() < 0)
            {
                Negativada = true;
            }
            else if(GetSaldo() >= 0)
            {
                Negativada = false;
            }
        }
    }
}
