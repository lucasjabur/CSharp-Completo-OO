using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._13._Generics__Set__Dictionary {
    internal class ExercicioPropostoDictionary {
        public static void Main(string[] args) {
            // Exercício proposto:
            // Na contagem de votos de uma eleição, são gerados vários registros de votação contendo o nome do candidato
            // e a quantidade de votos (formato .csv) que ele obteve em uma urna de votação. Você deve fazer um programa
            // para ler os registros de votação a partir de um arquivo, e daí gerar um relatório consolidado com os totais
            // de cada candidato.
            
            Console.Write("Entre com o caminho do arquivo: ");
            string path = @"C:\Users\lucas\Documentos\Estágio Datamob\Estudos\Cursos Udemy\CSharp-Completo-OO\CSharpCompletoOO\CSharpCompletoOO\Pasta de Assistência\" + Console.ReadLine();

            Dictionary<string, int> linhas = new Dictionary<string, int>();
            try {
                using (StreamReader streamReader = new StreamReader(path)) {
                    while (!streamReader.EndOfStream) {
                        string linha = streamReader.ReadLine();
                        string[] campos = linha.Split(',');

                        string nome = campos[0];
                        int votos = int.Parse(campos[1]);

                        if (linhas.ContainsKey(nome)) {
                            linhas[nome] += votos;
                        } else {
                            linhas[nome] = votos;
                        }
                    }
                }

                foreach (KeyValuePair<string, int> item in linhas) {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
