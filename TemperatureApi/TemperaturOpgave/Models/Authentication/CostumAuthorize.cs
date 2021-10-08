using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperaturOpgave.Backend;
using TemperaturOpgave.Services;

namespace TemperaturOpgave.Models.Authentication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CostumAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            DbCommunicator db = new DbCommunicator();

            var username = context.HttpContext.Request.Cookies["zbcRoomInfo"].Split(".")[0];
            var password = context.HttpContext.Request.Cookies["zbcRoomInfo"].Split(".")[1];

            User user = db.GetUsers().FirstOrDefault(x => Convert.ToBase64String(Hash.HashString(x.UserName)) == username);

            if (user == null || password != user.Password)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
