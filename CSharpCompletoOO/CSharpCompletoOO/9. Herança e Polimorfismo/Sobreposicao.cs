using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._9._Herança_e_Polimorfismo {
    internal class Sobreposicao {
        // Imagine agora que o saque de uma conta possui uma taxa de R$ 5,00.
        // A conta empresarial possui essa taxação, porém a conta poupança não.
        // A operação de saque de ambas as contas vem da mesma classe (classe 'Conta'),
        // porém ambas terão implementações distintas.

        // Isso é possível de ser feito de duas maneiras:
        // 1ª maneira: sobrescrevendo a implementação pai ***
        // Aqui existe a necessidade de se utilizar a palavra reservada 'override' na assinatura do método
        // assim como a palavra reservada 'virtual' na assinatura do método na superclasse
        /*
            public override void Saque(double quantidade) {
                SaldoConta -= quantidade;
            } 
        */

        // 2ª maneira: ocultando o método da superclasse
        /*
            public new void Saque(double quantidade) {
                SaldoConta -= quantidade;
            } 
        */

    }
}
