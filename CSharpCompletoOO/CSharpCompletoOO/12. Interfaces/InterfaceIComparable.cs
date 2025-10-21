using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._12._Interfaces {

    public class Funcionario : IComparable {
        public string Nome { get; set; }
        public double Salario { get; set; }

        public Funcionario(string csvFuncionario) {
            string[] vetor = csvFuncionario.Split(',');
            Nome = vetor[0];
            Salario = double.Parse(vetor[1]);
        }

        public override string ToString() {
            return $"Nome: {Nome}, Salário: R$ {Salario:F2}";
        }

        public int CompareTo(object? obj) {
            if (!(obj is Funcionario)) {
                throw new ArgumentException("Erro de comparação: argumento não é do tipo 'Funcionário'!");
            }
            Funcionario func = obj as Funcionario;
            return Nome.CompareTo(func.Nome);
        }
    }
    internal class InterfaceIComparable {
        public static void MainX(string[] args) {
            // Exercício prático 1:
            // Faça um programa para ler um arquivo contendo nomes de pessoas (um nome por linha), armazenando-os
            // em uma lista. Depois, ordenar os dados dessa lista e mostrá-los ordenadamente na tela.

            string path = @"C:\Users\lucas\Documentos\Estágio Datamob\Estudos\Cursos Udemy\CSharp-Completo-OO\CSharpCompletoOO\CSharpCompletoOO\Pasta de Assistência\Arquivo1.txt"; 

            try {
                using (StreamReader streamReader = File.OpenText(path)) {
                    List<string> lista = new List<string>();
                    while (!streamReader.EndOfStream) {
                        lista.Add(streamReader.ReadLine());
                    }
                    lista.Sort();
                    foreach (var str in lista) {
                        Console.WriteLine(str);
                    }
                }
            } catch (IOException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Main(string[] args) {
            // Exercício prático 2:
            // Faça um programa para ler um arquivo contendo funcionários (nome e salário) no formato .csv, 
            // armazenando-os em uma lista. Depois, ordenar a lista por nome e mostrar o resultado na tela.

            string path = @"C:\Users\lucas\Documentos\Estágio Datamob\Estudos\Cursos Udemy\CSharp-Completo-OO\CSharpCompletoOO\CSharpCompletoOO\Pasta de Assistência\Arquivo3.csv";

            try {
                using (StreamReader streamReader = File.OpenText(path)) {
                    List<Funcionario> lista = new List<Funcionario>();
                    while (!streamReader.EndOfStream) {
                        lista.Add(new Funcionario(streamReader.ReadLine()));
                    }
                    lista.Sort(); // não tem como ordenar essa lista sem saber como se compara um funcionário com outro!
                    // O método 'Sort()' faz o uso da interface 'IComparable'. Ou seja, a classe 'Funcionario' terá que
                    // implementar a interface 'IComparable' também.
                    foreach (var func in lista) {
                        Console.WriteLine(func);
                    }
                }
            } catch (IOException ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
