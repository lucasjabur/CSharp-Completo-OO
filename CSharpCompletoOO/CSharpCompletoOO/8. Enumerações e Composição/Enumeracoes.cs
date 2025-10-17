using CSharpCompletoOO._8._Enumerações_e_Composição.Entities;
using CSharpCompletoOO._8._Enumerações_e_Composição.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._8._Enumerações_e_Composição {
    internal class Enumeracoes {
        public static void MainX(string[] args) {
            Pedido pedido = new Pedido {
                Id = 1080,
                Momento = DateTime.Now,
                Status = StatusPedido.PagamentoPendente
            };

            Console.WriteLine(pedido);

            string str = StatusPedido.PagamentoPendente.ToString(); // convertendo enum para string
            Console.WriteLine(str);

            StatusPedido sp = Enum.Parse<StatusPedido>("Entregue"); // convetendo string para enum
            Console.WriteLine(sp);
        } 
    }
}
