using Desafio02;

Retangulo retangulo = new Retangulo();
retangulo.Largura = 6;
retangulo.Altura = 8;

Console.WriteLine($"Características do retângulo: \n" +
    $"\nLargura: {retangulo.Largura}\n" +
    $"Altura: {retangulo.Altura}\n" +
    $"Área: {retangulo.CalcularArea()}\n" +
    $"Perímetro:  {retangulo.CalcularPerimetro()}");