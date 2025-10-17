using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._8._Enumerações_e_Composição.Entities.Enums {
    enum StatusPedido : int {
        PagamentoPendente = 0,
        Processando = 1,
        Enviado = 2,
        Entregue = 3,
    };
}
