using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._6._Comportamento_de_Memória {

    public class Funcionario {
        public int Id { get; set; }
        public string Nome {  get; set; }
        public double Salario { get; private set; }

        public Funcionario(int id, string nome, double salarioInicial) {
            Id = id;
            Nome = nome;
            Salario = salarioInicial;
        }

        public Funcionario(double salarioInicial) {
            Salario = salarioInicial;
        }

        public void AumentarSalario(double porcentagem) {
            Salario = Salario + (Salario * (porcentagem/100));
        }

        public override string ToString() {
            return $"{Id}. Nome: {Nome}, Salário: R$ {Salario:F2}";
        }
    }

    internal class ExercicioFixacaoListas {
        public static void MainX(string[] args) {
            // Exercício de fixação:
            // Fazer um programa para ler um número inteiro N e depois os dados (id, nome e salário) de N funcionários.
            // Não deve haver repetição de id.
            // Em seguida, efetuar um aumento de X % no salário de um determinado funcionário. Para isso, o programa deve ler
            // um id e o valor X. Se o id informado não existir, mostrar uma mensagem e abortar a operação. Ao final, mostrar
            // a listagem atualizada dos funcionários, conforme exemplos.
            // Lembre-se de aplicar a técnica de encapsulamento para não permitir que o salário possa ser mudado livremente.
            // Um salário só pode aumentar com base em uma operação de aumento por porcentagem dada.

            // 1. variável int N para n° de funcionários
            // 2. id deve ser único
            // 3. armazenar funcionários em uma lista
            // 4. 'Funcionario' é uma classe com método para aumentar salário que possui como parâmetro a porcentagem do aumento
            // 4.1. devo percorrer a lista, encontrar o funcionário cujo id bate com o id passado, chamar o método e alterar o valor.
            // 5. mostrar a lista atualizada de funcionários

            Console.Write("Entre com o número de funcionários: ");
            int numFunc = int.Parse(Console.ReadLine());

            var listFunc = new List<Funcionario>();
            Funcionario funcionario;

            for (int i = 0; i < numFunc; i++) {
                Console.Write($"Entre com o id do funcionário {i + 1}: ");
                int idFunc = int.Parse(Console.ReadLine());
                Console.Write($"Entre com o nome do funcionário {i + 1}: ");
                string nomeFunc = Console.ReadLine();
                Console.Write($"Entre com o salário do funcionário {i + 1}: ");
                double salFunc = double.Parse(Console.ReadLine());
                Console.WriteLine();

                funcionario = new Funcionario(idFunc, nomeFunc, salFunc);
                listFunc.Add(funcionario);
            }

            Console.Write("Selecione o funcionário que se deseja aumentar o salário: ");
            int idFuncAumento = int.Parse(Console.ReadLine());
            Console.Write("Passe a porcentagem do aumento: ");
            double porcentagem = double.Parse(Console.ReadLine());

            Console.WriteLine("\nExibindo os funcionários...\n");
            foreach (var func in listFunc) {
                Console.WriteLine(func);
            }

            Console.WriteLine($"\nAumentando o salário do funcionário {idFuncAumento}");
            foreach (var func in listFunc) {
                if (func.Id == idFuncAumento) {
                    func.AumentarSalario(porcentagem);
                }
            }

            Console.WriteLine("\nExibindo os dados atualizados...\n");
            foreach (var func in listFunc) {
                Console.WriteLine(func);
            }
        }
    }
}
