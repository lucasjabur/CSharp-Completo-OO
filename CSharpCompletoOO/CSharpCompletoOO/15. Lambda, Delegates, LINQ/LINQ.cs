using CSharpCompletoOO._6._Comportamento_de_Memória;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpCompletoOO._15._Lambda__Delegates__LINQ {

    public class OutroProduto {
        public int IdProduto { get; set; }
        public string Nome {  get; set; }
        public double Preco {  get; set; }
        public Categoria Categoria { get; set; }

        public override string ToString() {
            return $"{IdProduto}. Nome: {Nome}, Preço: R$ {Preco:F2}, Nome da Categoria: {Categoria.NomeCategoria}, Tier: {Categoria.Tier}";
        }
    }

    public class Categoria {
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public int Tier { get; set; }

    }

    internal class LINQ {
        public static void Main(string[] args) {
            // LINQ:
            // Integração de funcionalidades de consultas dentro do C#.

            // Especificar a fonte dos dados
            int[] numeros = new int[] { 2, 3, 4, 5 };

            // Definir a consulta
            IEnumerable<int> resultado = numeros.Where(x => x % 2 == 0).Select(x => x * 10);

            // Executar a consulta
            foreach (int valor in resultado) {
                Console.WriteLine(valor);
            }

            // Trabalhando com LINQ + Lambda:

            Categoria c1 = new Categoria() { IdCategoria = 1, NomeCategoria = "Ferramentas", Tier = 2 };
            Categoria c2 = new Categoria() { IdCategoria = 2, NomeCategoria = "Computadores", Tier = 1 };
            Categoria c3 = new Categoria() { IdCategoria = 3, NomeCategoria = "Eletrônicos", Tier = 1 };

            List<OutroProduto> produtos = new List<OutroProduto>() {
                new OutroProduto() { IdProduto = 1, Nome = "Computador", Preco = 3500.00, Categoria = c2 },
                new OutroProduto() { IdProduto = 2, Nome = "Martelo", Preco = 90.00, Categoria = c1 },
                new OutroProduto() { IdProduto = 3, Nome = "TV", Preco = 1700.00, Categoria = c3 },
                new OutroProduto() { IdProduto = 4, Nome = "Notebook", Preco = 1300.00, Categoria = c2 },
                new OutroProduto() { IdProduto = 5, Nome = "Serra", Preco = 80.00, Categoria = c1 },
                new OutroProduto() { IdProduto = 6, Nome = "Tablet", Preco = 700.00, Categoria = c2 },
                new OutroProduto() { IdProduto = 7, Nome = "Camera", Preco = 700.00, Categoria = c3 },
                new OutroProduto() { IdProduto = 8, Nome = "Impressora", Preco = 350.00, Categoria = c3 },
                new OutroProduto() { IdProduto = 9, Nome = "MacBook", Preco = 1800.00, Categoria = c2 },
                new OutroProduto() { IdProduto = 10, Nome = "Sound bar", Preco = 700.00, Categoria = c3 },
                new OutroProduto() { IdProduto = 11, Nome = "Level", Preco = 70.00, Categoria = c1 },
            };

            // var resultado1 = produtos.Where(p => p.Categoria.Tier == 1 && p.Preco < 900.00);
            var resultado1 =
                from p in produtos
                where p.Categoria.Tier == 1 && p.Preco < 900.00
                select p;
            Console.WriteLine("Produtos Tier 1 e preço < R$ 900.00: ");
            foreach(var item in resultado1) {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            // var resultado2 = produtos.Where(p => p.Categoria.NomeCategoria == "Ferramentas").Select(p => p.Nome);
            var resultado2 =
                from p in produtos
                where p.Categoria.NomeCategoria == "Ferramentas"
                select p.Nome;
            foreach (var item in resultado2) {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            // var resultado3 = produtos.Where(p => p.Nome[0] == 'C').Select(p => new { p.Nome, p.Preco, p.Categoria.NomeCategoria });
            var resultado3 =
                from p in produtos
                where p.Nome[0] == 'C'
                select new {
                    p.Nome,
                    p.Preco,
                    p.Categoria.NomeCategoria
                };
            foreach (var item in resultado3) {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            // var resultado4 = produtos.Where(p => p.Categoria.Tier == 1).OrderBy(p => p.Preco).ThenBy(p => p.Nome);
            var resultado4 =
                from p in produtos
                where p.Categoria.Tier == 1
                orderby p.Nome
                orderby p.Preco
                select p; 
            foreach (var item in resultado4) {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            // var resultado5 = resultado4.Skip(2).Take(4); 
            var resultado5 =
                (from p in resultado4
                 select p).Skip(2).Take(4);
            foreach (var item in resultado5) {
                Console.WriteLine(item);
            }

            var resultado6 = produtos.First();
            Console.WriteLine("Teste 1: " + resultado6);

            var resultado7 = produtos.Where(p => p.Preco > 4000.00).FirstOrDefault();
            Console.WriteLine("Teste 2: " + resultado6);

            var resultado8 = produtos.Where(p => p.IdProduto == 3).SingleOrDefault();
            Console.WriteLine("Id = 3: " + resultado8);

            var resultado9 = produtos.Where(p => p.IdProduto == 30).SingleOrDefault();
            Console.WriteLine("Id = 30: " + resultado9);

            var resultado10 = produtos.Max(p => p.Preco);
            Console.WriteLine($"Preço máximo: R$ {resultado10:F2}");

            var resultado11 = produtos.Min(p => p.Preco);
            Console.WriteLine($"Preço máximo: R$ {resultado11:F2}");

            var resultado12 = produtos.Where(p => p.Categoria.IdCategoria == 1).Sum(p => p.Preco);
            Console.WriteLine("Soma dos preços da categoria 1: " + resultado12);

            var resultado13 = produtos.Where(p => p.Categoria.IdCategoria == 1).Average(p => p.Preco);
            Console.WriteLine("Média dos preços da categoria 1: " + resultado13);

            var resultado14 = produtos.Where(p => p.Categoria.IdCategoria == 5).Select(p => p.Preco).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Média dos preços da categoria 5 (não existe): " + resultado14);

            // e seu eu quiser utilizar funções personalizadas?
            var resultado15 = produtos.Where(p => p.Categoria.IdCategoria == 1).Select(p => p.Preco).Aggregate(0.0, (x, y) => x + y);
            // utilização com o 'Aggregate()' com uma função anônima passada como parâmetro
            // O '0.0' como primeira argumento aciona uma sobrecarga da função 'Aggregate()' que faz com que este valor seja
            // o valor padrão da operação caso um erro seja gerado. Como filtrar por uma categoria que não existe.
            Console.WriteLine("Categoria 1, aggregate sum: " + resultado15);
            Console.WriteLine();

            var resultado16 = produtos.GroupBy(p => p.Categoria);
            foreach (IGrouping<Categoria, OutroProduto> grupo in resultado16) {
                Console.WriteLine($"Categoria {grupo.Key.NomeCategoria}: ");
                foreach (OutroProduto p in grupo) {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }
        }
    }
}
