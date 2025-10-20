using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._9._Herança_e_Polimorfismo {

    public class Funcionario {
        public string Nome { get; set; }
        public int Horas { get; set; }
        public double ValorPorHora { get; set; }

        public Funcionario() { }

        public Funcionario(string nome, int horas, double valorPorHora) {
            Nome = nome;
            Horas = horas;
            ValorPorHora = valorPorHora;
        }

        public virtual double Pagamento() {
            return ValorPorHora * Horas;
        }
    }

    public class FuncionarioTerceirizado : Funcionario {
        public double DespesaAdicional {  get; set; }

        public FuncionarioTerceirizado(string nome, int horas, double valorPorHora, double despesaAdicional)
            : base(nome, horas, valorPorHora) {
            DespesaAdicional = despesaAdicional;
        }

        public override double Pagamento() {
            return base.Pagamento() + DespesaAdicional * 1.1;
        }
    }
    internal class Exercicio {
        public static void MainX(string[] args) {
            // Exercício:
            // Uma empresa possui funcionários próprios e terceirizados.
            // Para cada funcionário, deseja-se registrar nome, horas trabalhadas e valor por hora.
            // Funcionários terceirizados possuem ainda uma despesa adicional.
            // O pagamento dos funcionários corresponde ao valor da hora multiplicado pelas horas trabalhadas
            // sendo que os funcionários terceirizados ainda recebm um bônus correspondente a 110% de sua despesa
            // adicional. Fazer um programa para ler os dados de N funcionários e armazená-los em uma lista.
            // Depois de ler todos os dados, mostra nome e pagamento de cada funcionário na mesma ordem que
            // foram digitados.

            Console.Write("Entre com o número de funcionários: ");
            int funcNum = int.Parse(Console.ReadLine());

            List<Funcionario> funcionarios = new List<Funcionario>();
            for (int i = 0; i < funcNum; i++) {
                Console.WriteLine($"\nEntrando com os dados do funcionário {i + 1}...");
                Console.Write("Nome: ");
                string nomeFunc = Console.ReadLine();

                Console.Write("Horas trabalhadas: ");
                int horasTrab = int.Parse(Console.ReadLine());

                Console.Write("Valor por hora: ");
                double valorHora = double.Parse(Console.ReadLine());

                Console.Write("Funcionário é terceirizado (S/N): ");
                char funcTerceirizado = char.Parse(Console.ReadLine());

                if (funcTerceirizado == 's' || funcTerceirizado == 'S') {
                    Console.Write("Entre com o valor da despesa adicional: ");
                    double despesaAdd = double.Parse(Console.ReadLine());
                    FuncionarioTerceirizado funcTerc = new FuncionarioTerceirizado(nomeFunc, horasTrab, valorHora, despesaAdd);
                    funcionarios.Insert(i, funcTerc);
                } else {
                    Funcionario func = new Funcionario(nomeFunc, horasTrab, valorHora);
                    funcionarios.Insert(i, func);
                }
            }

            Console.WriteLine("\nPagamentos:");
            foreach (var func in funcionarios) {
                Console.WriteLine($"{func.Nome}: R$ {(func.Pagamento()):F2}");
            }
        }
    }
}
