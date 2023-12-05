using AulaMVC2._1.Interface;
using AulaMVC2._1.Models;
using MySql.Data.MySqlClient;

namespace AulaMVC2._1.ModosDao
{
    public class CrudLocais : ICrud<Local>
    {
        public Local consultar(int id)
        {
            Local locais = new();
            MySqlConnection con = new(Models.ChaveSQL.Key());
            MySqlCommand cmd = con.CreateCommand();
            try
            {
                con.Open();
                cmd.CommandText = $@"select * from locais where id = {id}";
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    locais.Id = Convert.ToInt32(dr["id"]);
                    locais.NomeLocal = Convert.ToString(dr["nomelocal"]);
                    locais.Cidade = Convert.ToString(dr["cidade"]);
                    locais.Bairro = Convert.ToString(dr["bairro"]);
                    locais.CEP = Convert.ToString(dr["CEP"]);
                    locais.Rua = Convert.ToString(dr["rua"]);
                    locais.Uf = Convert.ToString(dr["uf"]);
                    locais.Numero = Convert.ToInt32(dr["id"]);
                }
                return locais;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public List<Local> consultar(Local t)
        {
            List<Local> ret = new List<Local>();
            MySqlConnection con = new(Models.ChaveSQL.Key());
            MySqlCommand cmd = con.CreateCommand();
            try
            {
                con.Open();
                cmd.CommandText = $@"select * from locais where id = {id}";
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Local locais = new();
                    locais.Id = Convert.ToInt32(dr["id"]);
                    locais.NomeLocal = Convert.ToString(dr["nomelocal"]);
                    locais.Cidade = Convert.ToString(dr["cidade"]);
                    locais.Bairro = Convert.ToString(dr["bairro"]);
                    locais.CEP = Convert.ToString(dr["CEP"]);
                    locais.Rua = Convert.ToString(dr["rua"]);
                    locais.Uf = Convert.ToString(dr["uf"]);
                    locais.Numero = Convert.ToInt32(dr["id"]);
                    ret.Add(locais);
                }
                return ret;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public bool editar(Local t)
        {
            MySqlConnection con = new MySqlConnection(Models.ChaveSQL.Key());
            MySqlCommand cmd = con.CreateCommand();
            try
            {
                con.Open();
                cmd.CommandText = $@"update contatos set nomelocal = @NomeLocal, rua = @Rua, numero = @Numero, bairro = @Bairro, cidade = @Cidade, CEP = @CEP, uf = @Uf where id = {t.Id}";
                cmd.Parameters.Add("NomeLocal", MySqlDbType.VarChar).Value = t.NomeLocal;
                cmd.Parameters.Add("Rua", MySqlDbType.VarChar).Value = t.Rua;
                cmd.Parameters.Add("Numero", MySqlDbType.Int32).Value = t.Numero;
                cmd.Parameters.Add("Bairro", MySqlDbType.VarChar).Value = t.Bairro;
                cmd.Parameters.Add("Cidade", MySqlDbType.VarChar).Value = t.Cidade;
                cmd.Parameters.Add("CEP", MySqlDbType.VarChar).Value = t.CEP;
                cmd.Parameters.Add("Uf", MySqlDbType.VarChar).Value = t.Uf;

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return true;
        }

        public void excluir(Local t)
        {
            MySqlConnection con = new MySqlConnection(Models.ChaveSQL.Key());
            MySqlCommand cmd = con.CreateCommand();
            t.status = 0;
            try
            {
                con.Open();
                cmd.CommandText = $@"update locais set locais.status = @status where id = {t.Id}";
                cmd.Parameters.Add("status", MySqlDbType.Bit).Value = t.status;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public bool salvar(Local t)
        {
            MySqlConnection con = new MySqlConnection(Models.ChaveSQL.Key());
            MySqlCommand cmd = con.CreateCommand();
            try
            {
                con.Open();
                cmd.CommandText = $@"insert into contatos(nomelocal,rua,numero,bairro,cidade,CEP,uf) values (@NomeLocal, @Rua, @Numero,@Bairro,@Cidade,@CEP,@Uf, @status)";
                cmd.Parameters.Add("NomeLocal", MySqlDbType.VarChar).Value = t.NomeLocal;
                cmd.Parameters.Add("Rua", MySqlDbType.VarChar).Value = t.Rua;
                cmd.Parameters.Add("Numero", MySqlDbType.Int32).Value = t.Numero;
                cmd.Parameters.Add("Bairro", MySqlDbType.VarChar).Value = t.Bairro;
                cmd.Parameters.Add("Cidade", MySqlDbType.VarChar).Value = t.Cidade;
                cmd.Parameters.Add("CEP", MySqlDbType.VarChar).Value = t.CEP;
                cmd.Parameters.Add("Uf", MySqlDbType.VarChar).Value = t.Uf;
                cmd.Parameters.Add("status", MySqlDbType.Bit).Value = true;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return true;
        }
    }
}
