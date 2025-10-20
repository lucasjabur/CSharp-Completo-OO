using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._9._Herança_e_Polimorfismo {

    public class Conta {
        public int NumeroConta { get; private set; } // essa variável pode apenas ser acessada pela subclasse, mas não alterada
        public string TitularConta { get; private set; } // aqui a mesma coisa que a variável de cima
        public double SaldoConta { get; protected set; } // já aqui, a alteração pode ser feita na subclasse, mas não no 'Main()', por exemplo

        public Conta() { }

        public Conta(int numeroConta, string titularConta, double saldoConta) {
            NumeroConta = numeroConta;
            TitularConta = titularConta;
            SaldoConta = saldoConta;
        }

        public virtual void Saque(double quantidade) {
            SaldoConta -= quantidade + 5.0;
        }

        public void Deposito(double quantidade) {
            SaldoConta += quantidade;
        }
    }

    public class ContaEmpresarial : Conta {
        public double LimiteEmprestimo { get; set; }

        // No construtor da subclasse, ao invés de reimplementar os atributos da superclasse, basta utilizar 
        // o comando 'base()', o qual importa o construtor da superclasse que já possui os atributos implementados.
        public ContaEmpresarial(int numeroConta, string titularConta, double saldoConta, double limiteEmprestimo)
            : base(numeroConta, titularConta, saldoConta) { 
            LimiteEmprestimo = limiteEmprestimo;
        }

        public void Emprestimo(double quantidade) {
            if (quantidade <= LimiteEmprestimo) {
                SaldoConta += quantidade;
            }
        }
    }
    internal class Heranca {
        public static void MainX(string[] args) {
            Conta conta1 = new Conta(1001, "Lucas", 0.0);
            ContaEmpresarial contaEmp1 = new ContaEmpresarial(2002, "Manuela", 0.0, 500.0);

            // Upcasting: conversão da subclasse para a superclasse
            Conta conta2 = contaEmp1;
            Conta conta3 = new ContaEmpresarial(3003, "Isabela", 0.0, 250.0);
            Conta conta4 = new ContaPoupanca(4004, "Lisa", 0.0, 0.01);

            // Downcasting: conversão da superclasse para a subclasse
            // 'ContaEmpresarial conta5 = conta3;' --> isso gera um erro, pois o compilador está enxergando que os tipos são diferentes
            // os tipos 'ContaEmpresarial' e 'Conta' são diferentes, ele não vê que 'conta3' está sendo instanciada como uma
            // 'ContaEmpresarial'. 
            // Para dar certo, tem que fazer uma conversão explícita (casting):
            ContaEmpresarial conta5 = (ContaEmpresarial)conta3;

            // O downcasting é uma operação insegura, por exemplo:
            // 'ContaEmpresarial conta6 = (ContaEmpresarial)conta4;' --> isso gera erro em tempo de execução, apenas!
            // Aqui no código aparentemente está tudo certo, mas depois que o código for executado uma exceção será gerada.
            // Para garantir que o downcasting não irá gerar erros, deve fazer:
            if (conta4 is ContaEmpresarial) { // quer dizer: 'conta4' é instância de 'ContaEmpresarial'?
                ContaEmpresarial conta6 = (ContaEmpresarial)conta4;
                // Outra maneira de fazer o casting:
                ContaEmpresarial conta7 = conta4 as ContaEmpresarial;
            }
        } 
    }
}
