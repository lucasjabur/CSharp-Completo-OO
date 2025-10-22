using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._14._Tópicos_Avançados_C_ {

    public static class StringExtensions {
        public static string Cut(this String thisObj, int valor) {
            if (thisObj.Length <= valor) {
                return thisObj;
            } else {
                return thisObj.Substring(0, valor) + "...";
            }
        }  
    }

    public static class DateTimeExtensions {
        public static string ElapsedTime(this DateTime thisObj) {
            TimeSpan duracao = DateTime.Now.Subtract(thisObj);
            if (duracao.TotalHours < 24) {
                return duracao.TotalHours.ToString("F1") + " horas";
            } else {
                return duracao.TotalDays.ToString("F1") + " dias";
            }
        }
    }
    internal class ExtensionMethods {
        public static void MainX(string[] args) {
            // Métodos de extensão:
            // Estendem a funcionalidade de um tipo, sem precisar alterar o código fonte deste tipo, nem herdar desse tipo.

            DateTime dt = new DateTime(2025, 10, 16, 6, 10, 45);
            Console.WriteLine(dt.ElapsedTime());

            string str = "Olá, meus caros amigos!";
            Console.WriteLine(str.Cut(10));
        }
    }
}
