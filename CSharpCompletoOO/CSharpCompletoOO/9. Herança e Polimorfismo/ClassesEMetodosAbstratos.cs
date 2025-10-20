using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._9._Herança_e_Polimorfismo {

    public enum CorEnum {
        Preto = 0,
        Azul = 1,
        Vermelho = 2
    };

    public abstract class Forma {
        public CorEnum Cor {  get; set; }

        public Forma() { }

        public Forma(CorEnum cor) {
            Cor = cor;
        }

        public abstract double Area();

    }

    public class Retangulo : Forma {
        public double Largura {  get; set; }
        public double Altura{  get; set; }

        public Retangulo(CorEnum cor,  double largura, double altura)
            : base(cor) {
            Largura = largura;
            Altura = altura;
        }

        public override double Area() {
            return Largura * Altura;
        }
    }

    public class Circulo : Forma {
        public double Raio { get; set; }

        public Circulo(CorEnum cor, double raio)
            : base(cor) {
            Raio = raio;
        }

        public override double Area() {
            return Math.PI * Math.Pow(Raio, 2);
        }
    }
        
    internal class ClassesEMetodosAbstratos {
        public static void Main(string[] args) {
            // Exercício:
            // Fazer um programa para ler os dados de N figuras e depois mostrar as áreas destas figuras
            // na mesma ordem em que foram digitadas.

            Console.Write("Entre com o número de formas: ");
            int numFormas = int.Parse(Console.ReadLine());

            List<Forma> formas = new List<Forma>();

            for (int i = 0; i < numFormas; i++) {
                Console.WriteLine("\nDados da primeira forma: ");
                Console.Write("Retângulo ou círculo (R/C): ");
                char rectCirc = char.Parse(Console.ReadLine());
                Console.Write("Cor (preto/azul/vermelho: ");
                CorEnum cor = (CorEnum)Enum.Parse(typeof(CorEnum), Console.ReadLine());
                if (rectCirc == 'r' || rectCirc == 'R') {
                    Console.Write("Largura: ");
                    double largura = double.Parse(Console.ReadLine());
                    Console.Write("Altura: ");
                    double altura = double.Parse(Console.ReadLine());
                    Forma retangulo = new Retangulo(cor, largura, altura);
                    formas.Insert(i, retangulo);
                } else {
                    Console.Write("Raio: ");
                    double raio = double.Parse(Console.ReadLine());
                    Forma circulo = new Circulo(cor, raio);
                    formas.Insert(i, circulo);
                }
            }

            Console.WriteLine("\nÁreas das formas:");
            foreach (var forma in formas) {
                Console.WriteLine($"{forma.Area():F2}");
            }
        }
    }
}
