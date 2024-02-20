using BDprodutosGenerics_.Interfaces;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Prng;
using System.Data;

namespace BDprodutosGenerics_
{
    public class DaoProduto : Iprodutos<Produtos>
    {
        MySqlConnection conexão = new(Conexão.chave);
        Produtos produtos = new();
        public bool add(Produtos t)
        {
            Console.Write("Produto: ");
            t.Nome = Console.ReadLine();
            {
                conexão.Open();
                MySqlCommand cmVer = conexão.CreateCommand();
                cmVer.CommandText = @"select Produtos.NomeProduto, Produtos.id from Produtos";
                MySqlDataReader rd = cmVer.ExecuteReader();
                while (rd.Read())
                {
                    produtos = new();
                    produtos.Id = Convert.ToInt32(rd["id"]);
                    produtos.Nome = Convert.ToString(rd["NomeProduto"]);
                    if(produtos.Nome == t.Nome)
                    {
                        Console.WriteLine($"Produto já adicionado no Id: {produtos.Id}");
                        return true;
                    }
                }

            }
            Console.Write("Valor: ");
            t.Valor = double.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            t.Quantidade = int.Parse(Console.ReadLine());
            Console.Write("Categoria: ");
            t.Codigo = int.Parse(Console.ReadLine());
            MySqlCommand cm = conexão.CreateCommand();
            try
            {
                conexão.Open();
                cm.CommandType = CommandType.Text;
                cm.CommandText = @"insert into Produtos(NomeProduto,ValorUnitario,QuantidadeEst,Categoria)values(@Nome,@Valor,@Quantidade,@Codigo)";
                cm.Parameters.Add("Nome", MySqlDbType.VarChar).Value = t.Nome;
                cm.Parameters.Add("Valor", MySqlDbType.Decimal).Value = t.Valor;
                cm.Parameters.Add("Quantidade", MySqlDbType.Int32).Value = t.Quantidade;
                cm.Parameters.Add("Codigo", MySqlDbType.Int32).Value = t.Codigo;
                return cm.ExecuteNonQuery() < 0;

            }
            finally
            {
                if (conexão.State == ConnectionState.Open)
                {
                    conexão.Close();
                }
            }

        }

        public bool Alterar(Produtos t)
        {
            bool resultado = false;
            Console.Write("Qual ID deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            conexão.Open();
            MySqlCommand cmVerId = conexão.CreateCommand();
            cmVerId.CommandText = @"select Produtos.id from Produtos";
            MySqlDataReader rdi = cmVerId.ExecuteReader();
            while (rdi.Read())
            {
                produtos = new();
                produtos.Id = Convert.ToInt32(rdi["id"]);
                if (produtos.Id == id)
                {
                    resultado = true;
                }
            }
            if (resultado != true)
            {
                Console.WriteLine("Id incorreto");
                return true;
            }
            Console.Write("Novo Produto: ");
            t.Nome = Console.ReadLine();
            Console.Write("Valor: ");
            t.Valor = double.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            t.Quantidade = int.Parse(Console.ReadLine());
            Console.Write("Categoria: ");
            t.Codigo = int.Parse(Console.ReadLine());
            MySqlCommand cm = conexão.CreateCommand();
            try
            {
                cm.CommandType = CommandType.Text;
                cm.CommandText = $"update Produtos set NomeProduto = @Nome, ValorUnitario = @Valor, QuantidadeEst = @Quantidade, Categoria = @Codigo where Id = {id}";
                cm.Parameters.Add("Nome", MySqlDbType.VarChar).Value = t.Nome;
                cm.Parameters.Add("Valor", MySqlDbType.Decimal).Value = t.Valor;
                cm.Parameters.Add("Quantidade", MySqlDbType.Int32).Value = t.Quantidade;
                cm.Parameters.Add("Codigo", MySqlDbType.Int32).Value = t.Codigo;
                return cm.ExecuteNonQuery() < 0;
            }
            finally
            {
                if (conexão.State == ConnectionState.Open)
                {
                    conexão.Close();
                }
            }
        }

        public void Consultar(Produtos t)
        {
            MySqlCommand cm = conexão.CreateCommand();
            try
            {
                conexão.Open();
                cm.CommandText = @"select * from Produtos,Categoria where Produtos.Categoria = Categoria.idcat";
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    t = new();
                    t.Id = Convert.ToInt32(dr["id"]);
                    t.Nome = Convert.ToString(dr["NomeProduto"]);
                    t.Valor = Convert.ToDouble(dr["ValorUnitario"]);
                    t.Quantidade = Convert.ToInt32(dr["QuantidadeEst"]);
                    t.categoria = new Categoria() { categoriaId = Convert.ToInt32(dr["idcat"]), nomeCategoria = Convert.ToString(dr["nomecat"]) };
                    Console.WriteLine(t.ToString());
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

        public void ConsultarID(Produtos t)
        {
            Console.Write("Qual id deseja ver: ");
            int idCon = int.Parse(Console.ReadLine());

            MySqlCommand cm = conexão.CreateCommand();
            try
            {
                conexão.Open();
                cm.CommandText = $@"select * from Produtos,Categoria where id = {idCon} and Produtos.Categoria = Categoria.idcat";
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    t = new();
                    t.Id = Convert.ToInt32(dr["id"]);
                    t.Nome = Convert.ToString(dr["NomeProduto"]);
                    t.Valor = Convert.ToDouble(dr["ValorUnitario"]);
                    t.Quantidade = Convert.ToInt32(dr["QuantidadeEst"]);
                    t.categoria = new Categoria() { categoriaId = Convert.ToInt32(dr["idcat"]), nomeCategoria = Convert.ToString(dr["nomecat"]) };
                    Console.WriteLine(t.ToString());
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

        public void Excluir(Produtos t)
        {
            Console.Write("Qual id deseja Apagar: ");
            int idCon = int.Parse(Console.ReadLine());
            MySqlCommand cm = conexão.CreateCommand();
            try
            {
                conexão.Open();
                cm.CommandText = $@"delete from Produtos where id = {idCon}";
                cm.ExecuteNonQuery();
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
