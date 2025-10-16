using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._6._Comportamento_de_Memória {
    internal class DesalocaçãoDeMemoria {
        // Garbage Collector:
        // Imagine a seguinte situação: 
        /*
            Product p1, p2
            p1 = new Product("TV", 2900.00, 0);
            p2 = new Product("Mouse", 150.00, 0);
              
            // Aqui, 'p1' é uma variável declarada na 'stack' e aponta para os valores inicializados
            // os quais estão armazenados na 'heap'. Isso também vale para 'p2'.
            
            p1 = p2;
            // Agora, o que aconteceu é que 'p1' aponta para o local da memória que 'p2' aponta, ou seja.
            // ambos referenciam o mesmo conteúdo (mesmo local de memória).
            // Porém, o valores que anteriormente eram apontados por 'p1' ainda estão alocados e ocupando
            // um espaço, teoricamente, desnecessário.

            // A linguagem C# possui o que é chamado de 'Garbage Collector', cujo papel é exatamente buscar
            // conteúdos alocados em memória que não estão mais sendo utilizados, a fim de desalocá-los
            // automaticamente.
        */

        // Desalocação por escopo:
        // Imagine o seguinte código:
        /*
            void method1() {
                int x = 10;
                if (x > 0) {
                    int y = 20;
                }
                Console.WriteLine(x);
            }

            // Aqui, a variável 'x' é declarada e inicializada (valor alocado na 'stack') dentro do escopo do 'method1()'.
            // Quando o fluxo do código entra no 'if() {...}', a variável 'y' é declarada e inicializada da mesma maneira que 'x' foi,
            // porém ela pertence ao escopo do 'if()'.
            // Quando o fluxo do código sai do 'if()' e chega na próxima instrução, a variável 'y' não existe mais, ela não pode ser
            // acessada, ou seja, ela foi desalocada da memória automaticamente. Porém, isso não é 'Garbage Collector', mas sim 
            // 'Desalocação por Escopo'.
        */  
    }
}
