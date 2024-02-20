using MySql.Data.MySqlClient;

namespace AulaMVC2._1.Models
{
	public class ChaveSQL
	{
		public static string Key()
		{
			string chave = $@"server=localhost;database=agenda;uid=caua;pwd=cabrazoera29";
			return chave;
        }
    }
}

