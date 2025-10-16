using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._3._Básico_de_C_ {
    internal class ExerciciosEstruturaFor {
        public static void MainX(string[] args) {
            Console.WriteLine("Menu:\n[1] Exercício 1\n[2] Exercício 2\n[3] Exercício 3" +
                              "\n[4] Exercício 4\n[5] Exercício 5\n[6] Exercício 6\n[7] Exercício 7");
            Console.Write("Escolha uma opção: ");
            int option = int.Parse(Console.ReadLine());
            switch (option) {
                case 1:
                    Console.WriteLine("\n\n=== Exercício 1 em execução... ==============================");
                    // Exercício 1:
                    // Leia um valor inteiro X (1 <= X <= 1000). Em seguida mostre os ímpares de 1 até X, um valor por linha, inclusive o
                    // X, se for o caso.

                    Console.Write("Entre com um valor: ");
                    int valor = int.Parse(Console.ReadLine());

                    for (int i = 0; i <= valor; i++) {
                        if (i % 2 != 0) {
                            Console.WriteLine(i);
                        }
                    }

                    break;
                case 2:
                    Console.WriteLine("\n\n=== Exercício 2 em execução... ==============================");
                    // Exercício 2:
                    // Leia um valor inteiro N. Este valor será a quantidade de valores inteiros X que serão lidos em seguida.
                    // Mostre quantos destes valores X estão dentro do intervalo[10, 20] e quantos estão fora do intervalo, mostrando
                    // essas informações conforme exemplo(use a palavra "in" para dentro do intervalo, e "out" para fora do intervalo).

                    Console.Write("Entre com um valor: ");
                    int qtdeValores = int.Parse(Console.ReadLine());
                    int valoresDentroIntervalo = 0;
                    for (int i = 0; i < qtdeValores; i++) {
                        Console.Write($"{i + 1}° valor: ");
                        int valorInt = int.Parse(Console.ReadLine());
                        if (valorInt >= 10 && valorInt <= 20) {
                            valoresDentroIntervalo++;
                        }
                    }

                    Console.WriteLine($"Quantidade de valores dentro do intervalo: {valoresDentroIntervalo}");
                    Console.WriteLine($"Quantidade de valores fora do intervalo: {qtdeValores - valoresDentroIntervalo}");

                    break;
                case 3:
                    Console.WriteLine("\n\n=== Exercício 3 em execução... ==============================");
                    // Exercício 3:
                    // Leia 1 valor inteiro N, que representa o número de casos de teste que vem a seguir. Cada caso de teste consiste
                    // de 3 valores reais, cada um deles com uma casa decimal.Apresente a média ponderada para cada um destes
                    // conjuntos de 3 valores, sendo que o primeiro valor tem peso 2, o segundo valor tem peso 3 e o terceiro valor tem
                    // peso 5.

                    Console.Write("Entre com um valor: ");
                    int numTestes = int.Parse(Console.ReadLine());

                    for (int i = 0; i < numTestes; i++) {
                        Console.Write($"1° valor: ");
                        double valor1 = double.Parse(Console.ReadLine());
                        
                        Console.Write($"2° valor: ");
                        double valor2 = double.Parse(Console.ReadLine());

                        Console.Write($"3° valor: ");
                        double valor3 = double.Parse(Console.ReadLine());

                        double mediaPond = (2*valor1 + 3*valor2 + 5*valor3) / 10;
                        Console.WriteLine($"{i + 1}ª média: {mediaPond:F1}");
                    }

                    break;
                case 4:
                    Console.WriteLine("\n\n=== Exercício 4 em execução... ==============================");
                    // Exercício 4:
                    // Fazer um programa para ler um número N. Depois leia N pares de números e mostre a divisão do primeiro pelo
                    // segundo.Se o denominador for igual a zero, mostrar a mensagem "divisao impossivel".

                    Console.Write("Entre com um valor: ");
                    int valorN = int.Parse(Console.ReadLine());

                    for (int i = 0; i < valorN; i++) {
                        Console.Write("\nEntre com o numerador: ");
                        double numerador = double.Parse(Console.ReadLine());

                        Console.Write("Entre com o denominador: ");
                        double denominador = double.Parse(Console.ReadLine());
                    
                        if (denominador == 0) {
                            Console.WriteLine("Divisão impossível!");
                            continue;
                        }

                        double div = numerador / denominador;
                        Console.WriteLine($"{i + 1}ª divisão: {div}");
                    }

                    break;
                case 5:
                    Console.WriteLine("\n\n=== Exercício 5 em execução... ==============================");
                    // Exercício 5:
                    // Ler um valor N. Calcular e escrever seu respectivo fatorial. Fatorial de N = N * (N-1) * (N-2) * (N-3) * ... * 1.
                    // Lembrando que, por definição, fatorial de 0 é 1.

                    Console.Write("Entre com um valor: ");
                    int valorN2 = int.Parse(Console.ReadLine());
                    int fatorial = 1;

                    for (int i = 0; i < valorN2; i++) {
                        int temp = valorN2 - i;
                        fatorial *= temp;
                    }
                    Console.WriteLine($"Fatorial de {valorN2} é: {fatorial}");

                    break;
                case 6:
                    Console.WriteLine("\n\n=== Exercício 6 em execução... ==============================");
                    // Exercício 6:
                    // Ler um número inteiro N e calcular todos os seus divisores.

                    Console.Write("Entre com um valor: ");
                    int valorN3 = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Divisores de {valorN3}: ");
                    for (int i = 1; i <= valorN3; i++) {
                        if (valorN3 % i == 0) {
                            Console.WriteLine(i);
                        }
                    }

                    break;
                case 7:
                    Console.WriteLine("\n\n=== Exercício 7 em execução... ==============================");
                    // Exercício 7:
                    // Fazer um programa para ler um número inteiro positivo N. O programa deve então mostrar na tela N linhas,
                    // começando de 1 até N. Para cada linha, mostrar o número da linha, depois o quadrado e o cubo do valor, conforme
                    // exemplo.

                    Console.Write("Entre com um inteiro positivo: ");
                    int valorN4 = int.Parse(Console.ReadLine());
                    if (valorN4 < 0) {
                        return;
                    }
                    Console.WriteLine("\n");
                    for (int i = 0; i < valorN4; i++) {
                        Console.WriteLine($"{i+1} {Math.Pow(i+1,2)} {Math.Pow(i+1,3)}");
                    }

                    break;
                default:
                    Console.WriteLine("Entrada inválida!");
                    break;
            }
        }
    }
}
