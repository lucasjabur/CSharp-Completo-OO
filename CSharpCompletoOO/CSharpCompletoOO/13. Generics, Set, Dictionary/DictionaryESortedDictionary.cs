using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._13._Generics__Set__Dictionary {
    internal class DictionaryESortedDictionary {
        // Dictionary:
        // - coleção de pares 'chave e valor'
        // - não admite repetições do objeto chave
        // - os elementos são indexados pelo objeto chave (sem posição)
        // - acesso, inserção e remoção de elementos são rápidos

        // Uso comum:
        // - Cookies
        // - local storage

        // Diferenças: Dictionary vs SortedDicionary
        // - Dictionary:
        //    . armazenamento em tabela hash
        //    . extremamente rápido: inserção, remoção e busca O(1)
        //    . a ordem dos elementos não é garantida
        // - SortedDictionary:
        //    . armazenamneto em árvore
        //    . rápido: inserção, remoção e busca O(log(n))
        //    . os elementos são armazenados ordenadamente conforme implementação IComparer<T>

        // Métodos importantes:
        // dictionary[key]: acessa o elemento pela chave informada
        // Add(key, value): adiciona elemento (não aceita repetição)
        // Clear(): esvazia a coleção
        // Count: quantidade de elementos
        // ContainsKey(key): verifica se a chave existe
        // ContainsValue(value): verifica se o valor existe
        // Remove(key): remove um elemento pela chave
    }
}
