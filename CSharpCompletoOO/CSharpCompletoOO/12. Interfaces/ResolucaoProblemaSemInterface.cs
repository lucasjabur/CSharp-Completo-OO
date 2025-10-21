using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._12._Interfaces {

    public class AluguelCarro {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public Veiculo Automovel { get; private set; }
        public NotaDePagamento NotaPagamento { get; set; }

        public AluguelCarro() { }
        public AluguelCarro(DateTime inicio, DateTime fim, Veiculo automovel) {
            // A nota de pagamento não entra aqui pois será iniciada como 'null', pois é apenas gerada quando
            // o aluguel do carro for processado!
            Inicio = inicio;
            Fim = fim;
            Automovel = automovel;
        }
    }

    public class Veiculo {
        public string Modelo { get; set; }

        public Veiculo() { }
        public Veiculo(string modelo) {
            Modelo = modelo;
        }
    }

    public class NotaDePagamento {
        public double PagamentoBase { get; set; }
        public double Imposto { get; set; }

        public NotaDePagamento(double pagamentoBase, double imposto) {
            PagamentoBase = pagamentoBase;
            Imposto = imposto;
        }

        public double PagamentoTotal { // propriedade calculada
            get { return PagamentoBase + Imposto; }
        }

        public override string ToString() {
            return $"Pagamento base: R$ {PagamentoBase:F2}, " +
                   $"Imposto: R$ {Imposto:F2}, " +
                   $"Pagamento total: R$ {PagamentoTotal:F2}";
        }
    }

    public class ServicoAluguel {
        public double PrecoPorHora { get; set; }
        public double PrecoPorDia { get; set; }

        // private ServicoImpostoBrasil _servicoImpostoBrasil = new ServicoImpostoBrasil(); --> dependência muito forte! Manutenção ineficiente
        private IServicoImposto _servicoImposto;

        public ServicoAluguel(double precoHora, double precoDia, IServicoImposto servicoImposto) {
            // inversão de controle por meio de injeção de dependência
            // A classe em si não mais instância o objeto, ela recebe o objeto já instanciado e o atribui
            PrecoPorHora = precoHora;
            PrecoPorDia = precoDia;
            _servicoImposto = servicoImposto;
        }
        public void ProcessarPagamento(AluguelCarro aluguel) {
            TimeSpan duracao = aluguel.Fim.Subtract(aluguel.Inicio);
            double pagamentoBase = 0.0;

            if (duracao.TotalHours <= 12.0) {
                pagamentoBase = PrecoPorHora * Math.Ceiling(duracao.TotalHours); // arredondar para cima
            } else {
                pagamentoBase = PrecoPorDia * Math.Ceiling(duracao.TotalDays);
            }

            double imposto = _servicoImposto.Imposto(pagamentoBase);
            aluguel.NotaPagamento = new NotaDePagamento(pagamentoBase, imposto);
        }
    }

    public class ServicoImpostoBrasil : IServicoImposto {
        public double Imposto(double quantidade) {
            if (quantidade <= 100.0) {
                return quantidade * 0.2;
            } else {
                return quantidade * 0.15;
            }
        }
    }
    internal class ResolucaoProblemaSemInterface {
        public static void MainX(string[] args) {
            Console.WriteLine("Entre com os dados do aluguel: ");

            Console.Write("Modelo do carro: ");
            string modelo = Console.ReadLine();

            Console.Write("Data inicial: ");
            DateTime inicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);


            Console.Write("Data fim: ");
            DateTime fim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Preço por hora: ");
            double precoHora = double.Parse(Console.ReadLine());

            Console.Write("Preço por dia: ");
            double precoDia = double.Parse(Console.ReadLine());

            AluguelCarro aluguel = new AluguelCarro(inicio, fim, new Veiculo(modelo));
            ServicoAluguel servico = new ServicoAluguel(precoHora, precoDia, new ServicoImpostoBrasil());

            servico.ProcessarPagamento(aluguel);

            Console.WriteLine("Nota de Pagamento: ");
            Console.WriteLine(aluguel.NotaPagamento);
        }
    }
}
