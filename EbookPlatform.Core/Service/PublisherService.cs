using EbookPlatform.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.Service
{
    public class PublisherService:IPublisherService
    {
        private MyEbookPlatformContext _context;
        public PublisherService(MyEbookPlatformContext context)
        {
            _context = context;
        }

        public List<Publisher> ShowAllPublishers()
        {
            return _context.publishers.ToList();
        }
    }
}
