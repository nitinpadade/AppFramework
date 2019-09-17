using Framework.Data;
using Framework.Factory.Factory;

namespace Framework.Factory.Client
{
    public class CommandHandler : ICommandHandler
    {
        readonly CommandFactory _factory = null;
        readonly FrameworkDataContext _dataContext = null;
        private readonly ILoggedInUser _loggedInUser = null;

        public CommandHandler(CommandFactory factory, FrameworkDataContext dataContext, 
            ILoggedInUser loggedInUser)
        {
            _factory = factory;
            _dataContext = dataContext;
            _loggedInUser = loggedInUser;
        }

        public TObj Dispatch<TCls, TObj>(TObj cmdObj)
            where TCls : class
            where TObj : class
        {
            var _handler = _factory.CreateFactory<TObj, TCls>(_dataContext);
            return _handler.Execute(cmdObj);
        }

    }
}
