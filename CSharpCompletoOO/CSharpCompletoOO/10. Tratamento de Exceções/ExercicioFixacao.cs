using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._10._Tratamento_de_Exceções {

    public class Conta {
        public int Numero { get; set; }
        public string Titular { get; set; }
        public double Saldo { get; set; }
        public double LimiteSaque { get; set; }

        public Conta() { }

        public Conta(int numero, string titular, double saldo, double limiteSaque) {
            Numero = numero;
            Titular = titular;
            Saldo = saldo;
            LimiteSaque = limiteSaque;
        }

        public void Deposito(double quantidade) {
            Saldo += quantidade;
        }

        public void Saque(double quantidade) {
            if (Saldo < quantidade) {
                throw new NoBalanceEnoughException("Saldo na conta insuficiente para realizar o saque!");
            }
            if (quantidade > LimiteSaque) {
                throw new WithdrawBiggerThanLimitException("Quantidade desejada é superior ao limite de saque!");
            }
            Saldo -= quantidade;
        }
    }

    public class NoBalanceEnoughException : Exception {
        public NoBalanceEnoughException(string message) : base(message) { }
    }

    public class WithdrawBiggerThanLimitException : Exception {
        public WithdrawBiggerThanLimitException(string message) : base(message) { }
    }

    internal class ExercicioFixacao {
        public static void MainX(string[] args) {
            // Exercício de fixação:
            // Fazer um programa para ler os dados de uma conta bancária e depois realizar um saque nesta conta
            // bancária, mostrando o novo saldo. Um saque não pode ocorrer ou se não houver saldo na conta, ou 
            // se o valor do saque for superior ao limite de saque da conta.
            try {
                Console.WriteLine("Entre com os dados bancários: ");
                Console.Write("Número da conta: ");
                int numConta = int.Parse(Console.ReadLine());

                Console.Write("Nome do titular: ");
                string nomeTitular = Console.ReadLine();

                Console.Write("Saldo da conta: ");
                double saldo = double.Parse(Console.ReadLine());

                Console.Write("Limite de saque da conta: ");
                double limite = double.Parse(Console.ReadLine());

                Conta conta = new Conta(numConta, nomeTitular, saldo, limite);

                Console.WriteLine("\nRealizando saque...");
                Console.Write("Quanto deseja sacar: R$ ");
                double valor = double.Parse(Console.ReadLine());

                conta.Saque(valor);
                Console.WriteLine($"Saldo atualizado: R$ {conta.Saldo:F2}");
            } catch (NoBalanceEnoughException ex) {
                Console.WriteLine($"Erro: {ex.Message}");
            } catch (WithdrawBiggerThanLimitException ex) {
                Console.WriteLine($"Erro: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
