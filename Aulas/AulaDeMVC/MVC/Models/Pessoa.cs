namespace MVC.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public string ToString()
        {
            return $"{Id}{Nome}{Email}";
        }
    }
}
