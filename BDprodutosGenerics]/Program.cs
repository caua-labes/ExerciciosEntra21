using BDprodutosGenerics_;
using BDprodutosGenerics_.Interfaces;

namespace BDprodutosGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)

            {
                List<Produtos> lista = new List<Produtos>();
                Produtos produtos = new Produtos();
                Categoria categoria = new Categoria();
                DaoCategoria daoCat = new DaoCategoria();
                DaoProduto daoProd = new DaoProduto();
                Console.WriteLine("1 - Adicionar Categoria\n2 - Consultar Categoria por Id\n3 - Consultar Categorias\n4 - Alterar Categorias\n5 - Apagar Categoria\n6 - Adicionar Produtos\n7 - Consultar Produto por Id\n8 - Consultar Todos os Produtos\n9 - Alterar Produtos\n10 - Excluir Produto\n");
                int val = int.Parse(Console.ReadLine());
                
                switch (val)
                {
                    case 1:
                        daoCat.add(categoria);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        daoCat.ConsultarID(categoria);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        daoCat.Consultar(categoria);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        daoCat.Consultar(categoria);
                        daoCat.Alterar(categoria);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        daoCat.Consultar(categoria);
                        daoCat.Excluir(categoria);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                        daoProd.add(produtos);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 7:
                        daoProd.ConsultarID(produtos);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 8:
                        daoProd.Consultar(produtos);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 9:
                        daoProd.Consultar(produtos);
                        daoProd.Alterar(produtos);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 10:
                        daoProd.Consultar(produtos);
                        daoProd.Excluir(produtos);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }
            }
        }
    }
}