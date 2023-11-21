using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEcategoriasBD
{
    class DaoProdutos
    {
        public bool add(Produtos produtos)
        {
            Console.Write("Produto: ");
            produtos.Nome = Console.ReadLine();
            Console.Write("Valor: ");
            produtos.Valor = double.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            produtos.Quantidade = int.Parse(Console.ReadLine());
            Console.Write("Categoria: ");
            produtos.Codigo = int.Parse(Console.ReadLine());


            return true;
        }
        public bool addCategoria()
        {
            Console.Write("Categoria: ");
            string cat = Console.ReadLine();

            using (SqlConnection bd = new SqlConnection())
            {
                bd.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                
                SqlCommand linCm = new SqlCommand();
                linCm.CommandType = CommandType.Text;
                linCm.CommandText = "insert into Categorias([categoriaNome])values(@categoriaNome)";
                bd.Open();
                linCm.Parameters.Add("categoriaNome", SqlDbType.VarChar).Value = cat;
                linCm.Connection = bd;
                return linCm.ExecuteNonQuery() > 0;
            }
        }
        public bool addProduto(Produtos produtos)
        {
            produtos = new Produtos();
            Console.Write("Produto: ");
            produtos.Nome = Console.ReadLine();
            Console.Write("Valor: ");
            produtos.Valor = double.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            produtos.Quantidade = int.Parse(Console.ReadLine());
            Console.Write("Categoria: ");
            produtos.Codigo = int.Parse(Console.ReadLine());

            using (SqlConnection bd = new SqlConnection())
            {
                bd.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                SqlCommand linCm = new SqlCommand();
                linCm.CommandType = CommandType.Text;
                linCm.CommandText = "insert into Produtos([Nome], [ValorUnitario], [Quantidade], [Categoria])values(@Nome, @ValorUnitario, @Quantidade, @Categoria)";
                bd.Open();
                linCm.Parameters.Add("Nome", SqlDbType.VarChar).Value = produtos.Nome;
                linCm.Parameters.Add("ValorUnitario", SqlDbType.Decimal).Value = produtos.Valor;
                linCm.Parameters.Add("Quantidade", SqlDbType.Int).Value = produtos.Quantidade;
                linCm.Parameters.Add("Categoria", SqlDbType.Int).Value = produtos.Codigo;
                linCm.Connection = bd;
                return linCm.ExecuteNonQuery() > 0;
               
            }
        }
        public void ConsultarCategorias(List<Produtos> lista)
        {
           
            using(SqlConnection bd = new SqlConnection())
            {
                bd.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                bd.Open();
                SqlCommand linCm = new SqlCommand();
                linCm.CommandType = CommandType.Text;
                linCm.CommandText = "select Produtos.Id, Produtos.Nome, Produtos.ValorUnitario, Produtos.Quantidade, Categorias.categoriaNome from Produtos, Categorias where Produtos.Categoria = Categorias.Idcategoria";

                linCm.Connection = bd;

                SqlDataReader dr;
                dr = linCm.ExecuteReader();
                while (dr.Read())
                {
                    Produtos produtos = new Produtos();
                    produtos.Id = Convert.ToInt32(dr["Id"]);
                    produtos.Nome = Convert.ToString(dr["Nome"]);
                    produtos.Valor = Convert.ToDouble(dr["ValorUnitario"]);
                    produtos.Quantidade = Convert.ToInt32(dr["Quantidade"]);
                    produtos.categoria = new Categoria() { categoriaId = Convert.ToInt32(dr["Id"]), nomeCategoria = Convert.ToString(dr["categoriaNome"]) };
                    lista.Add(produtos);
                }
                foreach (Produtos item in lista)
                {
                    
                    Console.WriteLine(item.ToString());
                }
            }
        }
        public void ListarPorCategoria(Produtos produtos)
        {
            List<Produtos> lista = new List<Produtos>();
            Console.Write("Qual Id do Produto: ");
            string IdProd = Console.ReadLine();
            using (SqlConnection bd = new SqlConnection())
            {
                bd.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                bd.Open();
                SqlCommand linCm = new SqlCommand();
                linCm.CommandType = CommandType.Text;
                linCm.CommandText = $"select Produtos.Id, Produtos.Nome, Produtos.ValorUnitario, Produtos.Quantidade, Categorias.categoriaNome from Produtos, Categorias where Produtos.Id = {IdProd} and Produtos.Categoria = Categorias.Idcategoria";

                linCm.Connection = bd;

                SqlDataReader dr;
                dr = linCm.ExecuteReader();
                while (dr.Read())
                {
                    produtos.Id = Convert.ToInt32(dr["Id"]);
                    produtos.Nome = Convert.ToString(dr["Nome"]);
                    produtos.Valor = Convert.ToDouble(dr["ValorUnitario"]);
                    produtos.Quantidade = Convert.ToInt32(dr["Quantidade"]);
                    produtos.categoria = new Categoria() { categoriaId = Convert.ToInt32(dr["Id"]), nomeCategoria = Convert.ToString(dr["categoriaNome"]) };
                    lista.Add(produtos);
                }
                foreach (Produtos item in lista)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        public bool deletar(Produtos produtos)
        {
            Console.Write("Qual ID deseja apagar: ");
            int id = int.Parse(Console.ReadLine());
            using (SqlConnection conta = new SqlConnection())
            {
                conta.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                SqlCommand cn = new();
                cn.CommandType = CommandType.Text;
                cn.CommandText = $"delete from Produtos where Id = {id}";
                conta.Open();
                cn.Connection = conta;
                return cn.ExecuteNonQuery() > 0;
            }
        }
        public bool alterar(Produtos produtos)
        {
            Console.Write("Qual ID deseja alterar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Novo Produto: ");
            produtos.Nome = Console.ReadLine();
            Console.Write("Valor: ");
            produtos.Valor = double.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            produtos.Quantidade = int.Parse(Console.ReadLine());
            Console.Write("Categoria: ");
            produtos.Codigo = int.Parse(Console.ReadLine());
            using (SqlConnection conta = new SqlConnection())
            {
                conta.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                SqlCommand cn = new();
                cn.CommandType = CommandType.Text;
                cn.CommandText = $"update Produtos set Nome = {produtos.Nome}, ValorUnitario = {produtos.Valor}, Quantidade = {produtos.Quantidade}, Categoria = {produtos.Codigo} where Id = {id}";
                conta.Open();
                cn.Connection = conta;
                return cn.ExecuteNonQuery() > 0;
            }
        }
    }
}
