namespace Cronotário
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escolha uma forma para escrever\nForma1 - 1\nForma2 - 2");
            int val = int.Parse(Console.ReadLine());
            switch (val)
            {
                case 1:
                    forma1();
                    break;
                case 2:
                    forma2();
                    break;
                default:
                    Console.WriteLine("Numero inválido");
                    break;
            }
        }

        static void forma1()
        {
            Console.Clear();
            int j = 0;
            var alfabeto = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            var resultado = "";
            var espaço = "";
            char ltrareal;

            var palavra = Console.ReadLine();
            for (int i = 0; i < palavra.Length; i++)
            {
                for (j = 0; j < alfabeto.Length; j++)
                {
                    Console.Clear();
                    ltrareal = alfabeto[j];
                    if (palavra[i] == alfabeto[j])
                    {
                        Console.Clear();
                        resultado += alfabeto[j];
                        espaço += " ";
                        Console.WriteLine(resultado);
                    }
                    Console.WriteLine(resultado + ltrareal);
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);
            }
            Console.ReadLine();
        }
        static void forma2()
        {
            Console.Clear();

            int j = 0;
            var alfabeto = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            var resultado = "";
            var espaço = "";
            char ltrareal;

            var palavra = Console.ReadLine();
            for (int i = 0; i < palavra.Length; i++)
            {

                for (j = 0; j < alfabeto.Length; j++)
                {
                    Console.WriteLine(espaço + alfabeto[j]);
                    if (palavra[i] == alfabeto[j])
                    {

                        resultado += alfabeto[j];
                        espaço += " ";
                        Console.Clear();
                        Console.WriteLine(resultado);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);
            }
            Console.ReadLine();
        }
    }
}