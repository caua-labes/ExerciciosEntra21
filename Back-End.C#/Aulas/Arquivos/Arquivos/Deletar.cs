namespace Arquivos
{
    class Deletar : Contato
    {
        public void Dell()
        {
            var lisT = "";
            List<string> listaComp = new List<string>();
            Console.WriteLine("Qual contato deseja apagar ");
            var ContDel = Console.ReadLine();
            using (StreamReader sr = File.OpenText(path))
            {
                while ((lisT = sr.ReadLine()) != null)
                {
                    listaComp.Add(lisT);
                }
            }
            for (int i = 1; i < listaComp.Count; i += 4)
            {
                if (listaComp[i] == ContDel)
                {
                    listaComp.RemoveAt(i);
                    listaComp.RemoveAt(i);
                    listaComp.RemoveAt(i);
                    listaComp.RemoveAt(i);
                    break;

                }
            }


            using (StreamWriter sw = File.CreateText(path))
            {
                for (int j = 0; j < listaComp.Count; j++)
                {
                    sw.WriteLine(listaComp.ToArray()[j].ToString());
                }
            }


        }
    }
}
