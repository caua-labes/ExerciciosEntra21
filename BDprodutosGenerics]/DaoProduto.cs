using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDprodutosGenerics_.Interfaces;
using System.Collections;

namespace BDprodutosGenerics_
{
    public class DaoProduto : Iprodutos<Produtos>
    {
        public bool add(Produtos t)
        {
            Console.Write("Produto: ");
            t.Nome = Console.ReadLine();
            Console.Write("Valor: ");
            t.Valor = double.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            t.Quantidade = int.Parse(Console.ReadLine());
            Console.Write("Categoria: ");
            t.Codigo = int.Parse(Console.ReadLine());

            using (SqlConnection bd = new SqlConnection())
            {
                bd.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                SqlCommand linCm = new SqlCommand();
                linCm.CommandType = CommandType.Text;
                linCm.CommandText = "insert into Produtos([Nome], [ValorUnitario], [Quantidade], [Categoria])values(@Nome, @ValorUnitario, @Quantidade, @Categoria)";
                bd.Open();
                linCm.Parameters.Add("Nome", SqlDbType.VarChar).Value = t.Nome;
                linCm.Parameters.Add("ValorUnitario", SqlDbType.Decimal).Value = t.Valor;
                linCm.Parameters.Add("Quantidade", SqlDbType.Int).Value = t.Quantidade;
                linCm.Parameters.Add("Categoria", SqlDbType.Int).Value = t.Codigo;
                linCm.Connection = bd;
                return linCm.ExecuteNonQuery() > 0;

            }
        }

        public bool Alterar(Produtos t)
        {
            Console.Write("Qual ID deseja alterar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Novo Produto: ");
            t.Nome = Console.ReadLine();
            Console.Write("Valor: ");
            t.Valor = double.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            t.Quantidade = int.Parse(Console.ReadLine());
            Console.Write("Categoria: ");
            t.Codigo = int.Parse(Console.ReadLine());
            using (SqlConnection conta = new SqlConnection())
            {
                conta.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False";
                SqlCommand cn = new();
                cn.CommandType = CommandType.Text;
                cn.CommandText = $"update Produtos set Nome = @Nome, ValorUnitario = @ValorUnitario, Quantidade = @Quantidade, Categoria = @Categoria where Id = {id}";
                cn.Parameters.Add("@Nome", SqlDbType.VarChar).Value = t.Nome;
                cn.Parameters.Add("@ValorUnitario", SqlDbType.Decimal).Value = t.Valor;
                cn.Parameters.Add("@Quantidade", SqlDbType.Int).Value = t.Quantidade;
                cn.Parameters.Add("@Categoria", SqlDbType.Int).Value = t.Codigo;
                conta.Open();
                cn.Connection = conta;
                SqlDataReader dr;
                dr = cn.ExecuteReader();
                return true;
            }
        }

        public void Consultar(Produtos t)
        {
            List<Produtos> lista = new List<Produtos>();
            using (SqlConnection bd = new SqlConnection())
            {
                bd.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                bd.Open();
                SqlCommand linCm = new SqlCommand();
                linCm.CommandType = CommandType.Text;
                linCm.CommandText = "select Produtos.Id, Produtos.Nome, Produtos.ValorUnitario, Produtos.Quantidade, Categorias.categoriaNome, Categorias.Idcategoria from Produtos, Categorias where Produtos.Categoria = Categorias.Idcategoria";

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
                    produtos.categoria = new Categoria() { categoriaId = Convert.ToInt32(dr["Idcategoria"]), nomeCategoria = Convert.ToString(dr["categoriaNome"]) };
                    lista.Add(produtos);
                }
                foreach (Produtos item in lista)
                {

                    Console.WriteLine(item.ToString());
                }
            }
        }
        

        public void ConsultarID(Produtos t)
        {
            Console.Write("Qual id deseja ver: ");
            int idCon = int.Parse(Console.ReadLine());
            using (SqlConnection bd = new SqlConnection())
            {
                bd.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                bd.Open();
                SqlCommand linCm = new SqlCommand();
                linCm.CommandType = CommandType.Text;
                linCm.CommandText = $@"select Produtos.Id, Produtos.Nome, Produtos.ValorUnitario, Produtos.Quantidade, Categorias.categoriaNome, Categorias.Idcategoria from Produtos, Categorias where Id = {idCon} and Produtos.Categoria = Categorias.Idcategoria";
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
                    produtos.categoria = new Categoria() { categoriaId = Convert.ToInt32(dr["Idcategoria"]), nomeCategoria = Convert.ToString(dr["categoriaNome"]) };
                    Console.WriteLine(produtos.ToString());
                }

            }
        }

        public void Excluir(Produtos t)
        {
            Console.Write("Qual id deseja Apagar: ");
            int idCon = int.Parse(Console.ReadLine());
            using (SqlConnection bd = new SqlConnection())
            {
                bd.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                bd.Open();
                SqlCommand linCm = new SqlCommand();
                linCm.CommandType = CommandType.Text;
                linCm.CommandText = $@"Delete from Produtos where Id = {idCon}";
                linCm.Connection = bd;
                SqlDataReader rd;
                rd = linCm.ExecuteReader();
            }
        }
    }
}
