using System.ComponentModel.Design;
using Models;
using Controllers;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int op;

        do
        {
            op = Menu();

            switch (op)
            {
                case 1:
                    Console.Write("Informe o nome do livro: ");
                    string nameBook = Console.ReadLine();
                    Console.Write("Informe a edição do livro: ");
                    string editionBook = Console.ReadLine();
                    Console.Write("Informe o autor: ");
                    string authorBook = Console.ReadLine();
                    Console.Write("Informe o ISBN do livro: ");
                    string isbnBook = Console.ReadLine();

                    Book bookToSave = new BookController().CreateBook(nameBook, editionBook, authorBook, isbnBook);
                    new MongoController().InsertBook(bookToSave);

                    Console.WriteLine("Livro Armazenado!");
                    Console.WriteLine("Pressione enter para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                case 2:
                    Console.Write("Informe o nome do livro: ");
                    string bookNameToRead = Console.ReadLine();

                    new MongoController().ReadBook(bookNameToRead);

                    Console.WriteLine("Livro adicionado a lista de leitura!");
                    Console.WriteLine("Pressione enter para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                case 3:
                    Console.Write("Informe o nome do livro: ");
                    string bookNameToLead = Console.ReadLine();

                    new MongoController().LendBook(bookNameToLead);

                    Console.WriteLine("Livro adicionado a lista de emprestados!");
                    Console.WriteLine("Pressione enter para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                case 4:
                    int opmc = MenuCollections();
                    Console.Write("Informe o nome do livro: ");
                    string bookNameToShelf = Console.ReadLine();

                    switch (opmc)
                    {
                        case 1:
                            new MongoController().ReadingToShelf(bookNameToShelf);

                            Console.WriteLine("Livro devolvido para a prateleira!");
                            Console.WriteLine("Pressione enter para continuar...");
                            Console.ReadKey();
                            Console.Clear();

                            break;
                        case 2:
                            new MongoController().LendToShelf(bookNameToShelf);

                            Console.WriteLine("Livro devolvido para a prateleira!");
                            Console.WriteLine("Pressione enter para continuar...");
                            Console.ReadKey();
                            Console.Clear();

                            break;
                        default:
                            Console.WriteLine("Escolha uma opção valida!");                       

                            break;
                    }
                    break;
                case 5:

                    int opml = MenuList();

                    switch (opml)
                    {
                        case 1:
                            new ShelfController().InsertBookList(new MongoController().ShowShelfBooks());
                            Console.WriteLine("Pressione enter para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            new ShelfController().InsertReadingList(new MongoController().ShowReadingBooks());
                            Console.WriteLine("Pressione enter para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            new ShelfController().InsertLoanedList(new MongoController().ShowLoanedBooks());
                            Console.WriteLine("Pressione enter para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Escolha uma opção valida!");

                            break;
                    }

                    break;
                case 6:
                    Console.WriteLine("------Atualizar livro da prateleira------");
                    Console.Write("Nome do livro que você deseja atualizar: ");
                    string bookNameToUpdate = Console.ReadLine();
                    Console.Write("Informação você deseja atualizar: ");
                    string field = Console.ReadLine();
                    Console.Write("Informe o novo valor: ");
                    string value = Console.ReadLine();

                    Console.WriteLine("Livro atualizado!");
                    Console.ReadKey();
                    Console.Clear();

                    new MongoController().UpdateBook(bookNameToUpdate, field, value);

                    break;
                case 7:
                    Console.Write("Informe o nome do livro: ");
                    string bookNameToDelete = Console.ReadLine();

                    new MongoController().DeleteBook(bookNameToDelete);

                    Console.WriteLine("Livro excluido!");
                    Console.WriteLine("Pressione enter para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }
        } while (true);
    }

    public static int Menu()
    {
        Console.WriteLine($"----ESTANTE VIRTUAL----" +
                             $"\n1 - Adicionar livro a prateleira" +
                             $"\n2 - Adicionar livro a lista de leitura" +
                             $"\n3 - Emprestar livro" +
                             $"\n4 - Devovler livro para a prateleira" +
                             $"\n5 - Listar livros" +
                             $"\n6 - Atualizar livro" +
                             $"\n7 - Excluir livro" +
                             $"\n0 - Sair" +
                             "\n-----------------------");

        return int.Parse(Console.ReadLine());
    }

    public static int MenuCollections()
    {
        Console.WriteLine($"----ESTANTE VIRTUAL----" +
                             $"\n1 - Remover da lista de leitura" +
                             $"\n2 - Remover da lista de emprestados" +
                             "\n-----------------------");

        return int.Parse(Console.ReadLine());
    }

    public static int MenuList()
    {
        Console.WriteLine($"----Listar estantes----" +
                             $"\n1 - Listar livros" +
                             $"\n2 - Listar livros que está lendo" +
                             $"\n3 - Listar livros emprestados" +
                             "\n-----------------------");

        return int.Parse(Console.ReadLine());
    }
}