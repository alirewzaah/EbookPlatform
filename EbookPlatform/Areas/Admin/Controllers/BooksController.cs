using EbookPlatform.Core.Service.Interface;
using EbookPlatform.Core.ExtentionMethods;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EbookPlatform.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BooksController : Controller
    {
        private IBookService _bookService;
        private ICategoryService _categoryService;
        private IAuthorService _authorService;
        private ITranslatorService _translatorService;
        private ILanguageService _languageService;
        private IPublisherService _publisherService;
        public BooksController(IBookService bookService, ICategoryService categoryService, ITranslatorService translatorService, IAuthorService authorService, IPublisherService publisherService, ILanguageService languageService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _translatorService = translatorService;
            _authorService = authorService;
            _publisherService = publisherService;
            _languageService = languageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAllBooks()
        {
            return View(_bookService.GetBooks());

        }

        [HttpGet]
        public IActionResult AddBook()
        {
            ViewBag.category = _categoryService.Showsubcategory();
            ViewBag.authors = _authorService.ShowAllAuthor();
            ViewBag.languages = _languageService.ShowAllLanguages();
            ViewBag.translators = _translatorService.ShowAllTranslators();
            ViewBag.publishers = _publisherService.ShowAllPublishers();
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book, IFormFile picfile,IFormFile efile)
        {

            string imgname = UploadImage.CreateImage(picfile);
            string filename = UploadFile.CreateFile(efile);
            book.image = imgname;
            book.bookEFile = filename;




            if (!ModelState.IsValid)
            {
                ViewBag.category = _categoryService.Showsubcategory();
                ViewBag.authors = _authorService.ShowAllAuthor();
                ViewBag.languages = _languageService.ShowAllLanguages();
                ViewBag.translators = _translatorService.ShowAllTranslators();
                ViewBag.publishers = _publisherService.ShowAllPublishers();
                return View(book);
            }

            if (picfile == null)
            {
                ModelState.AddModelError("SliderImg", "لطفا یک تصویر برای اسلایدر انتخاب نمایید .");
                return View(book);

            }
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllBooks));
            }
            if (efile == null)
            {
                ModelState.AddModelError("SliderImg", "لطفا یک فایل برای اسلایدر انتخاب نمایید .");
                return View(book);

            }
            if (filename == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllBooks));
            }


            //book.bookEFile = "aksetest";
            book.productUpdated = DateTime.Now;
            book.productCreated = DateTime.Now;
            book.fileFormat = System.IO.Path.GetExtension(efile.FileName);
            book.fileSize =(Convert.ToInt32( ((efile.Length)/100)).ToString()+"Kilobytes");
            int bookID = _bookService.AddBook(book);
            TempData["Result"] = bookID > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllBooks));
  
        }

        [HttpGet]
        public IActionResult UpdateBook(int id)
        {
            Book update = _bookService.FinaBookByID(id);    
            if (update == null)
            {
                return NotFound();
            }

            ViewBag.category = _categoryService.Showsubcategory();
            ViewBag.authors = _authorService.ShowAllAuthor();
            ViewBag.languages = _languageService.ShowAllLanguages();
            ViewBag.translators = _translatorService.ShowAllTranslators();
            ViewBag.publishers = _publisherService.ShowAllPublishers();
            return View(update);
        }

        [HttpPost]
        public IActionResult UpdateBook(Book book, IFormFile? picfile, IFormFile? efile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.category = _categoryService.Showsubcategory();
                ViewBag.authors = _authorService.ShowAllAuthor();
                ViewBag.languages = _languageService.ShowAllLanguages();
                ViewBag.translators = _translatorService.ShowAllTranslators();
                ViewBag.publishers = _publisherService.ShowAllPublishers();
                return View(book);
            }

            if (picfile != null)
            {
                string imgname = UploadImage.CreateImage(picfile);
                if (imgname == "false")
                {
                    TempData["Result"] = "false";
                    return RedirectToAction(nameof(ShowAllBooks));
                }
                int DeleteImage = UploadImage.DeleteImg("SiteImages", book.image);
                if (DeleteImage==3)
                {
                    TempData["Result"] = "false";
                    return RedirectToAction(nameof(ShowAllBooks));
                }
                book.image = imgname;

            }


            if (efile != null)
            {
                string imgname = UploadFile.CreateFile(efile);
                if (imgname == "false")
                {
                    TempData["Result"] = "false";
                    return RedirectToAction(nameof(ShowAllBooks));
                }
                int DeleteImage = UploadFile.DeleteFile("SiteFiles", book.bookEFile);
                if (DeleteImage==3)
                {
                    TempData["Result"] = "false";
                    return RedirectToAction(nameof(ShowAllBooks));
                }


                book.fileFormat = System.IO.Path.GetExtension(efile.FileName);
                book.fileSize = (Convert.ToInt32(((efile.Length) / 100)).ToString() + "Kilobytes");
                book.bookEFile = imgname;

            }



            book.productUpdated = DateTime.Now;
            bool update = _bookService.UpdateBook(book);
            TempData["Result"] = update ? "true" : "false";
            return RedirectToAction(nameof(ShowAllBooks));

        }

        public IActionResult DeleteBook(int id)
        {
            Book book = _bookService.FinaBookByID(id);
            book.isDeleted = true;
            bool update = _bookService.UpdateBook(book);
            TempData["Result"] = update ? "true" : "false";
            return RedirectToAction(nameof(ShowAllBooks));

        }





        public IActionResult ShowDetails()
        {
            return View();
        }
    }
}
