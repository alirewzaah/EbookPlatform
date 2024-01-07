using EbookPlatform.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EbookPlatform.Components
{
    [ViewComponent(Name ="ShowNavbarViewComponent")]
    public class ShowNavbarViewComponent:ViewComponent
    {
        private MyEbookPlatformContext _context;
        public ShowNavbarViewComponent( MyEbookPlatformContext context)
        {
          
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.categories.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("ShowNavbar",GetCategories()));
        }
         
    }
}
