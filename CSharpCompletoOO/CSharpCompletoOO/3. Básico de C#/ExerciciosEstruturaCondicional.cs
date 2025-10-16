using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpCompletoOO._3._Básico_de_C_ {
    internal class ExerciciosEstruturaCondicional {
        public static void MainX(string[] args) {
            Console.WriteLine("Menu:\n[1] Exercício 1\n[2] Exercício 2\n[3] Exercício 3" +
                              "\n[4] Exercício 4\n[5] Exercício 5\n[6] Exercício 6\n[7] Exercício 7\n[8] Exercício 8");
            Console.Write("Escolha uma opção: ");
            int option = int.Parse(Console.ReadLine());
            switch (option) {
                case 1:
                    Console.WriteLine("\n\n=== Exercício 1 em execução... ==============================");
                    // Exercício 1:
                    // Fazer um programa para ler um número inteiro, e depois dizer se este número é negativo ou não

                    Console.Write("Entre com um valor: ");
                    int valor = int.Parse(Console.ReadLine());

                    if (valor > 0) {
                        Console.WriteLine("O número é positivo!");
                    } else {
                        Console.WriteLine("O número é negativo!");
                    }

                    break;
                case 2:
                    Console.WriteLine("\n\n=== Exercício 2 em execução... ==============================");
                    // Exercício 2:
                    // Fazer um programa para ler um número inteiro e dizer se este número é par ou ímpar.

                    Console.Write("Entre com um valor: ");
                    int valor2 = int.Parse(Console.ReadLine());

                    if (valor2 % 2 == 0) {
                        Console.WriteLine("O número é par!");
                    } else {
                        Console.WriteLine("O número é ímpar!");
                    }

                    break;
                case 3:
                    Console.WriteLine("\n\n=== Exercício 3 em execução... ==============================");
                    // Exercício 3:
                    // Leia 2 valores inteiros (A e B). Após, o programa deve mostrar uma mensagem "Sao Multiplos" ou "Nao sao
                    // Multiplos", indicando se os valores lidos são múltiplos entre si. Atenção: os números devem poder ser digitados em
                    // ordem crescente ou decrescente.

                    Console.Write("Ente com o primeiro valor: ");
                    int valor3 = int.Parse(Console.ReadLine());

                    Console.Write("Ente com o segundo valor: ");
                    int valor4 = int.Parse(Console.ReadLine());

                    if (valor3 % valor4 == 0 || valor4 % valor3 == 0) {
                        Console.WriteLine("São múltiplos!");
                    } else {
                        Console.WriteLine("Não são múltiplos!");
                    }

                    break;
                case 4:
                    Console.WriteLine("\n\n=== Exercício 4 em execução... ==============================");
                    // Exercício 4:
                    // Leia a hora inicial e a hora final de um jogo. A seguir calcule a duração do jogo, sabendo que o mesmo pode
                    // começar em um dia e terminar em outro, tendo uma duração mínima de 1 hora e máxima de 24 horas..

                    Console.Write("Entre com a hora inicial: ");
                    int horaInicial = int.Parse(Console.ReadLine());

                    Console.Write("Entre com a hora final: ");
                    int horaFinal = int.Parse(Console.ReadLine());

                    if (horaInicial == horaFinal) {
                        Console.WriteLine("Duração do jogo: 24 horas.");
                    } else if (horaInicial > horaFinal) {
                        int tempoJogo = (24 - horaInicial) + horaFinal;
                        Console.WriteLine($"Duração do jogo: {tempoJogo}");
                    } else if (horaInicial < horaFinal) {
                        int tempoJogo = horaFinal - horaInicial;
                        Console.WriteLine($"Duração do jogo: {tempoJogo}");
                    }

                    break;
                case 5:
                    Console.WriteLine("\n\n=== Exercício 5 em execução... ==============================");
                    // Exercício 5:
                    // Com base na tabela abaixo, escreva um programa que leia o código de um item e a quantidade deste item. A
                    // seguir, calcule e mostre o valor da conta a pagar.

                    Console.Write("Entre com o código do item: ");
                    int codigo = int.Parse(Console.ReadLine());

                    Console.Write("Entre com a quantidade do item: ");
                    int qtde = int.Parse(Console.ReadLine());

                    double pagamento;

                    switch (codigo) {
                        case 1:
                            Console.WriteLine("Item selecionado: Cachorro Quente");
                            Console.WriteLine($"Quantidade: {qtde} unidades");
                            pagamento = 4.00 * qtde;
                            Console.WriteLine($"Total: R$ {pagamento:F2}");
                            break;
                        case 2:
                            Console.WriteLine("Item selecionado: X-Salada");
                            Console.WriteLine($"Quantidade: {qtde} unidades");
                            pagamento = 4.50 * qtde;
                            Console.WriteLine($"Total: R$ {pagamento:F2}");
                            break;
                        case 3:
                            Console.WriteLine("Item selecionado: X-Bacon");
                            Console.WriteLine($"Quantidade: {qtde} unidades");
                            pagamento = 5.00 * qtde;
                            Console.WriteLine($"Total: R$ {pagamento:F2}");
                            break;
                        case 4:
                            Console.WriteLine("Item selecionado: Torrada Simples");
                            Console.WriteLine($"Quantidade: {qtde} unidades");
                            pagamento = 2.00 * qtde;
                            Console.WriteLine($"Total: R$ {pagamento:F2}");
                            break;
                        case 5:
                            Console.WriteLine("Item selecionado: Refrigerante");
                            Console.WriteLine($"Quantidade: {qtde} unidades");
                            pagamento = 1.50 * qtde;
                            Console.WriteLine($"Total: R$ {pagamento:F2}");
                            break;
                        default:
                            Console.WriteLine("Item não disponível no cardápio!");
                            break;
                    }   
                    break;
                case 6:
                    Console.WriteLine("\n\n=== Exercício 6 em execução... ==============================");
                    // Exercício 6:
                    // Você deve fazer um programa que leia um valor qualquer e apresente uma mensagem dizendo em qual dos
                    // seguintes intervalos([0, 25], (25,50], (50, 75], (75, 100]) este valor se encontra. Obviamente se o valor não estiver em
                    // nenhum destes intervalos, deverá ser impressa a mensagem “Fora de intervalo”.

                    Console.Write("Entre com um valor qualquer: ");
                    double qualquer = double.Parse(Console.ReadLine());

                    if (qualquer >= 0 && qualquer <= 25) {
                        Console.WriteLine("Intervalo: [0 , 25]");
                    } else if (qualquer > 25 && qualquer <= 50) {
                        Console.WriteLine("Intervalo: (25, 50]");
                    } else if (qualquer > 50 && qualquer <= 75) {
                        Console.WriteLine("Intervalo: (50, 75]");
                    } else if (qualquer > 75 && qualquer <= 100) {
                        Console.WriteLine("Intervalo: (75, 100]");
                    } else {
                        Console.WriteLine("Fora de qualquer intervalo!");
                    }

                    break;

                case 7:
                    Console.WriteLine("\n\n=== Exercício 7 em execução... ==============================");
                    // Exercício 7:
                    // Leia 2 valores com uma casa decimal (x e y), que devem representar as coordenadas
                    // de um ponto em um plano. A seguir, determine qual o quadrante ao qual pertence o
                    // ponto, ou se está sobre um dos eixos cartesianos ou na origem(x = y = 0).
                    // Se o ponto estiver na origem, escreva a mensagem “Origem”.
                    // Se o ponto estiver sobre um dos eixos escreva “Eixo X” ou “Eixo Y”, conforme for a situação.

                    Console.Write("Entre com o valor da coordenada X: ");
                    double coordX = double.Parse(Console.ReadLine());

                    Console.Write("Entre com o valor da coordenada Y: ");
                    double coordY = double.Parse(Console.ReadLine());

                    if (coordX > 0 && coordY > 0) {
                        Console.WriteLine("Quadrante Q1");
                    } else if (coordX > 0 && coordY < 0) {
                        Console.WriteLine("Quadrante Q4");
                    } else if (coordX < 0 && coordY > 0) {
                        Console.WriteLine("Quadrante Q2");
                    } else if (coordX < 0 && coordY < 0) {
                        Console.WriteLine("Quadrante Q3");
                    } else {
                        Console.WriteLine("Origem");
                    }

                    break;

                case 8:
                    Console.WriteLine("\n\n=== Exercício 8 em execução... ==============================");
                    // Exercício 8:
                    // Em um país imaginário denominado Lisarb, todos os habitantes ficam felizes em pagar seus impostos, pois sabem
                    // que nele não existem políticos corruptos e os recursos arrecadados são utilizados em benefício da população, sem
                    // qualquer desvio. A moeda deste país é o Rombus, cujo símbolo é o R$.
                    // Leia um valor com duas casas decimais, equivalente ao salário de uma pessoa de Lisarb. Em seguida, calcule e
                    // mostre o valor que esta pessoa deve pagar de Imposto de Renda, segundo a tabela abaixo.

                    // Lembre que, se o salário for R$ 3002.00, a taxa que incide é de 8% apenas sobre R$ 1000.00, pois a faixa de
                    // salário que fica de R$ 0.00 até R$ 2000.00 é isenta de Imposto de Renda. No exemplo fornecido(abaixo), a taxa é
                    // de 8 % sobre R$ 1000.00 + 18 % sobre R$ 2.00, o que resulta em R$ 80.36 no total. O valor deve ser impresso com
                    // duas casas decimais.

                    Console.Write("Entre com o seu salário: ");
                    double salario = double.Parse(Console.ReadLine());

                    if (salario > 0 && salario <= 2000) {
                        Console.WriteLine("Isento!");
                    } else if (salario > 2000 && salario <= 3000) {
                        double parteNaoIsenta = salario - 2000;

                        double imposto = (parteNaoIsenta * 0.08);

                        Console.WriteLine($"Imposto: {imposto}");

                    } else if (salario > 3000 && salario <= 4500) {
                        double parteNaoIsenta = salario - 2000;
                        double segundaParte = parteNaoIsenta - 1000;

                        double primeiroIntervaloImposto = parteNaoIsenta - segundaParte; 

                        double imposto = (primeiroIntervaloImposto * 0.08) + (segundaParte * 0.18);

                        Console.WriteLine($"Imposto: {imposto}");

                    } else if (salario > 4500) {
                        double parteNaoIsenta = salario - 2000;
                        double segundaParte = parteNaoIsenta - 1000;
                        double terceiraParte = segundaParte - 1500;

                        double primeiroIntervaloImposto = parteNaoIsenta - segundaParte;
                        double segundoIntervaloImposto = segundaParte - terceiraParte;

                        double imposto = (primeiroIntervaloImposto * 0.08) + (segundoIntervaloImposto * 0.18) + (terceiraParte * 0.28);

                        Console.WriteLine($"Imposto: {imposto}");
                    }

                    break;
                default:
                    Console.WriteLine("Entrada inválida!");
                    break;
            }
        }
    }
}
