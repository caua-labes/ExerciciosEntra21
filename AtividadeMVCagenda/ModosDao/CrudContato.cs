using AulaMVC2._1.Interface;
using AulaMVC2._1.Models;
using MySql.Data.MySqlClient;

namespace AulaMVC2._1.ModosDao
{
    public class CrudContato : ICrud<Contato>
    {
        Models.ChaveSQL bdkey = new();
        public Contato consultar(int id)
        {
            Contato cont = new();
            MySqlConnection con = new(Models.ChaveSQL.Key());
            MySqlCommand cmd = con.CreateCommand();
            try
            {
                con.Open();
                cmd.CommandText = $@"select * from contatos where id = {id}";
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cont.Id = Convert.ToInt32(dr["id"]);
                    cont.Nome = Convert.ToString(dr["nomecontato"]);
                    cont.Email = Convert.ToString(dr["email"]);
                    cont.Fone = Convert.ToString(dr["fone"]);
                    cont.status = Convert.ToByte(dr["status"]);
                }
                return cont;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public bool editar(Contato t)
        {
            MySqlConnection con = new MySqlConnection(Models.ChaveSQL.Key());
            MySqlCommand cmd = con.CreateCommand();
            try
            {
                con.Open();
                cmd.CommandText = $@"update contatos set nomecontato = @Nome, email = @Email, fone = @Fone where id = {t.Id}";
                cmd.Parameters.Add("Nome", MySqlDbType.VarChar).Value = t.Nome;
                cmd.Parameters.Add("Email", MySqlDbType.VarChar).Value = t.Email;
                cmd.Parameters.Add("Fone", MySqlDbType.VarChar).Value = t.Fone;
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

        public void excluir(Contato t)
        {
            MySqlConnection con = new MySqlConnection(Models.ChaveSQL.Key());
            MySqlCommand cmd = con.CreateCommand();
            t.status = 0;
            try
            {
                con.Open();
                cmd.CommandText = $@"update contatos set contatos.status = @status where id = {t.Id}";
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


        public bool salvar(Contato t)
        {
            MySqlConnection con = new MySqlConnection(Models.ChaveSQL.Key());
            MySqlCommand cmd = con.CreateCommand();
            try
            {
                con.Open();
                cmd.CommandText = $@"insert into contatos(nomecontato,email,fone,status) values (@Nome, @Email, @Fone, @status)";
                cmd.Parameters.Add("Nome", MySqlDbType.VarChar).Value = t.Nome;
                cmd.Parameters.Add("Email", MySqlDbType.VarChar).Value = t.Email;
                cmd.Parameters.Add("Fone", MySqlDbType.VarChar).Value = t.Fone;
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

        public List<Contato> consultar(Contato contato)
        {
            List<Contato> lista = new();
            MySqlConnection con = new(Models.ChaveSQL.Key());
            MySqlCommand cmd = con.CreateCommand();
            try
            {
                con.Open();
                cmd.CommandText = @"select * from contatos where status = 1";
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Contato cont = new();
                    cont.Id = Convert.ToInt32(dr["id"]);
                    cont.Nome = Convert.ToString(dr["nomecontato"]);
                    cont.Email = Convert.ToString(dr["email"]);
                    cont.Fone = Convert.ToString(dr["fone"]);
                    cont.status = Convert.ToByte(dr["status"]);
                    lista.Add(cont);
                }
                return lista;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
