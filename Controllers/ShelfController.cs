using Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace Controllers
{
    public class ShelfController
    {
        Shelf shelf = new();
        
        public void InsertBookList(List<BsonDocument> booksBson)
        {
            booksBson.ForEach(book => shelf.Books.Add(BsonSerializer.Deserialize<Book>(book)));

            ShowBook(shelf.Books);
        }

        public void InsertReadingList(List<BsonDocument> booksBson)
        {
            booksBson.ForEach(book => shelf.ReadingBooks.Add(BsonSerializer.Deserialize<Book>(book)));

            ShowBook(shelf.ReadingBooks);
        }

        public void InsertLoanedList(List<BsonDocument> booksBson)
        {
            booksBson.ForEach(book => shelf.LoanedBooks.Add(BsonSerializer.Deserialize<Book>(book)));

            ShowBook(shelf.LoanedBooks);
        }

        public void ShowBook(List<Book> books)
        {
            books.ForEach(item => Console.WriteLine(item.ToString()));
        }
    }
}
