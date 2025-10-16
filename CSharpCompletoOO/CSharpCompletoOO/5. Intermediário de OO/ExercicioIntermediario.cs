using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._5._Intermediário_de_OO {

    public class ContaBancaria() {
        public int NumeroDaConta { get; private set; } // 'private set' reforça que o 'NumeroDaConta' não pode ser alterado!
        public string NomeDoTitular { get; set; }
        public double SaldoDaConta { get; private set; } // 'SaldoDaConta' só poder ser alterado por manipulação de métodos

        public ContaBancaria(int numeroDaConta, string nomeDoTitular) : this() { // 'this()' chama o construtor padrão (está implícito)
            NumeroDaConta = numeroDaConta;
            NomeDoTitular = nomeDoTitular;
        }

        public ContaBancaria(int numeroDaConta, string nomeDoTitular, double depositoInicial) : this(numeroDaConta, nomeDoTitular) {
            // aqui, o 'this(...)' chama o construtor anteriormente definido de forma explícita e seus parâmetros já definidos
            RealizarDeposito(depositoInicial); // operação mais eficiente em relação à manutenção do código.
            // se a lógica de depósito está encapsulada no método 'RealizarDeposito()', por que fazer uam atribuição direta?
                // 'SaldoDaConta = depositoInicial;' --> não gera erro, mas é menos eficiente
        }

        public bool QuantiaEValida(double valor) {
            if (valor < 0) {
                Console.WriteLine("Não é possível depositar um valor negativo!");
                return false;
            }
            return true;
        }

        public void RealizarDeposito(double quantiaADepositar) {
            bool retornoValidacao = QuantiaEValida(quantiaADepositar);
            if (retornoValidacao) {
                SaldoDaConta += quantiaADepositar;
            }
        }

        public void RealizarSaque(double quantiaASacar) {
            bool retornoValidacao = QuantiaEValida(quantiaASacar); // lembrando que o enunciado diz que é possível sacar quantidades
                                                                   // acima do saldo disponível!
            if (retornoValidacao) {
                SaldoDaConta -= quantiaASacar;
                SaldoDaConta -= 5.0; // equivalente à taxa definida no enunciado do exercício
            }   
        }

        public override string ToString() {
            return $"Conta {NumeroDaConta}, Titular: {NomeDoTitular}, Saldo: R$ {SaldoDaConta:F2}";
        }

    }
    internal class ExercicioIntermediario {
        public static void Main(string[] args) {
            // Exercício que explora detalhes intermediários importantes de OO:
            /*
                Em um banco, para se cadastrar uma conta bancária, é necessário informar o número da conta, o nome do titular
                da conta, e o valor de depósito inicial que o titular depositou ao abrir a conta. Esse valor de depósito inicial,
                entretando, é opcional, ou seja: se o titular não tiver dinheiro para depósitar no momento de abrir sua conta, 
                o depósito inicial não será feito e o saldo inicial da conta será, naturalmente, zero.

                Importante: uma vez que uma conta bancária foi aberta, o número da conta nunca poderá ser alterado. Já o nome do
                titular pode ser alterado (pois uma pessoa pode mudar de nome por ocasião de casamento, por exemplo).

                Por fim, o saldo da conta não poder ser alterado livremente. É preciso haver um mecanismo para proteger isso. O
                saldo só aumenta por meio de depósitos, e só diminui por meio de saques. Para cada saque realizado, o banco cobra
                uma taxa de $ 5.00. Nota: a conta pode ficar com saldo negativo se o saldo não for suficiente para realizar o saque
                e/ou pagar a taxa.

                Você deve fazer um programa que realize o cadastro de uma conta, dando opção para que seja ou não informado o valor de
                depósito inicial. Em sequida, realizar uma depósito e depois um saque, sempre mostrando os dados da conta após cada
                operação.
            */

            ContaBancaria conta;

            Console.Write("Entre com o número da conta: ");
            int numeroDaConta = int.Parse(Console.ReadLine());

            Console.Write("Entre com o nome do titular: ");
            string nomeDoTitular = Console.ReadLine();

            Console.Write("Haverá depósito inicial (S/N)? ");
            char resposta = char.Parse(Console.ReadLine());
            if (resposta == 'S' || resposta == 's') {
                Console.Write("Entre com o valor do depósito inicial: ");
                double depositoInicial = double.Parse(Console.ReadLine());
                conta = new ContaBancaria(numeroDaConta, nomeDoTitular, depositoInicial);
            } else {
                conta = new ContaBancaria(numeroDaConta, nomeDoTitular);
            }

            Console.WriteLine();
            Console.WriteLine("\nDados da conta:");
            Console.WriteLine(conta);

            Console.WriteLine("\n\nRealizando depósito...");
            Console.Write("Entre com o valor que se deseja depositar: R$ ");
            double deposito = double.Parse(Console.ReadLine());

            conta.RealizarDeposito(deposito);

            Console.WriteLine();
            Console.WriteLine("\nDados atualizados da conta:");
            Console.WriteLine(conta);

            Console.WriteLine("\n\nRealizando saque...");
            Console.Write("Entre com o valor que se deseja sacar: R$ ");
            double saque = double.Parse(Console.ReadLine());

            conta.RealizarSaque(saque);

            Console.WriteLine();
            Console.WriteLine("\nDados atualizados da conta:");
            Console.WriteLine(conta);
        }
    }
}
