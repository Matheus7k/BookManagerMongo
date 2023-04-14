using System;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Controllers
{
    public class MongoController
    {
        private MongoClient Mongo;
        private IMongoDatabase dataBase;
        private IMongoCollection<BsonDocument> booksCollection;
        private IMongoCollection<BsonDocument> readingsCollection;
        private IMongoCollection<BsonDocument> loanedCollection;

        public MongoController()
        {
            Mongo = new("mongodb://localhost:27017");
            dataBase = Mongo.GetDatabase("BookManager");
            booksCollection = dataBase.GetCollection<BsonDocument>("Books");
            readingsCollection = dataBase.GetCollection<BsonDocument>("Reading");
            loanedCollection = dataBase.GetCollection<BsonDocument>("Loaned");
        }

        public void InsertBook(Book book)
        {
            var bookToSave = new BsonDocument
            {
                {"Name", book.Name},
                {"Edition", book.Edition},
                {"Author", book.Author},
                {"ISBN", book.ISBN},
            };

            booksCollection.InsertOne(bookToSave);
        }

        public void ReadBook(string bookName)
        {
            var book = booksCollection.Find(Builders<BsonDocument>.Filter.Regex("Name", bookName)).First();

            readingsCollection.InsertOne(book);
            booksCollection.FindOneAndDelete(book);
        }

        public void LendBook(string bookName)
        {
            var book = booksCollection.Find(Builders<BsonDocument>.Filter.Regex("Name", bookName)).First();

            loanedCollection.InsertOne(book);
            booksCollection.FindOneAndDelete(book);
        }

        public void LendToShelf(string bookName)
        {
            var book = loanedCollection.Find(Builders<BsonDocument>.Filter.Regex("Name", bookName)).First();

            booksCollection.InsertOne(book);
            loanedCollection.FindOneAndDelete(book);
        }

        public void ReadingToShelf(string bookName)
        {
            var book = readingsCollection.Find(Builders<BsonDocument>.Filter.Regex("Name", bookName)).First();

            booksCollection.InsertOne(book);
            readingsCollection.FindOneAndDelete(book);
        }

        public void DeleteBook(string bookName)
        {
            var book = booksCollection.Find(Builders<BsonDocument>.Filter.Regex("Name", bookName)).First();

            booksCollection.DeleteOne(book);
        }

        public void UpdateBook(string bookName, string field, string value)
        {
            booksCollection.UpdateOne(Builders<BsonDocument>.Filter.Regex("Name", bookName), Builders<BsonDocument>.Update.Set(field, value));
        }

        public List<BsonDocument> ShowShelfBooks()
        {
            var booksToList = booksCollection.Find(new BsonDocument()).ToList();

            return booksToList;
        }

        public List<BsonDocument> ShowReadingBooks()
        {
            var booksToList = readingsCollection.Find(new BsonDocument()).ToList();

            return booksToList;
        }

        public List<BsonDocument> ShowLoanedBooks()
        {
            var booksToList = loanedCollection.Find(new BsonDocument()).ToList();

            return booksToList;
        }
    }
}
