using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquivos
{
    class Limpar : Contato
    {
        public void limpar()
        {
            Console.WriteLine("Sua lista está limpa");
            using (StreamWriter sw = File.CreateText(path))
            {
                {
                    sw.WriteLine("");
                }
            }
        }
    }
}
