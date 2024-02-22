using System.Data;
using System.Data.SqlClient;
using BDprodutosGenerics_.Interfaces;

namespace BDprodutosGenerics_
{
    public class DaoCategoria : Iprodutos<Categoria>
    {
        public bool add(Categoria t)
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

        public bool Alterar(Categoria t)
        {
            Console.Write("Qual ID deseja alterar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nova categoria: ");
            t.nomeCategoria = Console.ReadLine();
            using (SqlConnection conta = new SqlConnection())
            {
                conta.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                SqlCommand cn = new();
                cn.CommandType = CommandType.Text;
                cn.CommandText = $"update Categorias set categoriaNome = @nomeCategoria where Idcategoria = {id}";
                cn.Parameters.Add("@nomeCategoria", SqlDbType.VarChar).Value = t.nomeCategoria ;
                conta.Open();
                cn.Connection = conta;
                SqlDataReader rd;
                rd = cn.ExecuteReader();
                
                return true;
            }
        }

        public void Consultar(Categoria t)
        {
            List<Categoria> lista = new List<Categoria>();
            using (SqlConnection bd = new SqlConnection())
            {
                bd.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                bd.Open();
                SqlCommand linCm = new SqlCommand();
                linCm.CommandType = CommandType.Text;
                linCm.CommandText = "select * from Categorias";

                linCm.Connection = bd;

                SqlDataReader dr;
                dr = linCm.ExecuteReader();
                while (dr.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.categoriaId = Convert.ToInt32(dr["Idcategoria"]);
                    categoria.nomeCategoria = Convert.ToString(dr["categoriaNome"]);

                    lista.Add(categoria);
                }
                foreach (Categoria item in lista)
                {

                    Console.WriteLine(item.ToString());
                }
            }
        }

        public void ConsultarID(Categoria t)
        {
            List<Categoria> lista = new List<Categoria>();
            Console.WriteLine("Qual id deseja ver: ");
            int id = int.Parse(Console.ReadLine());
            using (SqlConnection bd = new SqlConnection())
            {
                bd.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                bd.Open();
                SqlCommand linCm = new SqlCommand();
                linCm.CommandType = CommandType.Text;
                linCm.CommandText = $"select * from Categorias where Idcategoria = {id}";

                linCm.Connection = bd;

                SqlDataReader dr;
                dr = linCm.ExecuteReader();
                while (dr.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.categoriaId = Convert.ToInt32(dr["Idcategoria"]);
                    categoria.nomeCategoria = Convert.ToString(dr["categoriaNome"]);
                    lista.Add(categoria);
                }
                foreach (Categoria item in lista)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public void Excluir(Categoria t)
        {
            Console.Write("Qual ID deseja apagar: ");
            int id = int.Parse(Console.ReadLine());
            using (SqlConnection bd = new SqlConnection())
            {
                bd.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                SqlCommand lin = new();
                lin.CommandType = CommandType.Text;
                lin.CommandText = $"delete from Categorias where Idcategoria = {id}";
                bd.Open();
                lin.Connection = bd;
                
            }
        }
    }

}
