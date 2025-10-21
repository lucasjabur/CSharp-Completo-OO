using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._13._Generics__Set__Dictionary {
    internal class IgualdadeColecoesHash {
        // Se 'GetHashCode' e 'Equals' estiverem implementados:
        // o 'GetHashCode' será utilizado para realizar a comparação de igualdade, e aí se der igual
        // o 'Equals' é utilizado para confirmar.

        // Se 'GetHashCode' e 'Equals' não estiverem implementados:
        // Tipos referência: compara as referências dos objetos
        // - exemplo: criei uma classe 'Produto' e não implementei o 'GetHashCode' e nem o 'Equals'
        //   o que será realizado é a comparação de referência de memória do objeto (espaço de memória
        //   em que está armazenado)
        // Tipos valor: comparar os valores dos atributos
        // - exemplo: uma struct, a comparação é realizada pelos valores dos atributos
    }
}
