using System.ComponentModel.DataAnnotations;

namespace Aula_de_LINQ
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Estudantes();
            //numeros();
        }
        static void numeros()
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var pares =
                from num in numeros
                where (num % 2) == 0
                select num;

            foreach (int par in pares)
            {
                Console.WriteLine(par);
            }
            var impares =
                from num in numeros
                where (num % 2) != 0
                select num;

            foreach (int im in impares)
            {
                Console.WriteLine(im);
            }
        }
        static void Estudantes()
        {
            List<Estudante> students = new()
            {
    new Estudante { NomeCompleto = "Svetlana",Id = 111,  notas = new List<int> { 97, 92, 81, 60 } },
    new Estudante { NomeCompleto = "Claire",  Id = 112,  notas = new List<int> { 75, 84, 91, 39 } },
    new Estudante { NomeCompleto = "Sven",    Id = 113,  notas = new List<int> { 88, 94, 65, 91 } },
    new Estudante { NomeCompleto = "Cesar",   Id = 114,  notas = new List<int> { 97, 89, 85, 82 } },
    new Estudante { NomeCompleto = "Debra",   Id = 115,  notas = new List<int> { 35, 72, 91, 70 } },
    new Estudante { NomeCompleto = "Fadi",    Id = 116,  notas = new List<int> { 99, 86, 90, 94 } },
    new Estudante { NomeCompleto = "Hanying", Id = 117,  notas = new List<int> { 93, 92, 80, 87 } },
    new Estudante { NomeCompleto = "Hugo",    Id = 118,  notas = new List<int> { 92, 90, 83, 78 } },
    new Estudante { NomeCompleto = "Lance",   Id = 119,  notas = new List<int> { 68, 79, 88, 92 } },
    new Estudante { NomeCompleto = "Terry",   Id = 120,  notas = new List<int> { 99, 82, 81, 79 } },
    new Estudante { NomeCompleto = "Eugene",  Id = 121,  notas = new List<int> { 96, 85, 91, 60 } },
    new Estudante { NomeCompleto = "Michael", Id = 122,  notas = new List<int> { 10, 69, 69, 99 } }
    };
            int val = int.Parse(Console.ReadLine());

            switch (val)
            {
                case 1:
                    /*var aprovados =
                from alunos in students
                where (alunos.notas[0] + alunos.notas[1] + alunos.notas[2] + alunos.notas[3]) / 4 > 70 
                select alunos;*/
                    Console.WriteLine("Aprovados");
                    var aprovados =
                        from alunos in students
                        where alunos.notas.Average() >= 70
                        select alunos;

                    foreach (var alunos in aprovados)
                    {
                        Console.WriteLine($"{alunos.Id} {alunos.NomeCompleto} {alunos.notas.Average()}");
                    }
                    break;

                case 2:
                    var reprovados =
                        from alunos in students
                        where alunos.notas.Average() < 70
                        select alunos;
                    Console.WriteLine("Reprovados");
                    foreach (var alunos in reprovados)
                    {
                        Console.WriteLine($"{alunos.Id} {alunos.NomeCompleto} {alunos.notas.Average()}");
                    }
                    break;

                case 3:
                    var mediaM =
                        from nm in students
                        let media = nm.notas.Average()
                        select media;  
                    var notaM =
                        from nm in students
                        select nm.notas.Max();

                    Console.WriteLine(notaM.ToList().Max() +" -- "+ mediaM.Max());

                    break;

                case 4:
                    var mediaMin =
                        from nm in students
                        let media = nm.notas.Average()
                        select media;
                    var notaMin =
                        from nm in students
                        select nm.notas.Min();

                    Console.WriteLine(notaMin.ToList().Min() + " -- " + mediaMin.Min());
                    break;


            }



        }

    }
}