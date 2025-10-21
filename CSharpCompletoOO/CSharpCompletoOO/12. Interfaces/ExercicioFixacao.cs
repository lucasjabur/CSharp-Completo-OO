//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CSharpCompletoOO._12._Interfaces {

//    public class Contrato { // irá receber uma lista composta por itens do tipo Prestacao
//        // essas parcelas serão geradas por meio de um servico
//        public int Numero {  get; set; }
//        public DateTime Data {  get; set; }
//        public double ValorTotal {  get; set; }

//        public Contrato() { }
//        public Contrato(int numero, DateTime data, double valorTotal) {
//            Numero = numero;
//            Data = data;
//            ValorTotal = valorTotal;
//        }

//    }

//    public class Prestacao {
//        public DateTime DataAPagar { get; set; }
//        public double ValorAPagar { get; set; }
//    }

//    public class ServicoContrato {

//        public void ProcessarContrato(Contrato contrato, int meses) {

//        }
//    }

//    public class ServicoPaypal : IServicoPagamentoOnline {
//        public double TaxaPagamento(double quantidade) {

//        }

//        public double Juro(double quantidade, int meses) {

//        }
//    }

//    public interface IServicoPagamentoOnline {
//        public double TaxaPagamento(double quantidade);
//        public double Juro(double quantidade, int meses);
//    }

//    internal class ExercicioFixacao {
//        public static void MainX(string[] args) {
//            // Exercício de fixação:
//            // Uma empresa deseja automatizar o processamento de seus contratos. O processamento de um contrato
//            // consiste em gerar as parcelas a serem pagas para aquele contrato, com base no número de meses desejado.
//            // A empresa utiliza um serviço de pagamento online para realizar o pagamento das parcelas. Os serviços
//            // de pagamento online tipicamente cobram um juro mensal, bem como uma taxa por pagamento. O serviço
//            // no momento é o do PayPal, que aplica juros simples de 1% a cada parcela, mais uma taxa de pagamento
//            // de 2%.
//            // Fazer um programa para ler os dados de um contrato (número do contrato, data do contrato e valor total
//            // do contrato). Em seguida, o programa deve ler o número de meses para parcelamento do contrato, e daí
//            // gerar os registros de parcelas a serem pagas (data e valor), sendo a primeira parcela a ser paga um
//            // mês após a data do contrato, a segunda parcela dois meses após o contrato e etc. Mostrar os dados na tela.
//        }
//    }
//}
