using System.Collections.Generic;

namespace Arquivos
{
    class Adicionar : Contato
    {
        public void Criar()
        {
            
            bool verTXT = false;
            Contato cont = new Contato();
            List<Contato> list = new List<Contato>();
            while (true)
            {
                Console.Write("Nome: ");
                cont.nome = Console.ReadLine();
                Console.Write("Numero: ");
                cont.numero = Console.ReadLine();
                Console.Write("Idade: ");
                cont.idade = Console.ReadLine();
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
                    if (listaComp[i] == cont.nome)
                    {
                        Console.WriteLine("Nome já existe na lista");
                        return;     
                        
                    }
                }
                break;
            }
            Console.Clear();
            Console.WriteLine($"Nome: {cont.nome}\nNumero: {cont.numero}\nIdade: {cont.idade}");
            Console.WriteLine("\nDeseja inserir este contato\nS - Sim\nN - Não");
            string val = Console.ReadLine().ToLower();
            if (val == "s")
            {
                Console.WriteLine("Contato adicionado");
                list.Add(cont);
                verTXT = true;
            }
            if (verTXT == true)
            {
                
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(list.ToArray()[0].ToString());
                }
            }
            else
            {
                Console.WriteLine("Contato não adicionado");
                verTXT = false;
            }
        }
    }
}
