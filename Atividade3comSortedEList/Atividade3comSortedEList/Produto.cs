using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade3comSortedEList
{
    class Produto
    {
        public string produto;
        public string descricao;
        public double preco;

        public string ToString()
        {
            return $"{produto}\n{descricao}\n{preco}\n";
        }
    }
}
