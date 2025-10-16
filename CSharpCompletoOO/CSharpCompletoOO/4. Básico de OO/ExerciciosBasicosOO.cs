using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._4._Básico_de_OO {

    public class Pessoa {
        internal string Nome;
        internal int Idade;
    }

    public class Funcionario {
        internal string Nome;
        internal double Salario;
    }
    internal class ExerciciosBasicosOO {
        public static void MainX(string[] args) {
            // Exercício 1:
            // Fazer um programa para ler os dados de duas pessoas, depois mostrar o nome da pessoa mais
            // velha.

            // Duas maneiras de instanciar um objeto sem construtor definido explicitamente

            Console.WriteLine("EXECUTANDO EXERCÍCIO 1...\n");

            Pessoa pessoa1 = new Pessoa();
            Console.Write("Entre com o nome da primeira pessoa: ");
            pessoa1.Nome = Console.ReadLine();

            Console.Write("Entre com a idade da primeira pessoa: ");
            pessoa1.Idade = int.Parse(Console.ReadLine());

            Console.Write("Entre com o nome e a idade da segunda pessoa: ");
            Pessoa pessoa2 = new Pessoa() {
                Nome = Console.ReadLine(),
                Idade = int.Parse(Console.ReadLine())
            };

            if (pessoa1.Idade > pessoa2.Idade) {
                Console.WriteLine($"{pessoa1.Nome} é mais velho que {pessoa2.Nome}\n");
            } else {
                Console.WriteLine($"{pessoa2.Nome} é mais velho que {pessoa1.Nome}\n");
            }

            // Exercício 2:
            // Fazer um programa para ler nome e salário de dois funcionários. Depois, mostrar o salário
            // médio dos funcionários.

            Console.WriteLine("\n\nEXECUTANDO EXERCÍCIO 2...");

            Funcionario func1 = new Funcionario();
            Funcionario func2 = new Funcionario();

            Console.Write("Entre com o nome do funcionário 1: ");
            func1.Nome = Console.ReadLine();

            Console.Write("Entre com a idade do funcionário 1: ");
            func1.Salario = double.Parse(Console.ReadLine());

            Console.Write("Entre com o nome do funcionário 2: ");
            func2.Nome = Console.ReadLine();

            Console.Write("Entre com a idade do funcionário 2: ");
            func2.Salario = double.Parse(Console.ReadLine());

            double mediaSal = (func1.Salario + func2.Salario) / 2;
            Console.WriteLine($"\nMédia salarial: R$ {mediaSal:F2}");
        }
    }
}
