using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._4._Básico_de_OO {

    public static class ConversorDeMoeda {
        public static double CotacaoDolar;
        public static double ValorDolar;
        private const double IOF = 0.06;

        public static double ValorAPagar() {
            double valor = CotacaoDolar * ValorDolar;
            valor += (valor * IOF);
            return valor;
        }
    }
    internal class ExercicioMembrosEstaticos {
        public static void MainX(string[] args) {
            // Exercício de fixação:
            // Faça um programa para ler a cotação do dólar, e depois um valor em dólares a ser comprado por uma pessoa em reais.
            // Informar quantos reais a pessoa vai pagar pelos dólares, considerando ainda que a pessoa terá que pagar 6% de IOF
            // sobre o valor em dólar.

            Console.Write("Qual a cotação do dólar? ");
            ConversorDeMoeda.CotacaoDolar = double.Parse(Console.ReadLine());

            Console.Write("Quantos dólares você deseja comprar? ");
            ConversorDeMoeda.ValorDolar = double.Parse(Console.ReadLine());

            Console.WriteLine($"Valor a ser pago: R$ {ConversorDeMoeda.ValorAPagar():F2}");

        }
    }
}
