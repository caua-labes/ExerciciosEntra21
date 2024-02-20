using System.IO;

namespace Arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Listar\n2 - Mostrar\n3 - Deletar\n4 - Limpar\n5 - Ver Contato\n6 - Alterar\n");
                int val = int.Parse(Console.ReadLine());
                Adicionar add = new Adicionar();
                LerLista mostrar = new LerLista();
                Deletar de = new Deletar();
                Limpar delet = new Limpar();
                VerEspefiq ver = new VerEspefiq();
                Alterar alterar = new Alterar();
                Contato contato = new Contato();
                if (!File.Exists(contato.path))
                {
                    using (StreamWriter sw = File.CreateText(contato.path))
                    {
                        sw.WriteLine("\n");
                    }
                }
                switch (val)
                {
                    case 1:
                        add.Criar();
                        Console.ReadKey();
                        break;

                    case 2:
                        mostrar.Ler();
                        Console.ReadKey();
                        break;

                    case 3:
                        de.Dell();
                        Console.ReadKey();
                        break;

                    case 4:
                        delet.limpar();
                        Console.ReadKey();
                        break;

                    case 5:
                        ver.verCont();
                        break;

                    case 6:
                        alterar.alterar();
                        break;


                        default: Console.WriteLine("Numero inválido");
                        break;

                }
            }
            
        }
        
    }
}