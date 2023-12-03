using Microsoft.VisualBasic;

namespace AulaMVC2._1.Models
{
	public class Compromissos
	{
        public int Id { get; set; }
		public string Descricão { get; set; }
        public DateTime Data { get; set; }
        public Local Local { get; set; }
        public Contato Contato { get; set; }
    }
}
