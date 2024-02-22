using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquivos
{
    class VerEspefiq : Contato
    {
        public void verCont()
        {
            bool verF = true;
            Console.Write("Qual contato deseja ver: ");
            string nomeEsp = Console.ReadLine();
            List<string> listaComp = new List<string>();
            var lisT = "";
            using (StreamReader sr = File.OpenText(path))
            {
                while ((lisT = sr.ReadLine()) != null)
                {
                    listaComp.Add(lisT);
                }
            }
            for (int i = 1; i < listaComp.Count; i += 4)
            {
                if (listaComp[i] == nomeEsp)
                {
                    Console.WriteLine(listaComp.ToArray()[i].ToString());
                    Console.WriteLine(listaComp.ToArray()[i + 1].ToString());
                    Console.WriteLine(listaComp.ToArray()[i + 2].ToString());
                    verF = false;
                }
            }
            if (verF == true)
            {
                Console.WriteLine("Contato não encontrado!");
            }
            Console.ReadKey();
        }
    }
}
