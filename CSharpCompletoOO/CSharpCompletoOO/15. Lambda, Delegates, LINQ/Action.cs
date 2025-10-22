using CSharpCompletoOO._9._Herança_e_Polimorfismo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._15._Lambda__Delegates__LINQ {
    internal class Action {
        public static void MainX(string[] args) {
            // O 'action' é um delegante que representa um método 'void' que recebe zero ou mais argumentos.
            // Exercício exemplo:
            // Fazer um programa que, a partir de uma lista de produtos, aumenteo preço dos produtos em 10%

            List<Produto> lista = new List<Produto>();

            lista.Add(new Produto("Kindle", 950.00));
            lista.Add(new Produto("Caderneta B5", 29.90));
            lista.Add(new Produto("Notebook", 7880.90));
            lista.Add(new Produto("Headphone", 675.00));
            lista.Add(new Produto("Caneta Gel", 18.90));

            Action<Produto> action = p => { p.Preco += p.Preco * 0.1; };

            lista.ForEach(action);
            foreach(var item in lista) {
                Console.WriteLine(item);
            }
        }
    }
}
