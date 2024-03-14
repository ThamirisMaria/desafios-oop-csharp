namespace Desafio02
{
    public class Retangulo
    {
        public double Largura { get; set; }
        public double Altura { get; set; }

        public double CalcularArea() => Largura * Altura;

        public double CalcularPerimetro() => 2 * Largura + 2 * Altura;
    }
}
