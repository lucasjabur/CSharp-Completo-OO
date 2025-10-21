using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._11._Arquivos {
    internal class PathClass {
        public static void MainX(string[] args) {
            string path = @"C:\Users\lucas\Documentos\Estágio Datamob\Estudos\Cursos Udemy\CSharp-Completo-OO\CSharpCompletoOO\CSharpCompletoOO\Pasta de Assistência\Arquivo1.txt";
            Console.WriteLine(Path.DirectorySeparatorChar); // caso fosse Linux seria '/'.
            Console.WriteLine(Path.PathSeparator);
            Console.WriteLine(Path.GetDirectoryName(path));
            Console.WriteLine(Path.GetFileName(path));
            Console.WriteLine(Path.GetFileNameWithoutExtension(path));
            Console.WriteLine(Path.GetExtension(path));
            Console.WriteLine(Path.GetFullPath(path));
            Console.WriteLine(Path.GetTempPath());
        }
    }
}
 