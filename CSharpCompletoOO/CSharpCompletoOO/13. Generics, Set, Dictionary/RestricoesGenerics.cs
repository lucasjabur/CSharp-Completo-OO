using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._13._Generics {

    public class Produto : IComparable {
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, double preco) {
            Nome = nome;
            Preco = preco;
        }

        public override string ToString() {
            return $"Nome: {Nome}, Preco: R$ {Preco:F2}";
        }

        public int CompareTo(object? obj) {
            if (!(obj is Produto)) {
                throw new ArgumentException("Erro de comparação! Argumento não é um 'Produto'.");
            }
            Produto prod = obj as Produto;
            return Preco.CompareTo(prod.Preco);
        }
    }

    public class ServicoCalculo {
        public T Maximo<T>(List<T> lista) where T : IComparable{ // a minha lista vai receber valores de um tipo T qualquer
            // desde que esse tipo 'T' seja um tipo comparável. 
            // Caso contrário, a operação de comparação necessária para encontrar o maior elemento não seria possível.
            // Isso é a restrição de Generics.
            // Essa restrição pode ser de outros tipos, como 'struct', 'class', 'unmanaged', 'new()', '<base type name>, outro tipo genérico.
            if (lista.Count == 0) {
                throw new ArgumentException("A lista não pode ser vazia!");
            }

            T maximo = lista[0];
            for (int i = 1; i < lista.Count; i++) {
                if (lista[i].CompareTo(maximo) > 0) {
                    maximo = lista[i];
                }
            }

            return maximo;
        }
    }

    internal class RestricoesGenerics {
        public static void MainX(string[] args) {
            // Problema:
            // Uma empresa de consultoria deseja avaliar a performance de produtos, funcionários,
            // dentre outras coisas. Um dos cálculos que ela precisa é encontrar o maior dentre um
            // conjunto de elementos. Fazer um programa que leia um conjunto de N produtos e depois
            // mostre o mais caro deles.

            Console.Write("Número de produtos: ");
            int numProds = int.Parse(Console.ReadLine());

            List<Produto> lista = new List<Produto>();

            for (int i = 0; i < numProds; i++) {
                Console.Write("Entre com o nome e o preco do produto: ");
                string[] vetor = Console.ReadLine().Split(',');
                string nome = vetor[0];
                double preco = double.Parse(vetor[1]);
                lista.Add(new Produto(nome, preco));
            }

            ServicoCalculo servico = new ServicoCalculo();

            Produto maximo = servico.Maximo(lista);

            Console.Write($"Maior elemento: {maximo}");
        }
    }
}
