using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._9._Herança_e_Polimorfismo {

    public class Produto {
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Produto() { }

        public Produto(string nome, double preco) {
            Nome = nome;
            Preco = preco;
        }

        public virtual string EtiquetaPreco() {
            return $"{Nome} R$ {Preco:F2}";
        }
    }

    public class ProdutoImportado : Produto {
        public double TaxaDeImportacao { get; set; }

        public ProdutoImportado(string nome, double preco, double taxaDeImportacao)
            : base(nome, preco) {
            TaxaDeImportacao = taxaDeImportacao;
        }

        public override string EtiquetaPreco() {
            return $"{Nome} R$ {Preco + TaxaDeImportacao:F2} (Taxa de importação: R$ {TaxaDeImportacao:F2})";
        }
        
    }

    public class ProdutoUsado : Produto {
        public DateTime DataFabricacao { get; set; }
        
        public ProdutoUsado(string nome, double preco, DateTime dataFabricacao)
            : base(nome, preco) {
            DataFabricacao = dataFabricacao;
        }
        public override string EtiquetaPreco() {
            return $"{Nome} (usado) R$ {Preco:F2} (Data de fabricação: {DataFabricacao.ToString("dd/MM/yyyy")})";
        }

    }
    internal class ExercicioFixacaoHerancaPolimorfismo {
        public static void MainX(string[] args) {
            // Exercício de fixação:
            // Fazer um programa para ler os dados de N produtos. Ao final, mostrar a etiqueta de preço
            // de cada produto na mesma ordem em que foram registrados.
            // Todo produto possui nome e preço. Produtos importados possuem uma taxa de alfândega,
            // e produtos usados possuem data de fabricação.
            // Estes dados específicos devem ser acrescentados na etiqueta de preço. Para produtos importados,
            // a taxa de alfândega deve ser acrescentada ao preço final do produto.

            Console.Write("Entre com o número de produtos: ");
            int prodNum = int.Parse(Console.ReadLine());

            List<Produto> produtos = new List<Produto>();
            for (int i = 0; i < prodNum; i++) {
                Console.WriteLine($"\nEntrando com os dados do produto {i + 1}...");
                Console.Write("Nome: ");
                string nomeProd = Console.ReadLine();

                Console.Write("Preço: ");
                int preco = int.Parse(Console.ReadLine());

                Console.Write("Produto comum, usado ou importado (C/U/I): ");
                char prodCategoria = char.Parse(Console.ReadLine());

                if (prodCategoria == 'C' || prodCategoria == 'c') {
                    Produto produtoComum = new Produto(nomeProd, preco);
                    produtos.Insert(i, produtoComum);
                } else if (prodCategoria == 'U' || prodCategoria == 'u') {
                    Console.Write("Entre com a data de fabricação: ");
                    DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());
                    Produto produtoUsado = new ProdutoUsado(nomeProd, preco, dataFabricacao);
                    produtos.Insert(i, produtoUsado);
                } else {
                    Console.Write("Entre com o valor da taxa de importação: ");
                    double taxa = double.Parse(Console.ReadLine());
                    Produto produtoImp = new ProdutoImportado(nomeProd, preco, taxa);
                    produtos.Insert(i, produtoImp);
                }
            }

            Console.WriteLine("\nEtiquetas de preço:");
            foreach (var prod in produtos) {
                Console.WriteLine($"{prod.EtiquetaPreco()}");
            }
        }
    }
}
