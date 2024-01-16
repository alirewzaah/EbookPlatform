using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EbookPlatform.Core.Service.Interface;

namespace EbookPlatform.Core.Service
{
    public class AuthorService : IAuthorService
    {
        private MyEbookPlatformContext _context;
        public AuthorService(MyEbookPlatformContext context)
        {
            _context = context;
        }


        public List<Author> ShowAllAuthor()
        {
            return _context.authors.ToList();
        }
    }
}
