using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._13._Generics__Set__Dictionary {
    internal class HashSetESortedSet {
        // HashSet:
        // - armazenamento em tabela hash
        // - extremamente rápido: inserção, remoção e busca O(1)
        // - a ordem dos elementos não é garantida!

        // SortedSet:
        // - armazenamento em árvore
        // - rápido: inserção, remoção e busca O(log(n))
        // - os elementos são armazenados ordenadamente conforme implementação IComparer<T>

        // Alguns métodos importantes:
        // - Add
        // - Clear
        // - Contains
        // - UnionWith(other)     - operação união: adiciona no conjunto os elementos do outro conjunto não contidos em other
        // - IntersectWith(other) - operação interseção: remove do conjunto os elementos não contido em other
        // - ExceptWith(other)    - operação diferença: remove do conjunto os elementos contidos em other
        // - Remove(T)
        // - RemoveWhere(predicate)

        public static void MainX(string[] args) {
            HashSet<string> hashSet = new HashSet<string>();
            hashSet.Add("TV");
            hashSet.Add("Notebook");
            hashSet.Add("Tablet");

            Console.WriteLine(hashSet.Contains("Notebook"));

            foreach (var elemento in hashSet) { // não é indexado, por isso deve-se sempre utilizar 'foreach'
                Console.WriteLine(elemento);
            }

            SortedSet<int> sortedSet1 = new SortedSet<int>() { 0, 2, 4, 5, 6, 8, 10 };
            SortedSet<int> sortedSet2 = new SortedSet<int>() { 5, 6, 7, 8, 9, 10 };

            PrintarColecao(sortedSet1);

            // Operação de união:
            SortedSet<int> sortedSet3 = new SortedSet<int>(sortedSet1);
            sortedSet3.UnionWith(sortedSet2);
            PrintarColecao(sortedSet3);
        }

        public static void PrintarColecao<T>(IEnumerable<T> colecao) {
            foreach (T obj in colecao) {
                Console.Write(obj + " ");
            }
            Console.WriteLine();
        }
    }
}
