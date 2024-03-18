namespace Desafio03
{
    public class Titular
    {
        public Titular(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
        private List<ContaBancaria> ContasBancarias { get; } = new List<ContaBancaria>();

        public void ExibirRelatorioContasAgregadas()
        {
            Console.WriteLine($"--------------------- {Nome} ---------------------" +
                $"\nRelatório de contas agregadas ---------- {DateTime.Now}\n");
            foreach(ContaBancaria contaBancaria in ContasBancarias)
            {
                Console.WriteLine($"Conta: {contaBancaria.NumeroConta} ---------- Saldo: {contaBancaria.GetSaldo()}");
            }
            Console.WriteLine($"\nSaldo Total: {ContasBancarias.Sum(conta => conta.GetSaldo())}");
        }

        public void AdicionarContaBancaria(ContaBancaria contaBancaria)
        {
            if(contaBancaria.Titular.Nome == Nome)
            {
                ContasBancarias.Add( contaBancaria );
            }
            else
            {
                throw new ArgumentException("Conta não pertence a este titular.");
            }
        }

        public void ExibirContasNegativadas()
        {
            List<ContaBancaria> contasNegativadas = ContasBancarias.FindAll((contaBancaria) => contaBancaria.Negativada);

            Console.WriteLine($"--------------------- {Nome} ---------------------" +
                $"\nContas negativadas ---------- {DateTime.Now}\n");
            foreach(ContaBancaria contaNegativada in contasNegativadas)
            {
                Console.WriteLine($"Conta: {contaNegativada.NumeroConta} ---------- Saldo: {contaNegativada.GetSaldo()}");
            }
        }
    }
}