using Desafio01;

Carro carro = new Carro();
carro.Marca = "Chevrolet";
carro.Modelo = "Onix";
carro.Ano = 2022;

Pessoa pessoa = new Pessoa();
pessoa.Nome = "Laura";
pessoa.Idade = 31;
pessoa.Profissao = "Engenheira de Software";
pessoa.Carro =  carro;

Console.WriteLine($"Dados da pessoa: \n" +
    $"\nNome: {pessoa.Nome}\n" +
    $"Idade: {pessoa.Idade}\n" +
    $"Profissao: {pessoa.Profissao}\n" +
    $"Carro: {pessoa.Carro.Marca} {pessoa.Carro.Modelo} ({pessoa.Carro.Ano})");