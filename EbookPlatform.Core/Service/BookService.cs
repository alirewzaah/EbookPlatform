using EbookPlatform.Core.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.Service
{
    public class BookService : IBookService
    {
        private MyEbookPlatformContext _context;
        public BookService(MyEbookPlatformContext context)
        {
            _context=context;
        }

        public List<Book> GetBooks()
        {
            return _context.books.Where(p=> !p.isDeleted).ToList();       
        }
        public int AddBook(Book book)
        {
            try
            {
                _context.books.Add(book);
                _context.SaveChanges();
                return book.bookID;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Book FinaBookByID(int bookid)
        {
            return _context.books.Find(bookid);
        }

        public bool UpdateBook(Book product)
        {
            try
            {
                _context.books.Update(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
       



    }


}
