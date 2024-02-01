using Microsoft.AspNetCore.Mvc;

namespace EbookPlatform.Components
{
    [ViewComponent(Name = "ShowNavbarMobileViewComponent")]
    public class ShowNavbarMobileViewComponent : ViewComponent
    {
        private MyEbookPlatformContext _context;
        public ShowNavbarMobileViewComponent(MyEbookPlatformContext context)
        {

            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.categories.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("ShowNavbarMobile", GetCategories()));
        }

    }
}
