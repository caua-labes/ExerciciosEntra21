namespace ProdutosEcategoriasBD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                List<Produtos> lista = new List<Produtos>();
                Produtos produtos = new Produtos();
                DaoProdutos dao = new DaoProdutos();
                Console.WriteLine("1 - Adicionar Produto\n2 - Adicionar Categoria\n3 - Consultar Produto\n4 - Listar por Categoria\n5 - Deletar\n6 - Alterar\n");
                int val = int.Parse(Console.ReadLine());

                switch (val)
                {
                    case 1:
                        dao.addProduto(produtos);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        dao.addCategoria();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        dao.ConsultarCategorias(lista);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        dao.ListarPorCategoria(produtos);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        dao.deletar(produtos);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                        dao.alterar(produtos);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}