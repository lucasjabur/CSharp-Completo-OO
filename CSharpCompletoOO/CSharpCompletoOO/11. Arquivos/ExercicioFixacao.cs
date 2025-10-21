using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CSharpCompletoOO._11._Arquivos {
    internal class ExercicioFixacao {
        public static void MainX(string[] args) {
            // Exercício de fixação:
            // Fazer um programa para ler o caminho de um arquivo .csv contendo os dados de itens
            // vendidos. Cada item possui um nome, preço unitário e quantidade, separados por vírgula.
            // Você deve gerar um novo arquivo chamado "summary.csv", localizado em uma subpasta
            // chamada "out" a partir da pasta original do arquivo de origem, contendo apenas o nome
            // e o valor total para aquele item (preço unitário * pela quantidade).

            Console.WriteLine("Entre com o caminho de um arquivo: ");
            string path = @"C:\Users\lucas\Documentos\Estágio Datamob\Estudos\Cursos Udemy\CSharp-Completo-OO\CSharpCompletoOO\CSharpCompletoOO\Pasta de Assistência\" + Console.ReadLine();

            try {
                // 1°: organizar caminhos de origem do arquivo e de destino para o novo arquivo, e os próprios arquivos
                string origem = Path.GetDirectoryName(path);
                string destino = Path.Combine(origem, "out");
                
                Directory.CreateDirectory(destino); // criar diretório caso não exista

                string arquivoDestino = Path.Combine(destino, "summary.csv");
                
                // 2°: criar lista para armazenar as linhas do arquivo de origem
                List<string> linhas = new List<string>();

                using (StreamReader streamReader = new StreamReader(path)) {
                    while (!streamReader.EndOfStream) {
                        string linha = streamReader.ReadLine(); // pega a linha do arquivo
                        string[] campos = linha.Split(','); // separa a linha em campos para poder trabalhar com as informações individualmente

                        // 3°: separar as informações das linhas em variáveis distintas
                        string nome = campos[0];
                        double preco = double.Parse(campos[1]);
                        int quantidade = int.Parse(campos[2]);

                        double total = preco * quantidade; // e usá-las para calcular o preço total

                        linhas.Add($"{nome}, R$ {total:F2}"); // adicionar a string de informações na lista
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter(arquivoDestino)) {
                    foreach (string linha in linhas) {
                        streamWriter.WriteLine(linha); // escrever no arquivo
                    }
                }

            } catch (IOException ex) {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
