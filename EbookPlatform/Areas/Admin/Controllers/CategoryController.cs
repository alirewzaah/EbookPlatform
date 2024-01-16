using EbookPlatform.Core.Service;
using EbookPlatform.Core.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EbookPlatform.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }
        public IActionResult ShowAllCategory()
        {
            return View(_categoryService.ShowAllCategory());
        }
        [HttpGet]
        public IActionResult AddCategory(int? id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            if(_categoryService.doesExist(category.title, 0))
            {
                ModelState.AddModelError("title", "daste banduy tekrari ast!!!!!");
                return View(category);
            }
            int catid = _categoryService.AddCategory(category);
            TempData["Result"] = catid>0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllCategory));
        }

        [HttpGet]
        public ActionResult ShowAllSubCategory(int id) 
        {
            ViewBag.id = id;
            return View(_categoryService.ShowAllSubCategory(id));
        }

        [HttpGet]
        public ActionResult ShowAllSubCategoryLayerthree(int id)
        {
            ViewBag.id = id;
            return View(_categoryService.ShowAllSubCategory(id));
        }


        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            Category target=_categoryService.FindCategoryByID(id);
            target.isDeleted = true;
            _categoryService.DeleteCategory(target);

            return RedirectToAction(nameof(ShowAllCategory));
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            //ViewBag.id = id;
       
            Category target = _categoryService.FindCategoryByID(id);
       
            return View(target);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            /*
            if (_categoryService.doesExist(category.title, 0))
            {
                ModelState.AddModelError("title", "daste banduy tekrari ast!!!!!");
                return View(category);
            }
            */
            bool res = _categoryService.UpdateCategory(category);
            TempData["Result"] = res ? "true" : "false";
            return RedirectToAction(nameof(ShowAllCategory));

        }
    }
}
