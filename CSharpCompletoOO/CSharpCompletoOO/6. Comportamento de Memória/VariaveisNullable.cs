using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._6._Comportamento_de_Memória {
    internal class VariaveisNullable {
        // Variáveis Nullable:
        // Por padrão, o C# não permite a atribuição do valor 'null' para as variáveis.
        // Porém, existem casos em que é desejado deixar a variável sem nenhum valor inicialmente, como é o caso
        // de atributos opcionais, por exemplo.
        // Para isso, existe a seguinte notação:
        /*
            // Existem duas maneiras de se declarar uma variável Nullable:
            // 1° método: menos convencional

            Nullable<double> varNullable = null;
            
        
            // 2° método: mais comum
            
            double? varNull1 = null;
            double? varNull2 = 10;
            
            // Métodos para se utilizar com variáveis Nullable:
            Console.WriteLine(varNull1.GetValueOrDefault()); --> retorna o valor da variável ou o padrão de seu tipo caso seja 'null'.
            Console.WriteLine(varNull2.GetValueOrDefault()); --> nesse caso, retornaria '10', pois varNull2 é Nullable, mas não possui valor 'null'.

            Console.WriteLine(varNull1.HasValue()); --> retorna 'false' se for 'null' e 'true' se não for 'null'
            Console.WriteLine(varNull2.HasValue()); --> nesse caso, retornaria 'true', pois possui o valor '10' atribuído.

            Console.WriteLine(varNull1.Value); --> retorna uma exceção se a variável que está chamando-a vale 'null'.
            Console.WriteLine(varNull2.Value); --> nesse caso, retornaria '10', pois é valor atribuído à variável.
        */

        // Operador de Coalescência Nula:
        /*
            double? varNull1 = null;
            double? varNull2 = varNull1 ?? 0.0;
            
            // Isto é, ambas as variáveis são Nullable e 'varNull1' é 'null'.
            // 'varNull2' receberá o valor de 'varNull1' caso esse não seja 'null', caso contrário, 'varNull2' receberá '0.0' como valor.
            // É isso que esse operador faz, é semelhante, em termos bem gerais, ao Operador Ternário.

        */
    }
}
