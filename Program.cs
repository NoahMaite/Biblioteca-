using System;
using System.Linq;

namespace Biblioteca
{
    class Program
    {
        static void Main()
        {
            Livros biblioteca = new Livros();
            int opcao;

            do
            {
                Console.WriteLine("\n--- MENU BIBLIOTECA ---");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Livro novo = new Livro();
                        Console.Write("ISBN: ");
                        novo.ISBN = int.Parse(Console.ReadLine());
                        Console.Write("Título: ");
                        novo.Titulo = Console.ReadLine();
                        Console.Write("Autor: ");
                        novo.Autor = Console.ReadLine();
                        Console.Write("Editora: ");
                        novo.Editora = Console.ReadLine();
                        biblioteca.Adicionar(novo);
                        Console.WriteLine("Livro adicionado com sucesso!");
                        break;

                    case 2:
                        Console.Write("Informe o ISBN: ");
                        int isbnSint = int.Parse(Console.ReadLine());
                        var livroSint = biblioteca.Pesquisar(isbnSint);
                        if (livroSint != null)
                        {
                            Console.WriteLine($"Título: {livroSint.Titulo}");
                            Console.WriteLine($"Autor: {livroSint.Autor}");
                            Console.WriteLine($"Editora: {livroSint.Editora}");
                            Console.WriteLine($"Exemplares: {livroSint.QtdeExemplares()}");
                            Console.WriteLine($"Disponíveis: {livroSint.QtdeDisponiveis()}");
                            Console.WriteLine($"Empréstimos: {livroSint.QtdeEmprestimos()}");
                            Console.WriteLine($"% Disponibilidade: {livroSint.PercDisponibilidade():F2}%");
                        }
                        else Console.WriteLine("Livro não encontrado!");
                        break;

                    case 3:
                        Console.Write("Informe o ISBN: ");
                        int isbnAnalitico = int.Parse(Console.ReadLine());
                        var livroAnal = biblioteca.Pesquisar(isbnAnalitico);
                        if (livroAnal != null)
                        {
                            Console.WriteLine($"Título: {livroAnal.Titulo}");
                            Console.WriteLine($"Autor: {livroAnal.Autor}");
                            Console.WriteLine($"Editora: {livroAnal.Editora}");
                            Console.WriteLine($"Exemplares: {livroAnal.QtdeExemplares()}");

                            foreach (var ex in livroAnal.Exemplares)
                            {
                                Console.WriteLine($"\nTombo: {ex.Tombo}");
                                Console.WriteLine($"Disponível: {ex.Disponivel()}");
                                Console.WriteLine($"Total de empréstimos: {ex.QtdeEmprestimos()}");
                            }
                        }
                        else Console.WriteLine("Livro não encontrado!");
                        break;

                    case 4:
                        Console.Write("Informe o ISBN: ");
                        int isbnEx = int.Parse(Console.ReadLine());
                        var livroEx = biblioteca.Pesquisar(isbnEx);
                        if (livroEx != null)
                        {
                            Exemplar ex = new Exemplar();
                            Console.Write("Tombo do exemplar: ");
                            ex.Tombo = int.Parse(Console.ReadLine());
                            livroEx.AdicionarExemplar(ex);
                            Console.WriteLine("Exemplar adicionado!");
                        }
                        else Console.WriteLine("Livro não encontrado!");
                        break;

                    case 5:
                        Console.Write("ISBN do livro: ");
                        int isbnEmp = int.Parse(Console.ReadLine());
                        var livroEmp = biblioteca.Pesquisar(isbnEmp);
                        if (livroEmp != null)
                        {
                            Console.Write("Tombo do exemplar: ");
                            int tomboEmp = int.Parse(Console.ReadLine());
                            var ex = livroEmp.Exemplares.FirstOrDefault(e => e.Tombo == tomboEmp);
                            if (ex != null && ex.Emprestar())
                                Console.WriteLine("Empréstimo registrado!");
                            else
                                Console.WriteLine("Exemplar indisponível!");
                        }
                        else Console.WriteLine("Livro não encontrado!");
                        break;

                    case 6:
                        Console.Write("ISBN do livro: ");
                        int isbnDev = int.Parse(Console.ReadLine());
                        var livroDev = biblioteca.Pesquisar(isbnDev);
                        if (livroDev != null)
                        {
                            Console.Write("Tombo do exemplar: ");
                            int tomboDev = int.Parse(Console.ReadLine());
                            var ex = livroDev.Exemplares.FirstOrDefault(e => e.Tombo == tomboDev);
                            if (ex != null && ex.Devolver())
                                Console.WriteLine("Devolução registrada!");
                            else
                                Console.WriteLine("Exemplar não emprestado!");
                        }
                        else Console.WriteLine("Livro não encontrado!");
                        break;

                    case 0:
                        Console.WriteLine("Encerrando...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 0);
        }
    }
}
