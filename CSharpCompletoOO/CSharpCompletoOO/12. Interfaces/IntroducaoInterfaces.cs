using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._12._Interfaces {
    internal class IntroducaoInterfaces {
        public static void MainX(string[] args) {
            // Interfaces: tipo que define um conjunto de operações que uma classe ou struct deve implementar
            // A interface estabelece um contrato que a classe deve cumprir
            // Objetivo: criação de sistemas de baixo acoplamento e flexíveis

            // Problema exemplo:
            // Uma locadora de carros cobra um valor por hora para locações de até 12 horas. Porém, se a duração da locação
            // ultrapassar 12 horas, a locação será cobrada com base em um valor diário. Além do valor da locação, é acrescido
            // no preço o valor do imposto conforme regras do país, que no caso é de 20% para valores até R$ 100,00 ou 15% para
            // valores acima de R$ 100,00. Fazer um programa que lê os dados da locação (modelo do carro, instante inicial e
            // final da locação), bem como o valor por hora e o valor diário de locação. O programa deve então gerar a nota
            // de pagamento (contendo o valor da locação, valor do imposto e o valor total do pagamento) e informar os dados
            // na tela.

        }
    }
}
