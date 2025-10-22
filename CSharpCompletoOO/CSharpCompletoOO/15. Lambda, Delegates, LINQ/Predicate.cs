using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._15._Lambda__Delegates__LINQ {

    public class Produto {
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, double preco) {
            Nome = nome;
            Preco = preco;
        }

        public override string ToString() {
            return $"Nome: {Nome}, Preço: R$ {Preco:F2}";
        }
    }
    internal class Predicate {
        public static void MainX(string[] args) {
            // Exercício exemplo:
            // Fazer um programa que, a partir de uma lista de produtos, remova da lista somente aqueles cujo preço mínimo seja 100.
            // O 'predicate' é um delegate, porém com uma especificidade:
            // - deve receber um objeto e retornar um 'bool'
            // 'public delegate bool Predicate<in T>(T obj);'
            
            List<Produto> lista = new List<Produto>();

            lista.Add(new Produto("Kindle", 950.00));
            lista.Add(new Produto("Caderneta B5", 29.90));
            lista.Add(new Produto("Notebook", 7880.90));
            lista.Add(new Produto("Headphone", 675.00));
            lista.Add(new Produto("Caneta Gel", 18.90));

            lista.RemoveAll(ProdutoTeste);
            foreach (Produto p in lista) {
                Console.WriteLine(p);
            }
        }

        public static bool ProdutoTeste(Produto p) {
            return p.Preco >= 100;
        }
    }
}
