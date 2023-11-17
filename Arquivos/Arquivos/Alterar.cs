using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquivos
{
    class Alterar : Contato
    {
        public void alterar()
        {
            bool verF = true;
            Contato neCont = new Contato();
            Console.Write("Qual contato deseja alterar: ");
            string nome = Console.ReadLine();
            List<Contato> listaComp = new List<Contato>();
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
                if (listaComp[i].nome == nome)
                {
                    Console.Write("Nome: ");
                    neCont.nome = Console.ReadLine();
                    Console.Write("Numero: ");
                    neCont.numero = Console.ReadLine();
                    Console.Write("Idade: ");
                    neCont.idade = int.Parse(Console.ReadLine());

                    listaComp[i] = neCont.nome;
                    listaComp[i + 1] = neCont.numero;
                    listaComp[i + 2] = neCont.idade;
                    verF = false;

                }
            }
            if (verF == true)
            {
                Console.WriteLine("Contato não encontrado!");
            }
            else
            {
                for (int i = 0; i < listaComp.Count; i++)
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(listaComp.ToArray()[i].ToString());
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
