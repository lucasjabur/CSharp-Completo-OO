using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._3._Básico_de_C_ {
    internal class ExercicioEstruturaSequencial {
        public static void Main(string[] args) {
            Console.WriteLine("Menu:\n[1] Exercício 1\n[2] Exercício 2\n[3] Exercício 3" +
                              "\n[4] Exercício 4\n[5] Exercício 5\n[6] Exercício 6");
            Console.Write("Escolha uma opção: ");
            int option = int.Parse(Console.ReadLine());
            switch (option) {
                case 1:
                    Console.WriteLine("\n\n=== Exercício 1 em execução... ==============================");
                    // Exercício 1:
                    // Faça um programa para ler dois valores inteiros, e depois mostrar na tela a soma desses números com uma
                    // mensagem explicativa, conforme exemplos

                    Console.Write("Valor 1: ");
                    int valor1 = int.Parse(Console.ReadLine());

                    Console.Write("Valor 2: ");
                    int valor2 = int.Parse(Console.ReadLine());

                    int soma = valor1 + valor2;

                    Console.WriteLine($"Soma: {soma}");

                    break;
                case 2:
                    Console.WriteLine("\n\n=== Exercício 2 em execução... ==============================");
                    // Exercício 2:
                    // Faça um programa para ler o valor do raio de um círculo, e depois mostrar o valor da área deste círculo com quatro
                    // casas decimais conforme exemplos.
                    // Fórmula da área: area = π.raio2
                    // Considere o valor de π = 3.14159

                    const double PI = 3.14159;
                    Console.Write("Raio: ");
                    double raio = double.Parse(Console.ReadLine());
                    double area = PI * raio * raio;
                    Console.WriteLine($"Área: {area:F4}");

                    break;
                case 3:
                    Console.WriteLine("\n\n=== Exercício 3 em execução... ==============================");
                    // Exercício 3:
                    // Fazer um programa para ler quatro valores inteiros A, B, C e D. A seguir, calcule e mostre a diferença do produto
                    // de A e B pelo produto de C e D segundo a fórmula: DIFERENCA = (A * B - C * D).

                    Console.Write("Valor 1: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("Valor 2: ");
                    int b = int.Parse(Console.ReadLine());
                    Console.Write("Valor 3: ");
                    int c = int.Parse(Console.ReadLine());
                    Console.Write("Valor 4: ");
                    int d = int.Parse(Console.ReadLine());

                    int dif = (a * b) - (c * d);
                    Console.WriteLine($"Diferença dos produtos: {dif}");

                    break;
                case 4:
                    Console.WriteLine("\n\n=== Exercício 4 em execução... ==============================");
                    // Exercício 4:
                    // Fazer um programa que leia o número de um funcionário, seu número de horas trabalhadas, o valor que recebe por
                    // hora e calcula o salário desse funcionário.A seguir, mostre o número e o salário do funcionário, com duas casas
                    // decimais.
                    Console.Write("Número do funcionário: ");
                    int funcNum = int.Parse(Console.ReadLine());
                    Console.Write("Horas trabalhadas: ");
                    double horasTrab = double.Parse(Console.ReadLine());
                    Console.Write("Valor ganho por hora trabalhada: ");
                    double valorHora = double.Parse(Console.ReadLine());

                    double salario = horasTrab * valorHora;
                    Console.WriteLine($"O funcionário '{funcNum}' ganha como salário R$ {salario:F2}");

                    break;
                case 5:
                    Console.WriteLine("\n\n=== Exercício 5 em execução... ==============================");
                    // Exercício 5:
                    // Fazer um programa para ler o código de uma peça 1, o número de peças 1, o valor unitário de cada peça 1, o
                    // código de uma peça 2, o número de peças 2 e o valor unitário de cada peça 2.Calcule e mostre o valor a ser pago.
                    Console.Write("Código peça 1: ");
                    int codP1 = int.Parse(Console.ReadLine());
                    Console.Write("Número de peças 1: ");
                    int numDeP1 = int.Parse(Console.ReadLine());
                    Console.Write("Valor unitário peça 1: ");
                    double unitValP1 = double.Parse(Console.ReadLine());

                    Console.Write("\nCódigo peça 2: ");
                    int codP2 = int.Parse(Console.ReadLine());
                    Console.Write("Número de peças 2: ");
                    int numDeP2 = int.Parse(Console.ReadLine());
                    Console.Write("Valor unitário peça 2: ");
                    double unitValP2 = double.Parse(Console.ReadLine());

                    double valTotal = (numDeP1 * unitValP1) + (numDeP2 * unitValP2);

                    Console.WriteLine($"\nResumo da compra: ");
                    Console.WriteLine($"    {codP1}: {numDeP1} unidades a R$ {unitValP1:F2} por peça");
                    Console.WriteLine($"    {codP2}: {numDeP2} unidades a R$ {unitValP2:F2} por peça");
                    Console.WriteLine($"\nTotal a pagar: R$ {valTotal:F2}");

                    break;
                case 6:
                    Console.WriteLine("\n\n=== Exercício 5 em execução... ==============================");
                    // Exercício 6:
                    // Fazer um programa que leia três valores com ponto flutuante de dupla precisão: A, B e C. Em seguida, calcule e
                    // mostre:
                    //    a) a área do triângulo retângulo que tem A por base e C por altura.
                    //    b) a área do círculo de raio C. (pi = 3.14159)
                    //    c) a área do trapézio que tem A e B por bases e C por altura.
                    //    d) a área do quadrado que tem lado B.
                    //    e) a área do retângulo que tem lados A e B.
                    Console.Write("Valor 1: ");
                    double A = double.Parse(Console.ReadLine());
                    Console.Write("Valor 2: ");
                    double B = double.Parse(Console.ReadLine());
                    Console.Write("Valor 3: ");
                    double C = double.Parse(Console.ReadLine());

                    double areaTri = (A * C) / 2;
                    Console.WriteLine($"\nÁrea do triângulo: {areaTri:F2}");

                    double areaCirc = PI * Math.Pow(C, 2);
                    Console.WriteLine($"\nÁrea do círculo: {areaCirc:F2}");

                    double areaTrap = ((A + B) * C) / 2;
                    Console.WriteLine($"\nÁrea do trapézio: {areaTrap:F2}");

                    double areaQuad = Math.Pow(B, 2);
                    Console.WriteLine($"\nÁrea do quadrado: {areaQuad:F2}");

                    double areaRet = A * B;
                    Console.WriteLine($"\nÁrea do retângulo: {areaRet:F2}");

                    break;
                default:
                    Console.WriteLine("Entrada inválida!");
                    break;
            }
        }
    }
}
