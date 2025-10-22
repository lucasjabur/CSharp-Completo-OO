using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._15._Lambda__Delegates__LINQ {

    public class OperacoesMatematicas {
        public static double Soma(double a, double b) {
            return a + b;
        }

        public static double Subtracao(double a, double b) {
            return a - b;
        }

        public static double Quadrado(double a) {
            return a * a;
        }

        public static void ShowMax(double a, double b) {
            double max = (a > b) ? a : b;
            Console.WriteLine(max);
        }

        public static void ShowSum(double a, double b) {
            double sum = a + b;
            Console.WriteLine(sum);
        }
    }

    delegate double OperacaoNumericaBinaria(double n1, double n2);

    delegate void OperacaoNumericaBinaria2(double n1, double n2);
    
    // Será uma referência para uma função que recebe dois números 'double' e retorna um número 'double'
    internal class Delegate {
        public static void MainX(string[] args) {
            // Delegate:
            // É um tipo referência com type safety para um ou mais métodos
            // Uso comuns:
            // - comunicação entre objetos de forma flexível e extensível (eventos/callbacks)
            // - parametrização de operações por métodos (programação funcional)

            double a = 10;
            double b = 12;

            OperacaoNumericaBinaria operacao = OperacoesMatematicas.Soma;

            // O 'delegate' não funcionára com a função 'Quadrado()', por exemplo, pois aceita apenas métodos que
            // retornem o valor 'double' e que recebem dois argumentos 'double'. 'Quadrado()', por mais que retorne
            // um 'double', possui apenas um parâmetro.

            double resultComDelegate = operacao(a, b);
            double resultSemDelegate = OperacoesMatematicas.Soma(a, b);
            Console.WriteLine(resultComDelegate);
            Console.WriteLine(resultSemDelegate);

            // Multicast delegates:
            // - delegates que guardam a referência para mais de um método
            // - para adicionar uma referência: '+='
            // - a chamada Invoke() (ou sintaxe reduzida) executa todos os métodos na ordem em que foram adicionados
            // - seu uso faz sentido para métodos com retorno 'void'

            OperacaoNumericaBinaria2 operacao2 = OperacoesMatematicas.ShowMax;

            operacao2 += OperacoesMatematicas.ShowMax;
            operacao2.Invoke(a, b);
        }
    }
}
