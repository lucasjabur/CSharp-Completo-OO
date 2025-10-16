using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._4._Básico_de_OO {

    public class Retangulo() {
        public double Largura;
        public double Altura;

        public double Area() {
            return Largura * Altura;
        }

        public double Perimetro() {
            return 2 * Largura + 2 * Altura;
        }

        public double Diagonal() {
            return Math.Sqrt(Math.Pow(Largura,2) + Math.Pow(Altura,2));
        }
    }

    public class OutroFuncionario {
        public string Nome;
        public double SalarioBruto;
        public double ImpostoEmDinheiro;
    
        public double SalarioLiquido() {
            return SalarioBruto - ImpostoEmDinheiro;
        }

        public void AumentarSalario(double porcentagem) {
            if (porcentagem < 0) {
                Console.WriteLine("Porcentagem inválida!");
                return;
            } else if (porcentagem == 0) {
                Console.WriteLine("Salário inalterado! Nenhum aumento especificado.");
                return;
            }

            SalarioBruto += (SalarioBruto * (porcentagem/100));
        }

        public override string ToString() {
            return $"Dados do funcionário '{Nome}':\n" +
                   $"   Salário Líquido: R$ {SalarioLiquido():F2}";
        }
    }

    public class Aluno {
        public string Nome;
        public double NotaPriTri;
        public double NotaSegTri;
        public double NotaTerTri;
        private double NotaFinal;

        public void ValidarNotas() {
            if (NotaPriTri > 30 || NotaSegTri > 35 || NotaTerTri > 35) {
                Console.WriteLine("Nota(s) acima da nota máxima permitida!");
                return;
            }
        }

        public double CalculoNotaFinal() {
            NotaFinal = NotaPriTri + NotaSegTri + NotaTerTri;
            return NotaFinal;
        }

        public bool isAprovado() {
            bool aprovadoReprovado = NotaFinal >= 60.0 ? true : false;
            return aprovadoReprovado;
        }
    }

    internal class ExerciciosClassesAtributosMetodos {
        public static void MainX(string[] args) {

            // Exercício 1:
            // Fazer um programa para ler os valores da largura e altura de um retângulo.
            // Em seguida mostrar na tela o valor de sua área, perímetro e diagonal.

            Console.WriteLine("EXERCÍCIO 1 EM EXECUÇÃO...\n");

            Retangulo retangulo1 = new Retangulo();

            Console.Write("Entre com a largura do retângulo: ");
            retangulo1.Largura = double.Parse(Console.ReadLine());

            Console.Write("Entre com a altura do retângulo: ");
            retangulo1.Altura = double.Parse(Console.ReadLine());

            Console.WriteLine($"\nÁrea: {retangulo1.Area():F2}");
            Console.WriteLine($"Perímetro: {retangulo1.Perimetro():F2}");
            Console.WriteLine($"Diagonal: {retangulo1.Diagonal():F2}");

            // Exercício 2:
            // Fazer um programa para ler os dados de um funcionário (nome, salário bruto e imposto). 
            // Em seguida, mostrar os dados do funcionário (nome e salário líquido).
            // Em seguida, aumentar o salário do funcionário com base em uma porcentagem dada (somente o salário bruto é
            // afetado pela porcentagem) e mostrar novamente os dados do funcionário.

            Console.WriteLine("\n\nEXERCÍCIO 2 EM EXECUÇÃO...\n");

            OutroFuncionario funcionario = new OutroFuncionario();

            Console.Write("Entre com o nome do funcionário: ");
            funcionario.Nome = Console.ReadLine();

            Console.Write("Entre com o salário bruto do funcionário: ");
            funcionario.SalarioBruto = double.Parse(Console.ReadLine());

            Console.Write("Entre com o imposto (em dinheiro) do funcionário: ");
            funcionario.ImpostoEmDinheiro = double.Parse(Console.ReadLine());

            Console.WriteLine("\nDados do funcionário: \n");
            Console.WriteLine(funcionario);

            Console.WriteLine("\nAumentando salário...");
            Console.Write("Entre com a porcentagem do aumento: ");
            double porcentagem = double.Parse(Console.ReadLine());
            funcionario.AumentarSalario(porcentagem);

            Console.WriteLine("\nDados atualizados do funcionário: \n");
            Console.WriteLine(funcionario);

            // Exercício 3:
            // Fazer um programa para ler o nome de um aluno e as três notas que ele obteve nos três trimestres do ano
            // (primeiro trimestre vale 30, e o segundo e terceiro valem 35 cada). Ao final, mostral qual a nota final
            // do aluno no ano. Dizer também se o aluno está aprovado ou reprovado e, em caso negativo, quantos pontos
            // faltam para o aluno obter o mínimo para ser aprovado (60 pts). Você deve criar uma classe Aluno para
            // resolver este problema.

            Console.WriteLine("\n\nEXERCÍCIO 3 EM EXECUÇÃO...\n");

            Aluno aluno = new Aluno();

            Console.Write("Entre com o nome do aluno: ");
            aluno.Nome = Console.ReadLine();

            Console.Write("Entre com a nota do 1° trimestre: ");
            aluno.NotaPriTri = double.Parse(Console.ReadLine());

            Console.Write("Entre com a nota do 2° trimestre: ");
            aluno.NotaSegTri = double.Parse(Console.ReadLine());

            Console.Write("Entre com a nota do 3° trimestre: ");
            aluno.NotaTerTri = double.Parse(Console.ReadLine());

            aluno.ValidarNotas();

            Console.WriteLine($"Nota final: {aluno.CalculoNotaFinal()} pts.");

            string statusAprovacao = aluno.isAprovado() ? "APROVADO" : "REPROVADO";
            Console.WriteLine($"Status: {statusAprovacao}!");
        }
    }
}
