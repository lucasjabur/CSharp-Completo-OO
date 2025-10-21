using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._13._Generics {

    public class ServicoPrint<T> {
        private T[] _valores = new T[10];
        private int _contador = 0;

        public void AdicionarValor(T value) {
            if (_contador == 10) {
                throw new InvalidOperationException("ServicoPrint está cheio!");
            }
            _valores[_contador] = value;
            _contador++;
        }

        public T Primeiro() {
            if (_contador == 0) {
                throw new InvalidOperationException("ServicoPrint está vazio!");
            }
            return _valores[0];
        }

        public void Printar() {
            Console.Write("[");
            for (int i = 0; i < _contador - 1; i++) {
                Console.Write(_valores[i] + ", ");
            }
            if (_contador > 0) {
                Console.Write(_valores[_contador - 1]);
            }
            Console.WriteLine("]");
        }
    }

    internal class IntroducaoGenerics {
        // Generics permitem que classes, interfaces e métodospossam ser parametrizados por tipo.
        // Uso comum: coleções.

        public static void MainX(string[] args) {
            // Exercício 1:
            // Fazer um programa que leia um conjunto de N números inteiros (de 1 a 10), e depois imprima
            // esses números de forma organizada. Em seguida, informe qual foi o primeiro valor a ser mencionado.

            /*
                ServicoPrint print = new ServicoPrint();
                Console.Write("Número de valores: ");
                int numVal = int.Parse(Console.ReadLine());

                Console.WriteLine("Entre com os valores: ");
                for (int i = 0; i < numVal; i++) {
                    Console.Write("Valor: ");
                    int valor = int.Parse(Console.ReadLine());
                    print.AdicionarValor(valor);
                }

                print.Printar();
                Console.Write($"\nPrimeiro elemento: {print.Primeiro()}");
            */

            // Detalhe: e se você quiser passar de 'int' para 'string'?
            // Pode ser alterando as classes para aceitarem 'string' diretamente, mas o problema de alterar o tipo 
            // futuramente se mantém.
            // Pode ser alterando para 'object', mas isso pode gerar um problema de 'type safety', em que o programa
            // compila, mas gera um erro em tempo de execução. Como ele aceita qualquer coisa, você pode acabar tentando
            // colocar um tipo 'string', mas posteriormente acabar fazendo alguma manipulação ou conversão que era esperada
            // de um tipo 'int', por exemplo, o que geraria esse problema.

            // Qual a melhor solução, então? Utilizar Generics!

            ServicoPrint<int> print = new ServicoPrint<int>();
            Console.Write("Número de valores: ");
            int numVal = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com os valores: ");
            for (int i = 0; i < numVal; i++) {
                Console.Write("Valor: ");
                int valor = int.Parse(Console.ReadLine());
                print.AdicionarValor(valor);
            }

            // string a = (string)print.Primeiro(); --> gera erro! Aqui é onde morava o problema do 'type safety'


            print.Printar();
            Console.Write($"\nPrimeiro elemento: {print.Primeiro()}");
        }
    }
}
