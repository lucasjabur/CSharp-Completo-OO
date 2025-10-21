using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._11._Arquivos {
    internal class BlocoUsing {
        public static void MainX(string[] args) {
            // Bloco 'Using': garante que objetos 'IDisposable' serão fechados automaticamente após o seu uso
            // Objetos 'IDisposable' não são gerenciados pelo CLR do C#! Precisam ser fechados manualmente.

            string path = @"C:\Users\lucas\Documentos\Estágio Datamob\Estudos\Cursos Udemy\CSharp-Completo-OO\CSharpCompletoOO\CSharpCompletoOO\Pasta de Assistência\Trabalhando Com Arquivos.txt";

            try {
                // 1° método:
                /*
                    using (FileStream fileStream = new FileStream(path, FileMode.Open)) {
                        // Ao final do bloco, o 'fileStream' será automaticamente fechado.
                        using (StreamReader streamReader = new StreamReader(fileStream)) {
                            while (!streamReader.EndOfStream) {
                                string linha = streamReader.ReadLine();
                                Console.WriteLine(linha);
                            }
                        }
                    }
                */

                // 2° método:
                using (StreamReader streamReader = File.OpenText(path)) {
                    while (!streamReader.EndOfStream) {
                        string linha = streamReader.ReadLine();
                        Console.WriteLine(linha);
                    }
                }
            } catch (IOException ex) {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        } 
    }
}
