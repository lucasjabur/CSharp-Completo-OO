using CSharpCompletoOO._8._Enumerações_e_Composição.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._8._Enumerações_e_Composição {

    internal class Trabalhador {
        public string Nome { get; set; }
        public CategoriaTrabalhador Categoria {  get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; } // associando departamento ao trabalhador
        public List<ContratoHora> Contratos { get; set; } = new List<ContratoHora>(); // associando trabalhador aos contratos e instanciando
        // a lista para garantir que ela não seja nula

        public Trabalhador() { }
        public Trabalhador(string nome, CategoriaTrabalhador categoria, double salarioBase, Departamento departamento) { 
            Nome = nome;
            Categoria = categoria;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarContrato(ContratoHora contrato) {
            Contratos.Add(contrato);
        }

        public void RemoverContrato(ContratoHora contrato) {
            Contratos.Remove(contrato);
        }

        public double Renda(int ano, int mes) {
            double soma = SalarioBase;
            foreach (var contrato in Contratos) {
                if (contrato.Data.Year == ano && contrato.Data.Month == mes) {
                    soma += contrato.ValorTotal();
                }
            }
            return soma;
        }
    }

    internal class ContratoHora {
        public DateTime Data {  get; set; }
        public double ValorPorHora { get; set; }
        public int Horas { get; set; }

        public ContratoHora() { }

        public ContratoHora(DateTime data, double valorPorHora, int horas) {
            Data = data;
            ValorPorHora = valorPorHora;
            Horas = horas;
        }

        public double ValorTotal() {
            return ValorPorHora * Horas;
        }
    }

    internal class Departamento {
        public string NomeDepartamento { get; set; }

        public Departamento() { }
        public Departamento(string nomeDepartamento) {
            NomeDepartamento = nomeDepartamento;
        }
    }
    internal class Exercicio {
        public static void MainX(string[] args) {
            // Exercício:
            // Ler os dados de um trabalhador com N contratos (N fornecido pelo usuário). Depois, solicitar do usuário um mês e
            // mostrar qual foi o salário do funcionário nesse mês.

            Console.Write("Entre com o nome do departamento: ");
            string nomeDep = Console.ReadLine();

            Console.WriteLine("\n\nDados do trabalhador... ");
            Console.Write("Nome: ");
            string nomeTrab = Console.ReadLine();

            Console.Write("Nível do trabalhador (Junior / Pleno / Senior): ");
            CategoriaTrabalhador categoria = Enum.Parse<CategoriaTrabalhador>(Console.ReadLine());

            Console.Write("Salário base do trabalhador: ");
            double salarioBase = double.Parse(Console.ReadLine());

            Departamento departamento = new Departamento(nomeDep);
            Trabalhador trabalhador = new Trabalhador(nomeTrab, categoria, salarioBase, departamento);



            Console.Write("Número de contratos para o trabalhador: ");
            int numContratos = int.Parse(Console.ReadLine());

            for (int i = 0; i < numContratos; i++) {
                Console.WriteLine($"\nEntre com os dados do {i + 1}° contrato: ");
                
                Console.Write("Data do contrato: ");
                DateTime data = DateTime.Parse(Console.ReadLine());

                Console.Write("Valor da hora trabalhada: ");
                double valorHora = double.Parse(Console.ReadLine());

                Console.Write("Horas a serem trabalhadas: ");
                int horas = int.Parse(Console.ReadLine());

                ContratoHora contrato = new ContratoHora(data, valorHora, horas);
                trabalhador.AdicionarContrato(contrato);
            }

            Console.WriteLine("Cálculo da renda do trabalhador: ");
            Console.Write("Entre com o mês e o ano para realização do cálculo: ");
            string mesEAno = Console.ReadLine();
            int mes = int.Parse(mesEAno.Substring(0, 2));
            int ano = int.Parse(mesEAno.Substring(0, 3));
            Console.WriteLine($"Nome: {trabalhador.Nome}, Departamento: {trabalhador.Departamento.NomeDepartamento}," +
                              $"Renda para {mesEAno}: R$ {(trabalhador.Renda(mes: mes, ano: ano)):F2}");

        }
    }
}
