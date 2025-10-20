using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._9._Herança_e_Polimorfismo {
    internal class ClassesEMetodosSelados {
        public static void MainX(string[] args) {
            // A palavra reservada 'sealed' garante que a classe não possa ser herdada, porém ainda é possível
            // extender a funcionalidade de uma classe selada usando 'extension methods'.
            // Enquanto que, para os métodos, 'sealed' significa que um método sobreposto não possa ser
            // sobreposto novamente (só pode ser aplicado a métodos sobrepostos)

            // Classe selada:
            /*
                public sealed class ContaPoupanca : Conta {
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
                
                public class ContaPoupancaPlus : ContaPoupanca { } // --> Isso aqui gera um erro! Pois 'ContaPoupanca' é uma classe selada.
            */

            // Método selado:
            /*
                public sealed override void Saque(double quantidade) {
                    SaldoConta -= quantidade;
                } 
                
                // Esse método já era um método sobrescrito ('override').
                // Com a palavra chave 'sealed', agora ele não pode ser sobrescrito novamente
                // Ou seja, se eu criasse outra classe, por exemplo, que herda de 'Conta' e tentasse
                // sobrescrever o método 'Saque' para essa nova classe, o compilador vai me devolver um erro!
            */
        }
    }
}
