using EbookPlatform.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.Service
{
    public class TranslatorService :ITranslatorService
    {
        private MyEbookPlatformContext _context;
        public TranslatorService(MyEbookPlatformContext context)
        {
            _context = context;
        }

        public List<Translator> ShowAllTranslators()
        {
            return _context.translators.ToList();
        }
    }
}
