﻿using EbookPlatform.Core.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.Security
{
    public class CheckPermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private int _Permissionid;
        private IRoleService _RolService;
        public CheckPermissionAttribute(int Permissionid)
        {
            _Permissionid = Permissionid;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _RolService = (IRoleService)context.HttpContext.RequestServices.GetService(typeof(IRoleService));

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                int userid = int.Parse
                    (context.HttpContext.User.FindFirst("userID").Value);

                if (!_RolService.CheckPermission(userid, _Permissionid))
                {
                    context.Result = new RedirectResult("/Account/Login");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}
