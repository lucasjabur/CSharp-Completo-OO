using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CSharpCompletoOO._8._Enumerações_e_Composição {

    public class Postagem {
        public DateTime Momento { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public int Curtidas { get; set; }
        public List<Comentario> Comentarios = new List<Comentario>();

        public Postagem(DateTime momento, string titulo, string conteudo, int curtidas) {
            Momento = momento;
            Titulo = titulo;
            Conteudo = conteudo;
            Curtidas = curtidas;
        }

        public void AdicionarComentario(Comentario comentario) {
            Comentarios.Add(comentario);
        }

        public void RemoverComentario(Comentario comentario) {
            Comentarios.Remove(comentario);
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Titulo);
            sb.Append(Curtidas);
            sb.Append(" curtidas - ");
            sb.AppendLine(Momento.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine(Conteudo);
            sb.AppendLine("Comentários: ");
            foreach (var comentario in Comentarios) {
                sb.AppendLine(comentario.Texto);
            }

            return sb.ToString();
        }
    }

    public class Comentario {
        public string Texto { get; set; }

        public Comentario(string texto) {
            Texto = texto;
        }
    }

    internal class ExercicioStringBuilder {
        public static void MainX(string[] args) {
            // Exercício:
            // Instancie manualmente os objetos mostrados abaixo e mostre-os na tela do terminal.

            Console.Write("Faça um comentário: ");
            string texto = Console.ReadLine();
            Comentario comentario1 = new Comentario(texto);

            Postagem postagem1 = new Postagem(DateTime.Now, "Postagem 1", "Estudando C#!", 34);
            postagem1.AdicionarComentario(comentario1);

            Console.Write("Faça outro comentário: ");
            string texto2 = Console.ReadLine();
            Comentario comentario2 = new Comentario(texto2);

            Postagem postagem2 = new Postagem(DateTime.Parse("03/03/2024 14:50:00"), "Postagem 2", "Estudando Orientação a Objetos com C#!", 55);
            postagem2.AdicionarComentario(comentario2);

            // A classe 'Postagem' tem muitos dados para serem impressos, inclusive é possível que uma postagem
            // possua uma grande quantidade de comentários. Dessa forma, implementar o método 'ToString()' não é uma
            // boa solução, pois o que iria acontecer é uma grande quantidade de concatenações de strings, o que tornaria
            // a aplicação/o sistema desnecessariamente pesado.
            // Assim, deve-se implementar o 'ToString()' com a classe 'StringBuilder'.

            Console.WriteLine(postagem1);
            Console.WriteLine(postagem2);
        }
    }
}
