using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Arquivos
{
    class Alterar : Contato
    {
        public void alterar()
        {
            bool verF = true;
            Console.Write("Qual contato deseja alterar: ");
            string nome = Console.ReadLine();
            List<string> listaComp = new List<string>();
            using (StreamReader sr = File.OpenText(path))
            {
                while ((lisT = sr.ReadLine()) != null)
                {
                    listaComp.Add(lisT);
                }
            }
            for (int i = 1; i < listaComp.Count; i += 4)
            {
                if (listaComp[i] == nome)
                {
                    Contato dados = new Contato();
                    Console.Write("Nome: ");
                    dados.nome = Console.ReadLine();
                    Console.Write("Numero: ");
                    dados.numero = Console.ReadLine();
                    Console.Write("Idade: ");
                    dados.idade = Console.ReadLine();

                    listaComp[i] = dados.nome;
                    listaComp[i + 1] = dados.numero;
                    listaComp[i + 2] = dados.idade;
                    verF = false;

                }
            }
            if (verF == true)
            {
                Console.WriteLine("Contato não encontrado!");
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int j = 0; j < listaComp.Count; j++)
                    {
                        sw.WriteLine(listaComp.ToArray()[j].ToString());
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
