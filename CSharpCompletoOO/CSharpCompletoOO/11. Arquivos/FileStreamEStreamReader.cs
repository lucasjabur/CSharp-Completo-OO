using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._11._Arquivos {
    internal class FileStreamEStreamReader {
        public static void MainX(string[] args) {

            // Funcionalidades:

            // - 'FileStream':
            //    . fornece acesso direto a um arquivo no sistema de arquivos
            //    . usada para ler ou escrever bytes

            // - 'StreamReader':
            //    . é um wrapper (camada de abstração) sobre um Stream (geralmente um 'FileStream')
            //    . feita para ler texto cuidando automaticamente da codificação

            string path = @"C:\Users\lucas\Documentos\Estágio Datamob\Estudos\Cursos Udemy\CSharp-Completo-OO\CSharpCompletoOO\CSharpCompletoOO\Pasta de Assistência\Trabalhando Com Arquivos.txt";
            FileStream fileStream = null;
            StreamReader streamReader = null;

            // Primeira deve-se instanciar um 'FileStream' associado ao arquivo
            // E depois se instancia um 'StreamReader' associado ao 'FileStream'

            try {
                fileStream = new FileStream(path, FileMode.Open);
                streamReader = new StreamReader(fileStream);

                while (!streamReader.EndOfStream) { // roda todas as linhas do arquivo!
                    string linha = streamReader.ReadLine();
                    Console.WriteLine(linha);
                }

                // As operações com arquivos são gerenciadas pelo SO, não pelo CLR do C#.
                // Dessa forma, é necessário que sejam fechadas manualmente após a execução

                // Também é possível não utilizar o 'FileStream' para instanciar um 'StreamReader':
                StreamReader streamReader2 = File.OpenText(path);

            } catch (IOException ex) {
                Console.WriteLine($"Erro: {ex.Message}");
            } finally {
                if (streamReader != null) streamReader.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
    }
}
