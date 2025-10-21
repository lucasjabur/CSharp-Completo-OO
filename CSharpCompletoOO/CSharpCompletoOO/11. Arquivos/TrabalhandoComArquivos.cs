using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._11._Arquivos {
    internal class TrabalhandoComArquivos {
        public static void MainX(string[] args) {
            string origem = @"C:\Users\lucas\Documentos\Estágio Datamob\Estudos\Cursos Udemy\CSharp-Completo-OO\CSharpCompletoOO\CSharpCompletoOO\Pasta de Assistência\Trabalhando Com Arquivos.txt";
            string destino = @"C:\Users\lucas\Documentos\Estágio Datamob\Estudos\Cursos Udemy\CSharp-Completo-OO\CSharpCompletoOO\CSharpCompletoOO\Pasta de Assistência\Arquivo de Destino.txt";

            try {
                FileInfo fileInfo = new FileInfo(origem);
                fileInfo.CopyTo(destino);
                string[] linhas = File.ReadAllLines(origem);
                foreach (string linha in linhas) {
                    Console.WriteLine(linha);
                }

                // A diferença entre 'File' e 'FileInfo' é que:
                // 'File' é uma classe abstrata, ou seja, não pode ser instanciada, além de que suas operações
                // são mais lentas, pois a cada operação de I/O o sistema faz uma análise de segurança.
                // Isso não ocorre com o 'FileInfo' por instanciar um objeto de seu tipo, o que previne as
                // análises de segurança, fazendo com que as operações sejam mais rápidas.
                // 'File' é bom para uma pequena quantidade de operações, por ser bem mais simples.
                // 'FileInfo' é para soluções mais complexas e robustas.
            } catch (IOException ex) {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
