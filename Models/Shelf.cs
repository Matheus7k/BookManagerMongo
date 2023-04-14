using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Shelf
    {
        public List<Book> Books = new();
        public List<Book> ReadingBooks = new();
        public List<Book> LoanedBooks = new();
    }
}
