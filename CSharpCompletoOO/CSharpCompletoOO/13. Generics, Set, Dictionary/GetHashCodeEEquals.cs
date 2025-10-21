using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._13._Generics__Set__Dictionary {
    
    public class Cliente {
        public string Nome { get; set; }
        public string Email { get; set; }

        public override bool Equals(object? obj) {
            if (!(obj is Cliente)) return false;
            Cliente cli = obj as Cliente;
            return Email.Equals(cli.Email);
        }

        public override int GetHashCode() {
            return Email.GetHashCode();
        }
    }

    internal class GetHashCodeEEquals {
        // Operações da classe 'Object' utilizadas para comparar se um objeto é igual ao outro.
        // 'Equals': mais lento e a resposta é 100% garantida
        // 'GetHashCode': rápido, porém positiva não é 100% garantida
        // Os tipos predefinidos já possuem implementação para essas operações.
        // Classes e structs personalizadas precisam sobrepô-las.

        // Detalhe sobre o 'GetHashCode':
        // Se o código hash de dois objetos for diferente, então os dois objetos são com certeza diferentes!
        // Se o código hash for igual, muito provavelmente os objetos são iguais. Não é certeza absoluta! Mas na maioria das vezes
        // serão sim iguais. É por isso que é utilizado o 'GetHashCode' para filtrar os valores dentro do conjunto de dados
        // (por ser mais rápido que o 'Equals') e usa-se o 'Equals' para fazer a comparação final, por entregar a resposta 
        // correta caso positivo 100% das vezes.

        public static void MainX(string[] args) {
            // Exemplo:
            // Definição de um critério personalizado de quando que dois clientes serão iguais.

            Cliente cliente = new Cliente { Nome = "Lucas Jabur", Email = "lucas@email.com" };
            Cliente cliente2 = new Cliente { Nome = "Manuela Pasquini", Email = "manu@email.com" };
            Cliente cliente3 = new Cliente { Nome = "Manuela Alvarenga", Email = "manu@email.com" };

            Console.WriteLine(cliente.Equals(cliente2));
            Console.WriteLine(cliente2.Equals(cliente3));
            Console.WriteLine(cliente == cliente3);
            Console.WriteLine(cliente.GetHashCode());
            Console.WriteLine(cliente2.GetHashCode());
            Console.WriteLine(cliente3.GetHashCode());

            // Lembrando que o '==' refere-se a igualdade do local de memória em que as variáveis estão armazenadas!
        }
    }
}
