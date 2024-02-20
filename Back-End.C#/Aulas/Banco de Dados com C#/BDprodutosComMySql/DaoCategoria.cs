using BDprodutosGenerics_.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace BDprodutosGenerics_
{
    public class DaoCategoria : Iprodutos<Categoria>
    {
        MySqlConnection conexão = new(Conexão.chave);
        public bool add(Categoria t)
        {
            
            Console.Write("Categoria: ");
            t.nomeCategoria = Console.ReadLine();

            MySqlCommand cm = conexão.CreateCommand();
            try
            {
                conexão.Open();
                cm.CommandType = CommandType.Text;
                cm.CommandText = @"insert into Categoria(nomecat)values(@nomeCategoria)";
                cm.Parameters.Add("nomeCategoria", MySqlDbType.VarChar).Value = t.nomeCategoria;
                cm.ExecuteNonQuery();
            }
            finally
            {
                conexão.Close();
            }
            return true;
        }

        public bool Alterar(Categoria t)
        {
            Console.Write("Qual ID deseja alterar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nova categoria: ");
            t.nomeCategoria = Console.ReadLine();
            MySqlCommand cm = conexão.CreateCommand();
            try
            {
                conexão.Open();
                cm.CommandType = CommandType.Text;
                cm.CommandText = $@"update Categoria set nome = @nomeCategoria where id = {id}";
                cm.Parameters.Add("nomeCategoria", MySqlDbType.VarChar).Value = t.nomeCategoria;
                MySqlDataReader dr = cm.ExecuteReader();
                return true;
            }
            finally
            {
                conexão.Close();
            }
        }

        public void Consultar(Categoria t)
        {

            MySqlCommand cn = conexão.CreateCommand();
            try
            {
                conexão.Open();
                cn.CommandType = CommandType.Text;
                cn.CommandText = @"select * from Categoria";
                MySqlDataReader dr = cn.ExecuteReader();
                while (dr.Read())
                {

                    Categoria categoria = new();
                    categoria.categoriaId = Convert.ToInt32(dr["idcat"]);
                    categoria.nomeCategoria = Convert.ToString(dr["nomecat"]);
                    Console.WriteLine(categoria.ToString());
                }
            }
            finally
            {
                if (conexão.State == ConnectionState.Open)
                {
                    conexão.Close();
                }
            }
        }

        public void ConsultarID(Categoria t)
        {
            Console.Write("Qual id deseja ver: ");
            int idPro = int.Parse(Console.ReadLine());

            MySqlCommand cn = conexão.CreateCommand();
            try
            {
                conexão.Open();
                cn.CommandType = CommandType.Text;
                cn.CommandText = $@"select * from Categoria where id = {idPro}";
                MySqlDataReader dr = cn.ExecuteReader();
                while (dr.Read())
                {

                    Categoria categoria = new();
                    categoria.categoriaId = Convert.ToInt32(dr["id"]);
                    categoria.nomeCategoria = Convert.ToString(dr["nome"]);
                    Console.WriteLine(categoria.ToString());
                }
            }
            finally
            {
                if (conexão.State == ConnectionState.Open)
                {
                    conexão.Close();
                }
            }
            
        }

        public void Excluir(Categoria t)
        {
            Console.Write("Qual ID deseja apagar: ");
            int id = int.Parse(Console.ReadLine());

            MySqlCommand cn = conexão.CreateCommand();
            try
            {
                conexão.Open();
                cn.CommandType = CommandType.Text;
                cn.CommandText = $@"delete from Categoria where id = {id}";
                MySqlDataReader dr = cn.ExecuteReader();
            }
            finally
            {
                if (conexão.State == ConnectionState.Open)
                {
                    conexão.Close();
                }
            }
            
        }
    }

}
