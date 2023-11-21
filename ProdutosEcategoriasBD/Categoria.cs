using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEcategoriasBD
{
    
    class Categoria
    {
        public int categoriaId { get; set; }
        public string nomeCategoria { get; set; }

        public string ToString() 
        {
            return $"{categoriaId} {nomeCategoria}";
        }
    }
}
