using Models;

namespace Controllers
{
    public class BookController
    {
        public Book CreateBook(string name, string edition, string author, string isbn)
        {
            Book book = new();
            book.Name = name;
            book.Edition = edition;
            book.Author = author;
            book.ISBN = isbn;

            return book;
        }
    }
}