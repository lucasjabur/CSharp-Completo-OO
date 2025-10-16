using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._4._Básico_de_OO {

    public class Produto {
        internal string Nome;
        internal double Preco;
        internal int Quantidade;

        public double ValorTotalEmEstoque() {
            return Preco * Quantidade;
        }

        public void AdicionarProdutos(int quantidade) {
            if (Quantidade == 0) {
                Quantidade = quantidade;
            } else {
                Quantidade += quantidade;
            }
        }

        public void Remover(int quantidade) {
            if (Quantidade == 0) {
                Console.WriteLine("Não é possível remover! Não há unidades em estoque.");
            } else {
                Quantidade -= quantidade;
            }
        }

        public override string ToString() {
            double valorTotalEmEstoque = ValorTotalEmEstoque();
            return $"Dados do produto '{Nome}':\n" +
                   $"   Preço: R$ {Preco:F2}\n" +
                   $"   Quantidade: {Quantidade} unidades.\n" +
                   $"   Valor total em estoque: R$ {valorTotalEmEstoque:F2}\n";
        }
    }
    internal class ExercicioMetodos {
        public static void MainX(string[] args) {
            Produto produto1 = new Produto();
            Console.Write("Entre com o nome do produto: ");
            produto1.Nome = Console.ReadLine();

            Console.Write("Entre com o preço do produto: ");
            produto1.Preco = double.Parse(Console.ReadLine());

            Console.Write("Entre com a quantidade em estoque do produto: ");
            produto1.Quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Dados do produto: ");
            Console.WriteLine(produto1);

            Console.WriteLine("Realizando uma entrada no estoque...\n");
            Console.Write("Insira a quantidade que se deseja adicionar: ");
            int qtdeEntrada = int.Parse(Console.ReadLine());
            produto1.AdicionarProdutos(qtdeEntrada);

            Console.WriteLine("\nDados atualizados do produto: ");
            Console.WriteLine(produto1);

            Console.WriteLine("Realizando uma saída no estoque...");
            Console.Write("Insira a quantidade que se deseja retirar: ");
            int qtdeSaida = int.Parse(Console.ReadLine());
            produto1.Remover(qtdeSaida);

            Console.WriteLine("\nDados atualizados do produto: ");
            Console.WriteLine(produto1);
        }
    }
}
