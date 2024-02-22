namespace Arquivos
{
    class LerLista : Contato
    {
        public void Ler()
        {
            using (StreamReader sr = File.OpenText(path))
            {
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }

    }
}
