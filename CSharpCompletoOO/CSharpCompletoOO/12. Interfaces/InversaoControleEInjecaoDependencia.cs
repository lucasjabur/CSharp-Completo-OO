using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompletoOO._12._Interfaces {
    internal class InversaoControleEInjecaoDependencia {
        // No exemplo realizado tanto com a utilização de uma interface quanto sem, foi possível notar uma diferença:
        // No exemplo sem a interface, ocorreu um acoplamento forte entre as classes 'ServicoAluguel' e 'ServicoImpostoBrasil',
        // sendo notado na declaração e na instanciação de um objeto do tipo 'ServicoImpostoBrasil' diretamente dentro da classe
        // 'ServicoAluguel'. Se essa classe mudar, e agora o serviço de imposto for de outro país, essa mudança deveria ser 
        // realizada manualmente na classe, o que não é muito eficiente em termos de manutenção.

        // Na solução utilizando a interface 'IServicoImposto', foi utilizado a inversão de controle por meio da injeção de
        // dependência. Isso gera um acoplamento fraco entre as classes 'ServicoAluguel' e 'ServicoImpostoBrasil', pois uma
        // é acessada dentro da outra por meio de uma instância feita fora da classe principal, e passada como argumento
        // para o seu construtor (injeção de dependência). Além disso, a classe 'ServicoAluguel' pode receber qualquer tipo
        // de serviço de imposto que implemente a interface. Isso significa que a classe 'ServicoAluguel' não precisaria ser
        // alterada no caso de uma mudança do país, ou seja, menos um ponto de manutenção.

        // Mas é de fato inversão de controle?
        // Padrão de desenvolvimento que consiste em retirar da classe a responsabilidade de instânciar suas dependências.
    }
}
