using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._15._Lambda__Delegates__LINQ {
    internal class Func {
        public static void MainX(string[] args) {
            // o 'func' é um delegante que representa um método que recebe zero ou mais argumentos, e retorna uma valor.
            // Exercício exemplo:
            // Fazer um programa que, a partir de uma lista de produtos, gere uma nova lista contendo os nomes dos produtos
            // em caixa alta.

            List<Produto> lista = new List<Produto>();

            lista.Add(new Produto("Kindle", 950.00));
            lista.Add(new Produto("Caderneta B5", 29.90));
            lista.Add(new Produto("Notebook", 7880.90));
            lista.Add(new Produto("Headphone", 675.00));
            lista.Add(new Produto("Caneta Gel", 18.90));

            Func<Produto, string> func = NomeUpper;
            Func<Produto, string> func2 = p => p.Nome.ToUpper();

            List<string> resultado = lista.Select(func2).ToList();
            foreach(string str in resultado) {
                Console.WriteLine(str);
            }
        }

        public static string NomeUpper(Produto p) {
            return p.Nome.ToUpper();
        }
    }
}
