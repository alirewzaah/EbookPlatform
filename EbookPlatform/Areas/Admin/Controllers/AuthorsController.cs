using Microsoft.AspNetCore.Mvc;

namespace EbookPlatform.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorsController : Controller
    {
        private readonly ILogger<AuthorsController> _logger;
        private MyEbookPlatformContext _context;
        public AuthorsController(ILogger<AuthorsController> logger, MyEbookPlatformContext context)
        {
            _logger = logger;
            _context = context;
        }

     
        public IActionResult Index()
        {
            var authors = _context.authors.Where(c=>c.isDeleted==false).ToList();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = _context.authors.Find(id);
            author.isDeleted = true;
            _context.authors.Update(author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
      

            if (!ModelState.IsValid)
            {
                return View(author);

            }
            if (authorDoesExist(author.authorFullName))
            {
                ModelState.AddModelError("authorFullName", "این نویسنده تکراری است!");
                return View(author);
            }

            _context.authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Author author = _context.authors.Find(id);

            if (author == null)
            {
                Response.StatusCode = 404;
                return View("UserNotFound");
            }

            return View(author);

        }

        [HttpPost]
        public IActionResult Edit(int id, Author author)
        {
            author.authorID = id;
            var authorFound = _context.authors.Find(id);
            authorFound.authorFullName = author.authorFullName;
            authorFound.Description = author.Description;

            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public bool authorDoesExist(string fullName)
        {
            if (_context.authors.Where(o => o.authorFullName == fullName).Count() > 0)
            {
                return true;
            }
            else
                return false;
        }

    }
}
