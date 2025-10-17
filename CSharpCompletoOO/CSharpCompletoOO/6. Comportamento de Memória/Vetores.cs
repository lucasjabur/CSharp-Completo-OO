using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._6._Comportamento_de_Memória {

    internal class Produtos {
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
    internal class Vetores {

        public static void MainX(string[] args) {
            // Problema 1:
            // Fazer um programa para ler um número inteiro N e a altura de N pessoas.
            // Armazene as N alturas em um vetor. Em seguida, mostrar a altura média dessas pessoas.

            Console.WriteLine("\n\nEXECUTANDO PROBLEMA 1...\n");

            Console.Write("Entre com o número de pessoas: ");
            int numPessoas = int.Parse(Console.ReadLine());
            double[] alturas = new double[numPessoas]; // 'double' é uma struct!

            for (int i = 0; i < numPessoas; i++) {
                Console.Write($"Entre com a altura da pessoa {i + 1}: ");
                alturas[i] = double.Parse(Console.ReadLine());
            }

            double mediaAlturas1 = 0;
            foreach (var altura in alturas) {
                mediaAlturas1 += altura;
            }
            mediaAlturas1 /= numPessoas;
            Console.WriteLine($"Média das alturas: {mediaAlturas1:F2}");

            // Problema 2:
            // Fazer um programa para ler um número inteiro N e os dados (nome e preço) de N Produtos.
            // Armazene os N produtos em um vetor. Em seguida, mostrar o preço médio dos produtos.

            Console.WriteLine("\n\nEXECUTANDO PROBLEMA 2...\n");

            Console.Write("Entre com o número de produtos: ");
            int numProdutos = int.Parse(Console.ReadLine());
            Produtos[] produtos = new Produtos[numProdutos];

            // 1ª forma: como eu pensei
            for (int i = 0; i < numProdutos; i++) {
                produtos[i] = new Produtos();
                Console.Write($"Entre com o nome do produto {i + 1}: ");
                produtos[i].Nome = Console.ReadLine();

                Console.Write($"Entre com o preço do produto {i + 1}: ");
                produtos[i].Preco = double.Parse(Console.ReadLine());
            }

            // 2ª forma: como o curso apresentou
            /*
                for (int i = 0; i < numProdutos; i++) {
                    string nome = Console.ReadLine();
                    double preco = double.Parse(Console.ReadLine());
                    produtos[i] = new Produtos { Nome = nome, Preco = preco };
                }
            */

            double mediaPrecos = 0; 
            foreach (var produto in produtos) {
                mediaPrecos += produto.Preco;
            }
            mediaPrecos /= numProdutos;
            Console.WriteLine($"Média dos preços dos produtos: R$ {mediaPrecos:F2}");
        }

    }
}
