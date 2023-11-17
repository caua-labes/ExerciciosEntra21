namespace SOLID{
    internal class Program
    {
        static void Main(string[] args)
        {
            Crud func = new Crud();
            while (true) { 

            Produto produto = new Produto();
            Console.WriteLine("1 - Inserir\n2 - Apagar\n3 - Alterar\n4 - Listar\n'");
            int val = int.Parse(Console.ReadLine());
                switch (val)
                {
                    case 1: 
                        func.inserir();
                        break;
                    case 2:
                        func.apagar();
                        break;
                    case 3:
                        func.alterar();
                        break;
                    case 4:
                        func.listar();
                        break;
                }
            }
        }
    }
}