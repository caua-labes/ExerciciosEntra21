using Atividade3comSortedEList;

namespace Atividade3comSortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<string, List<Produto>> lista = new SortedList<string, List<Produto>>();
            List<Produto> lisProd = new List<Produto>();
            while (true)
            {
                Produto produto = new Produto();
                Console.Clear();
                Console.WriteLine("1 - Inserir novo produto\n2 - Criar categoria\n3 - Ver lista\n");
                int val = int.Parse(Console.ReadLine());

                switch (val)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Produto: ");
                        produto.produto = Console.ReadLine();
                        Console.Write("Descrição: ");
                        produto.descricao = Console.ReadLine();
                        Console.Write("Valor: ");
                        produto.preco = double.Parse(Console.ReadLine());
                        lisProd.Add(produto);
                        int poslista = lisProd.Count;

                        Console.WriteLine("\nCategoria do produto");
                        string verAddProdCat = Console.ReadLine();
                        if (lista.ContainsKey(verAddProdCat))
                        {
                            lista[verAddProdCat].Add(lisProd[poslista - 1]);
                            Console.WriteLine("Produto adicionado");
                        }
                        else
                        {
                            Console.WriteLine("Categoria inválida");
                        }
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Qual categoria deseja criar? ");
                        string novaCategoria = Console.ReadLine();

                        if (lista.ContainsKey(novaCategoria))
                        {
                            Console.WriteLine("Categoria inválida");
                        }
                        else
                        {
                            Console.WriteLine("Categoria criada");
                            lista.Add(novaCategoria, new List<Produto>());
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Qual categoria deseja ver");
                        string CatVer = Console.ReadLine();
                        if (lista.ContainsKey(CatVer))
                        {
                            Console.WriteLine($"{CatVer}\n");
                            foreach (var list in lista[CatVer])
                            {
                                Console.WriteLine(list.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Categoria inválida");
                        }
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}