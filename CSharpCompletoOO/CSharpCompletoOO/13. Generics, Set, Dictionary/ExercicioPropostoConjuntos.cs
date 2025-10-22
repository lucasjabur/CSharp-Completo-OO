using CSharpCompletoOO._4._Básico_de_OO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._13._Generics__Set__Dictionary {

    public class Usuario {
        public int Codigo { get; set; }

        public Usuario(int codigo) {
            Codigo = codigo;
        }
    }

    public class Instrutor {
        public string Nome;
        internal HashSet<Curso> CursosMinistrados {  get; set; } = new HashSet<Curso>();

        public Instrutor(string nome) {
            Nome = nome;
        }

        public int NumeroDeAlunos() {
            HashSet<int> _alunosTotais = new HashSet<int>();
            foreach (var curso in CursosMinistrados) {
                _alunosTotais.UnionWith(curso.UsuariosMatriculados);
            }

            return _alunosTotais.Count;
        }
    }

    public class Curso {
        public string NomeCurso { get; set; }
        internal HashSet<int> UsuariosMatriculados { get; set; } = new HashSet<int>();
        public Curso(string nomeCurso) {
            NomeCurso = nomeCurso;
        }
    }

    internal class ExercicioPropostoConjuntos {
        public static void MainX(string[] args) {
            // Exercício Proposto:
            // Em um portal de cursos online, cada usuário possui um código único, representado por um número inteiro.
            // Cada instrutor do portal pode ter vários cursos, sendo que um mesmo aluno pode se matricular em quantos cursos quiser.
            // Assim, o número total de alunos de um instrutor não é simplesmente a soma dos alunos de todos os cursos que ele possui,
            // pois pode haver alunos repetidos em mais de um curso.
            // O instrutor Alex possui três cursos A, B e C, e deseja saber seu número total de alunos.
            // Seu programa deve ler os alunos dos cursos A, B e C do instrutor Alex, depois mostrar a quantidade total de alunos dele.

            Instrutor instrutor = new Instrutor("Alex");
            Curso cursoA = new Curso("A");
            Curso cursoB = new Curso("B");
            Curso cursoC = new Curso("C");

            instrutor.CursosMinistrados.Add(cursoA);
            instrutor.CursosMinistrados.Add(cursoB);
            instrutor.CursosMinistrados.Add(cursoC);

            cursoA.UsuariosMatriculados.Add(123);
            cursoA.UsuariosMatriculados.Add(456);
            cursoA.UsuariosMatriculados.Add(789);
            cursoA.UsuariosMatriculados.Add(147);
            cursoA.UsuariosMatriculados.Add(258);

            cursoB.UsuariosMatriculados.Add(258);
            cursoB.UsuariosMatriculados.Add(369);
            cursoB.UsuariosMatriculados.Add(753);
            cursoB.UsuariosMatriculados.Add(951);
            cursoB.UsuariosMatriculados.Add(123);

            cursoC.UsuariosMatriculados.Add(842);
            cursoC.UsuariosMatriculados.Add(862);
            cursoC.UsuariosMatriculados.Add(369);
            cursoC.UsuariosMatriculados.Add(258);
            cursoC.UsuariosMatriculados.Add(123);

            Console.WriteLine($"Número total de alunos: {instrutor.NumeroDeAlunos()}");
        }
    }
}
