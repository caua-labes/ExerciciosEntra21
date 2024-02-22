using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDprodutosGenerics_
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int Codigo { get; set; }

        public Categoria categoria { get; set; }


        public string ToString()
        {
            return $"{Id} {Nome.Trim()} {Valor} {Quantidade} {categoria.ToString()}";
        }
    }
}
