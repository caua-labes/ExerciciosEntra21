using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public decimal Preco { get; set; }

        public Produto(){ }
        public Produto(int id, string descrição, decimal preco)
        {
            this.Id = id;
            this.Descrição = descrição;
            this.Preco = preco;
        }
        public string ToString()
        {
            return $"{Nome}\n{Descrição}\n{Preco}\n";
        }

        
    }
}
