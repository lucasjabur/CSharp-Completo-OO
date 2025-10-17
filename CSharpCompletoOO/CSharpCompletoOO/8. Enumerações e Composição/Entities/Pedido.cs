using CSharpCompletoOO._8._Enumerações_e_Composição.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._8._Enumerações_e_Composição.Entities {
    internal class Pedido {
        public int Id { get; set; }
        public DateTime Momento {  get; set; }
        public StatusPedido Status { get; set; }

        public override string ToString() {
            return $"{Id}, Momento: {Momento}, Status: {Status}";
        }
    }
}
