using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.Service.Interface
{
    public interface IBookService
    {

        List<Book> GetBooks();
        public int AddBook(Book book);
        public Book FinaBookByID(int bookid);
        public bool UpdateBook(Book product);
    }
}
