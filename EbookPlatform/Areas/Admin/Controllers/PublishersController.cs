using Microsoft.AspNetCore.Mvc;

namespace EbookPlatform.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PublishersController : Controller
    {
        private readonly ILogger<PublishersController> _logger;
        private MyEbookPlatformContext _context;
        public PublishersController(ILogger<PublishersController> logger, MyEbookPlatformContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var publishers = _context.publishers.Where(c => c.isDeleted == false).ToList();
            return View(publishers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);

            }
            if (publisherDoesExist(publisher.publisherFullName))
            {
                ModelState.AddModelError("publisherFullName", "این نویسنده تکراری است!");
                return View(publisher);
            }

            _context.publishers.Add(publisher);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var publisher = _context.publishers.Find(id);
            publisher.isDeleted = true;
            _context.publishers.Update(publisher);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            Publisher publisher = _context.publishers.Find(id);

            if (publisher == null)
            {
                Response.StatusCode = 404;
                return View("UserNotFound");
            }

            return View(publisher);

        }


        [HttpPost]
        public IActionResult Edit(int id, Publisher publisher)
        {
            publisher.publisherID = id;
            var publisherFound = _context.publishers.Find(id);
            publisherFound.publisherFullName = publisher.publisherFullName;
            publisherFound.description = publisher.description;

            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public bool publisherDoesExist(string fullName)
        {
            if (_context.publishers.Where(o => o.publisherFullName == fullName).Count() > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
