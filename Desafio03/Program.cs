using Desafio03;

Titular titular = new("TRANSPORTES LTDA");

ContaBancaria contaBancaria1 = new(2589, titular);
contaBancaria1.Depositar((decimal)2555.60);
ContaBancaria contaBancaria2 = new(1688, titular);
contaBancaria2.Depositar((decimal)40000.40);
ContaBancaria contaBancaria3 = new(6423, titular);
contaBancaria3.Depositar((decimal)52000.00);

try
{
    titular.AdicionarContaBancaria(contaBancaria1);
    titular.AdicionarContaBancaria(contaBancaria2);
    titular.AdicionarContaBancaria(contaBancaria3);
}catch(ArgumentException e)
{
    Console.WriteLine(e.Message);
}


titular.ExibirRelatorioContasAgregadas();
Console.WriteLine("");
contaBancaria1.Sacar(3000);
contaBancaria2.Sacar(80000);
titular.ExibirContasNegativadas();

try
{
    contaBancaria3.RealizarTransferencia(5000, contaBancaria1);
    contaBancaria3.RealizarTransferencia(10000, contaBancaria2);
}catch(ArgumentException e)
{
    Console.WriteLine(e.Message);
}

contaBancaria1.ExibirExtrato(ExtratoPeriodo.Mensal);
Console.WriteLine("");
contaBancaria2.ExibirExtrato(ExtratoPeriodo.Mensal);
Console.WriteLine("");
contaBancaria3.ExibirExtrato(ExtratoPeriodo.Mensal);
Console.WriteLine("");
titular.ExibirContasNegativadas();