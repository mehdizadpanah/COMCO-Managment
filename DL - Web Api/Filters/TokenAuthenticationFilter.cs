﻿using DL___Web_Api.TokenAuthentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DL___Web_Api.Filters
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenManager = (ITokenManager)context.HttpContext.RequestServices.GetService(typeof(ITokenManager));

            var result = true;
            if(!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                result = false;
            string token = string.Empty;
            if (result)
            {
                token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
                
                if(!tokenManager.VerifyToken(token))
                    result = false;
            }
            if(!result) 
            { 
                context.ModelState.AddModelError("Unauthorized", "You are not Unauthorized.");
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }
               
        }
    }
}
