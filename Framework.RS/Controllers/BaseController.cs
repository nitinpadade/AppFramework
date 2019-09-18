using Framework.BL.Common;
using Framework.Factory.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Framework.RS.Controllers
{
    public class BaseController : Controller
    {
        public readonly ICommandHandler _command;
        public readonly IQueryExecutor _query;
        public BaseController(ICommandHandler command, IQueryExecutor query)
        {
            _command = command;
            _query = query;
        }

        public TObj Command<TCls, TObj>(TObj cmdObj)
            where TCls : class
            where TObj : class
        {
            SetLoginUserContext();
            return _command.Dispatch<TCls, TObj>(cmdObj);
        }

        public TResult Query<TCls, TResult, TParameters>(TParameters parameters)
            where TCls : class
            where TResult : class
            where TParameters : class
        {
            SetLoginUserContext();
            return _query.Execute<TCls, TResult, TParameters>(parameters);
        }       

        void SetLoginUserContext()
        {
            var result = User.FindFirstValue("UserInfo").Split('|');
            if (result != null)
            {
                LoginUserContext.UserId = Convert.ToInt32(result[0].ToString());
                LoginUserContext.UserName = result[1].ToString();
                LoginUserContext.RoleId = Convert.ToInt32(result[2].ToString());
                LoginUserContext.RoleName = result[3].ToString();
            }
        }
    }
}