using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._11._Arquivos {
    internal class StreamWriterArquivos {
        public static void MainX(string[] args) {
            string origem = @"C:\Users\lucas\Documentos\Estágio Datamob\Estudos\Cursos Udemy\CSharp-Completo-OO\CSharpCompletoOO\CSharpCompletoOO\Pasta de Assistência\Trabalhando Com Arquivos.txt";
            string destino = @"C:\Users\lucas\Documentos\Estágio Datamob\Estudos\Cursos Udemy\CSharp-Completo-OO\CSharpCompletoOO\CSharpCompletoOO\Pasta de Assistência\Arquivo de Destino.txt";
            
            try {
                string[] linhas = File.ReadAllLines(origem);
                using (StreamWriter streamWriter = File.AppendText(destino)) {
                    // 'AppendText()': abre o arquivo para escrita e escrever ao final do arquivo
                    foreach (var linha in linhas) {
                        streamWriter.WriteLine(linha.ToUpper());
                    }
                }
            } catch (IOException ex) {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
