using Framework.Factory.Client;
using Microsoft.AspNetCore.Mvc;

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
            return _command.Dispatch<TCls, TObj>(cmdObj);
        }

        public TResult Query<TCls, TResult, TParameters>(TParameters parameters)
            where TCls : class
            where TResult : class
            where TParameters : class
        {
            return _query.Execute<TCls, TResult, TParameters>(parameters);
        }
    }
}