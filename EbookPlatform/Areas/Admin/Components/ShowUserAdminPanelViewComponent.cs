using EbookPlatform.Core.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EbookPlatform.Areas.Admin.Components
{
    [ViewComponent(Name = "ShowUserAdminPanelViewComponent")]
    public class ShowUserAdminPanelViewComponent : ViewComponent
    {
        private MyEbookPlatformContext _context;
        private readonly HttpContext _httpContext;
        private IUserService _UserService;
        public ShowUserAdminPanelViewComponent(MyEbookPlatformContext context, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {

            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
            _UserService= userService;  

        }

        public User GetUser()
        {
            User user = new User();
            user.UserName = "User Not Found";
            if (User.Identity.IsAuthenticated)
            {
                int userid = int.Parse
                    (_httpContext.User.FindFirst("userID").Value);
                user = _UserService.FindUserbyID(userid);
                return user;
            }
            else
                return user;

            
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("ShowUser", GetUser()));
        }
    }
}
