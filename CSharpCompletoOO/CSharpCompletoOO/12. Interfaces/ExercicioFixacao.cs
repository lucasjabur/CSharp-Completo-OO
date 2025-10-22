using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._12._Interfaces {

    // implementar as classes de domínio
    public class Contrato {
        public int Numero {  get; set; }
        public DateTime Data {  get; set; }
        public double ValorTotal { get; set; }

        public List<Prestacao> Prestacoes { get; set; } = new List<Prestacao>();

        public Contrato() { }
        public Contrato(int numero, DateTime data, double valorTotal) {
            Numero = numero;
            Data = data;
            ValorTotal = valorTotal;
        }
    }

    public class Prestacao {
        public DateTime DataFim {  get; set; }
        public double Valor { get; set; }

        public Prestacao(DateTime dataFim, double valor) {
            DataFim = dataFim;
            Valor = valor;
        }
    }

    public class ServicoContrato {

        private IServicoPagamento _servicoPagamento;

        public ServicoContrato(IServicoPagamento servicoPagamento) {
            _servicoPagamento = servicoPagamento;
        }

        public void ProcessarContrato(Contrato contrato, int meses) {
            for (int i = 1; i <= meses; i++) {
                double juros = _servicoPagamento.JuroCalc((contrato.ValorTotal / meses), i);
                double valorComJuros = (contrato.ValorTotal / meses) + juros;

                double taxa = _servicoPagamento.TaxaPagamentoCalc(valorComJuros);
                double valorFinalParcela = valorComJuros + taxa;

                DateTime dataParcela = contrato.Data.AddMonths(i);
                contrato.Prestacoes.Add(new Prestacao(dataParcela, valorFinalParcela));
            }
        }
    }

    public class ServicoPaypal : IServicoPagamento {
        public double TaxaPagamentoCalc(double quantidade) {
            return quantidade * 0.02;
        }

        public double JuroCalc(double quantidade, int meses) {
            return quantidade * 0.01 * meses;
        }
    }

    public interface IServicoPagamento {
        public double TaxaPagamentoCalc(double quantidade);
        public double JuroCalc(double quantidade, int meses);
    }

    internal class ExercicioFixacao {
        public static void MainX(string[] args) {
            // Exercício de fixação:
            // Uma empresa deseja automatizar o processamento de seus contratos. O processamento de um contrato
            // consiste em gerar as parcelas a serem pagas para aquele contrato, com base no número de meses desejado.
            // A empresa utiliza um serviço de pagamento online para realizar o pagamento das parcelas. Os serviços
            // de pagamento online tipicamente cobram um juro mensal, bem como uma taxa por pagamento. O serviço
            // no momento é o do PayPal, que aplica juros simples de 1% a cada parcela, mais uma taxa de pagamento
            // de 2%.
            // Fazer um programa para ler os dados de um contrato (número do contrato, data do contrato e valor total
            // do contrato). Em seguida, o programa deve ler o número de meses para parcelamento do contrato, e daí
            // gerar os registros de parcelas a serem pagas (data e valor), sendo a primeira parcela a ser paga um
            // mês após a data do contrato, a segunda parcela dois meses após o contrato e etc. Mostrar os dados na tela.

            Console.WriteLine("Dados do contrato: ");
            Console.Write("Número do contrato: ");
            int numContrato = int.Parse(Console.ReadLine());

            Console.Write("Data do contrato: ");
            DateTime dataContrato = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Valor total do contrato: ");
            double valorTotal = double.Parse(Console.ReadLine());

            Console.Write("Número de meses que se deseja parcelar: ");
            int numMeses = int.Parse(Console.ReadLine());

            Contrato contrato = new Contrato(numContrato, dataContrato, valorTotal);
            ServicoContrato servicoContrato = new ServicoContrato(new ServicoPaypal());

            servicoContrato.ProcessarContrato(contrato, numMeses);

            int contador = 0;
            foreach(var prestacao in contrato.Prestacoes) {
                Console.WriteLine($"{++contador}. Data da prestação: {prestacao.DataFim:dd/MM/yyyy}, " +
                                  $"Valor da prestação: R$ {prestacao.Valor:F2}");
            }
        }
    }
}
