using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arquivos
{
    public class Contato
    {
        public string s;
        //public string path = @"C:\Users\caua.labes\Desktop\Contatos\ListaContatos.txt";
        public string path = @"C:\Users\Dell\Desktop\AtividadesC#\Arquivos\ListaContatos.txt";
        public string nome { get; set; }
        public string numero { get; set; }
        public string idade { get; set; }
        public string lisT {  get; set; }

        public string ToString()
        {
            return $"{nome}\n{numero}\n{idade}\n";
        }
    }
}
