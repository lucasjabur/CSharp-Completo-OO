using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._9._Herança_e_Polimorfismo {

    public class ContaPoupanca : Conta {
        public double TaxaDeRendimento { get; set; }
        
        public ContaPoupanca() { }

        public ContaPoupanca(int numeroConta, string titularConta, double saldoConta, double taxaDeRendimento)
            : base(numeroConta, titularConta, saldoConta) {
            TaxaDeRendimento = taxaDeRendimento;
        }

        public void AtualizarSaldo() {
            SaldoConta += SaldoConta * TaxaDeRendimento;
        }

        public override void Saque(double quantidade) {
            // *** continuação 'Sobreposicao.cs' --> método 'Main()'
            SaldoConta -= quantidade;
        }
    }
    internal class UpcastingEDowncasting {
    }
}
