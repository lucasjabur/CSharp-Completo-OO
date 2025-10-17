using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._6._Comportamento_de_Memória {

    public class Calculadora {
        public static void TriploComRef(ref int valorEntrada) {
            valorEntrada = valorEntrada * 3;
        }

        public static void TriploComOut(int valorOriginal, out int operacao) {
            operacao = valorOriginal * 3;
        }
    }
    internal class OperadoresRefOut {
        public static void MainX(string[] args) {
            int valor = 10;
            Calculadora.TriploComRef(ref valor);
            Console.WriteLine(valor);
            // Operador 'ref':
            // O que irá acontecer aqui:
            // O método 'TriploComRef()' não possui retorno, mas queremos que o valor calculado ali dentro seja recuperado
            // de alguma forma. Então, a ideia é que este valor seja armazenado dentro da própria variável 'valor'.
            // Se passarmos essa variável por referência para o método, tanto a variável 'valor' quanto a variável do método
            // 'valorEntrada' irão apontar para o mesmo local de memória. O que significa que a operação realizada ali dentro
            // do método irá armazenar o seu resultado nesse endereço de memória e a variável 'valor' conseguirá recuperá-lo.

            int valor2 = 20;
            int resultado;
            Calculadora.TriploComOut(valor2, out resultado);
            Console.WriteLine(valor2);
            Console.WriteLine(resultado);
            // Operador 'ou':
            // O que irá acontecer aqui:
            // O método 'TriploComOut()' não possui retorno também, mas, novamente, é necessário recuperar o valor da operação
            // realizada ali dentro. Porém sem atribuição de valores por referência, o que queremos agora é atribuição por valor!
            // Como funciona: a variável 'valor2' aponta para um endereço de memória, enquanto 'resultado' aponta para outro, por
            // enquanto vazio. Ambas as variáveis são passadas como argumento para o método, porém 'resultado' possui o operador
            // 'out'. Isso significa que o resultado da operação dentro do método será armazenado em 'operacao' e essa variável
            // estabelece uma conexão direta com a variável 'resultado' (conexão de mão única!), fazendo uma cópia do seu valor
            // para a variável 'resultado', a qual recebe esse valor em seu local de memória. Essas duas variáveis NÃO apontam
            // para o mesmo local de memória, e 'resultado' NÃO poderia manipular a variável 'operacao', como 'valor' poderia
            // manipular 'valorEntrada' no exemplo anterior, caso quisesse. Porém, 'operacao', de certa maneira, manipula
            // 'resultado', pois o valor que ela possuir 'resultado' receberá. Por isso é dito que o operador 'out' trabalha
            // em um único sentido, é unidirecional.
        }
    }
}
