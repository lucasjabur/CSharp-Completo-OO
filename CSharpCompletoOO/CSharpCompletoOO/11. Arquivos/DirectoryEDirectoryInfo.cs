using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._11._Arquivos {
    internal class DirectoryEDirectoryInfo {
        public static void MainX(string[] args) {
            // Seguem a mesma linha que o 'File' e 'FileInfo':
            // 'Directory': simples e executar checagens de segurança para cada operação; membros estáticos
            // 'DirectoryInfo': membros de instância, não executa as checagens como o anterior e é um pouco mais robusto

            string path = @"C:\Users\lucas\Documentos\Estágio Datamob\Estudos\Cursos Udemy\CSharp-Completo-OO\CSharpCompletoOO\CSharpCompletoOO\Pasta de Assistência";

            try {
                IEnumerable<string> pastas =  Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
                // listar subpastas a partir da pasta inicial indicada
                // resultado: coleção com os strings correspondentes às pastas
                // será do tipo 'IEnumerable' (tipo mais genéricos de coleção)
                Console.WriteLine("PASTAS: ");
                foreach(string str in pastas) {
                    Console.WriteLine(str);
                }

                IEnumerable<string> arquivos = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("ARQUIVOS: ");
                foreach (string str in arquivos) {
                    Console.WriteLine(str);
                }

                Directory.CreateDirectory(path + @"\Nova Pasta");
            } catch (IOException ex) {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
