using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._6._Comportamento_de_Memória {

    public class Estudante {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Quarto;

        public Estudante(string nome, string email, int quarto) {
            Nome = nome;
            Email = email;
            Quarto = quarto;
        }

        public Estudante(string nome, string email) { // por que que aqui não é necessário o ': this(...)'?
            Nome = nome;
            Email = email;
        }

        public override string ToString() {
            return $"{Quarto}. Nome: {Nome}, E-mail: {Email}";
        }
    }
    internal class ExecicioFixacaoVetores {
        public static void MainX(string[] args) {
            // Exercício de fixação:
            // A dona de um pensionato possui 10 quartos para alugar para estudantes, sendo esses quartos identificados
            // por números de 0 a 9. Faça um programa que inicie com todos os 10 quartos vazios, e depois leia uma
            // quantidade N representando o número de estudante que vão alugar os quartos (N pode ser de 1 a 10).
            // Em seguida, registre o aluguel dos N estudantes. Para cada registro de aluguel, informar o nome e email
            // do estudante, bem como qual dos quartos ele escolheu (de 0 a 9). Suponha que seja escolhido um quarto vago.
            // Ao final, seu programa deve imprimir um relatório de todas as ocupações do pensionato, por ordem de quarto.

            // 1°: quartos é um vetor com 10 elementos (inicialmente vazio)
            // 2°: N é inteiro de 1 a 10
            // 3°: Estudante é uma classe com nome, email e numero do quarto (é nullable, pois inicialmente é 'null') como atributos

            Estudante[] quartos = new Estudante[10];

            Console.Write($"Entre com o número de estudante que desejam alugar um quarto: ");
            int numEstudantes = int.Parse(Console.ReadLine());

            if (numEstudantes < 1 || numEstudantes > 10) {
                Console.WriteLine("Valor inválido para o número de estudante!");
                return;
            }

            //Estudante[] estudantesQueQueremQuarto = new Estudante[numEstudantes];
            Console.WriteLine("\nRegistrando quarto...");
            for (int i = 0; i < numEstudantes; i++) {
                Console.Write("\nEntre com o nome do estudante: ");
                string nomeEstudante = Console.ReadLine();

                Console.Write("Entre com o e-mail do estudante: ");
                string emailEstudante = Console.ReadLine();

                Console.Write("Qual quarto o estudante deseja: ");
                int numQuarto = int.Parse(Console.ReadLine());

                Estudante estudante = new Estudante(nomeEstudante, emailEstudante, numQuarto);
                quartos[numQuarto - 1] = estudante;
            }

            foreach (var estudante in quartos) {
                Console.WriteLine(estudante);
            }
        }
    }
}
