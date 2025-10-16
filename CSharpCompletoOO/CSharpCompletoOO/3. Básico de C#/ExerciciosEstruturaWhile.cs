using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._3._Básico_de_C_ {

    internal class ExerciciosEstruturaWhile {
        public static void MainX(string[] args) {
            Console.WriteLine("Menu:\n[1] Exercício 1\n[2] Exercício 2\n[3] Exercício 3");
            Console.Write("Escolha uma opção: ");
            int option = int.Parse(Console.ReadLine());
            switch (option) {
                case 1:
                    Console.WriteLine("\n\n=== Exercício 1 em execução... ==============================");
                    // Exercício 1:
                    // Leia um valor inteiro X (1 <= X <= 1000). Em seguida mostre os ímpares de 1 até X, um valor por linha, inclusive o
                    // X, se for o caso

                    Console.Write("Insira um valor entre 1 e 1000: ");
                    int valor = int.Parse(Console.ReadLine());
                    int contador = 0;

                    while (contador <= valor) {

                        if (contador % 2 != 0) {
                            Console.WriteLine(contador);
                        }
                        contador++;
                    }

                    break;
                case 2:
                    Console.WriteLine("\n\n=== Exercício 2 em execução... ==============================");
                    // Exercício 2:
                    // Leia um valor inteiro N. Este valor será a quantidade de valores inteiros X que serão lidos em seguida.
                    // Mostre quantos destes valores X estão dentro do intervalo[10, 20] e quantos estão fora do intervalo, mostrando
                    // essas informações conforme exemplo(use a palavra "in" para dentro do intervalo, e "out" para fora do intervalo)

                    Console.Write("Entre com um valor inteiro: ");
                    int qtdeValores = int.Parse(Console.ReadLine());
                    int contador2 = 0;
                    int valoresDentroDoIntervalo = 0;
                    while (contador2 < qtdeValores) {
                        Console.Write($"{contador2 + 1}° valor: ");
                        int valorInteiro = int.Parse(Console.ReadLine());
                        if (valorInteiro >= 10 && valorInteiro <= 20) {
                            valoresDentroDoIntervalo++;
                        }
                        contador2++;
                    }
                    Console.WriteLine($"Quantidade de valores dentro do intervalo: {valoresDentroDoIntervalo}");
                    Console.WriteLine($"Quantidade de valores fora do intervalo: {qtdeValores - valoresDentroDoIntervalo}");

                    break;
                case 3:
                    Console.WriteLine("\n\n=== Exercício 3 em execução... ==============================");
                    // Exercício 3:
                    // Leia 1 valor inteiro N, que representa o número de casos de teste que vem a seguir. Cada caso de teste consiste
                    // de 3 valores reais, cada um deles com uma casa decimal.Apresente a média ponderada para cada um destes
                    // conjuntos de 3 valores, sendo que o primeiro valor tem peso 2, o segundo valor tem peso 3 e o terceiro valor tem
                    // peso 5.

                    Console.Write("Insira um valor inteiro: ");
                    int numCasoTestes = int.Parse(Console.ReadLine());
                    int contador3 = 0;

                    while (contador3 < numCasoTestes) {
                        Console.WriteLine($"\n\n=== {contador3 + 1}ª iteração ==========");
                        Console.Write("1° valor: ");
                        double valor1 = double.Parse(Console.ReadLine());
                        Console.Write("2° valor: ");
                        double valor2 = double.Parse(Console.ReadLine());
                        Console.Write("3° valor: ");
                        double valor3 = double.Parse(Console.ReadLine());

                        double mediaPond = (2 * valor1 + 3 * valor2 + 5 * valor3) / 10;
                        Console.WriteLine($"{contador3 + 1}ª média ponderada: {mediaPond:F1}");

                        contador3++;
                    }

                    break;
                default:
                    Console.WriteLine("Entrada inválida!");
                    break;
            }
        }
    }
}
