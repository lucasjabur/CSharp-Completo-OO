using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._10._Tratamento_de_Exceções {

    public class Reserva {
        public int NumeroQuarto { get; set; }
        public DateTime CheckIn {  get; set; }
        public DateTime CheckOut { get; set; }

        public Reserva() { }

        public Reserva(int numeroQuarto, DateTime checkIn, DateTime checkOut) {
            if (checkOut < checkIn) {
                throw new DomainException("As datas de check-out devem vir após a data de check-in!");
            }
            NumeroQuarto = numeroQuarto;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duracao() {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void AtualizarDatas(DateTime checkIn, DateTime checkOut) {
            DateTime now = DateTime.Now;
            if (checkIn < now || checkOut < now) {
                throw new DomainException("As datas só podem ser atualizar com data futuras!");
            }
            if (checkOut < checkIn) {
                throw new DomainException("As datas de check-out devem vir após a data de check-in!");
            }

            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public override string ToString() {
            return $"Quarto: {NumeroQuarto}," +
                   $"Data de check-in: {CheckIn.ToString("dd/MM/yyyy")}, " +
                   $"Data de check-out: {CheckOut.ToString("dd/MM/yyyy")}, " +
                   $"Duração: {Duracao()} noites.";
        }
    }

    public class DomainException : ApplicationException {
        public DomainException(string message) : base(message) { }
    }

    internal class ExcecoesPersonalizadas {
        public static void MainX(string[] args) {
            // Problema exemplo: 
            // Fazer um programa para ler os dados de uma reserva de hotel (número de quarto, data de entrada e 
            // data de saída) e mostrar os dados da reserva, inclusive a sua duração em dias.
            // Em seguida, ler novas datas de entrada e de saída, atualizar a reserva, e mostrar novamente a
            // reserva com os dados atualizados. O programa não deve aceitar dados inválidos para a reserva,
            // conforme as seguintes regras:
            // - Alterações de reservas só podem ocorrer para datas futuras
            // - A data de saída deve ser maior que a data de entrada
            try {
                Console.Write("Entre com o número do quarto: ");
                int numQuarto = int.Parse(Console.ReadLine());

                Console.Write("Check-in: ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());

                Console.Write("Check-out: ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                Reserva reserva = new Reserva(numQuarto, checkIn, checkOut);
                Console.WriteLine("\nExibindo os dados...");
                Console.WriteLine(reserva);

                Console.WriteLine("\n\nAtualizar as datas...");
                Console.Write("Nova data de check-in: ");
                checkIn = DateTime.Parse(Console.ReadLine());

                Console.Write("Nova data de check-out: ");
                checkOut = DateTime.Parse(Console.ReadLine());

                reserva.AtualizarDatas(checkIn, checkOut);

                Console.WriteLine("\nExibindo os dados atualizados...");
                Console.WriteLine(reserva);
            } catch (DomainException ex) {
                Console.WriteLine($"Erro ao realizar reserva: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine($"Erro inesperado: {ex.Message}"); // todas exceção irá casar com 'Exception' por 
                // , pois é tipo mais genérico.
            }
        }
    }
}
