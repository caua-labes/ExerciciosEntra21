using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class Crud
    {
        List<Produto> lista = new List<Produto>();
        public bool apagar() {
            Console.Clear();
            Console.WriteLine("Insira qual produto deseja remover");
            string prodDEL = Console.ReadLine();
            foreach (Produto produto in lista) {
                if (prodDEL == produto.Nome)
                {
                    lista.Remove(produto);
                }
            }
            Console.Clear();
            return true;
        }
        public bool alterar()
        {
            Console.Clear();
            Produto produto = new Produto();
            Console.WriteLine("Qual produto deseja alterar");
            string prodALT = Console.ReadLine();
            for(int i = 0;i<lista.Count;i++)
            {
                if (lista[i].Nome == prodALT)
                {
                    lista.Remove(lista[i]);
                    Console.Write("Novo produto: ");
                    produto.Nome = Console.ReadLine();
                    Console.Write("Descrição: ");
                    produto.Descrição = Console.ReadLine();
                    Console.Write("Valor: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());
                    
                    lista.Add(produto);
                    Console.Clear();
                    
                }
            }
            Console.Clear() ;
            return true;
        }
        public bool inserir()
        {
            Console.Clear();
            Produto produto = new Produto();
            Console.Write("Produto: ");
            produto.Nome = Console.ReadLine();
            Console.Write("Descrição: ");
            produto.Descrição = Console.ReadLine();
            Console.Write("Valor: ");
            produto.Preco = decimal.Parse(Console.ReadLine());
            Console.ReadKey();
            lista.Add(produto);
            Console.ReadKey();
            Console.Clear();
            return true;

        }
        public bool listar()
        {
            foreach (Produto produto in lista)
            {
                Console.Write(produto.ToString());
            }

            Console.ReadKey();
            Console.Clear();
            return true;
        }

        
    }
}
