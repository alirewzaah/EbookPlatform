using EbookPlatform.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.Service
{
    public class LanguageService:ILanguageService
    {
        private MyEbookPlatformContext _context;
        public LanguageService(MyEbookPlatformContext context)
        {
            _context = context;
        }

        public List<Language> ShowAllLanguages()
        {
            return _context.languages.ToList();
        }
    }
}
