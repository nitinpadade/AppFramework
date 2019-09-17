using Framework.Data;
using Framework.Factory.Factory;

namespace Framework.Factory.Client
{
    public class QueryExecutor : IQueryExecutor
    {
        readonly QueryFactory _factory = null;
        readonly FrameworkDataContext _dataContext = null;
        private readonly ILoggedInUser _loggedInUser = null;

        public QueryExecutor(QueryFactory factory, FrameworkDataContext dataContext, ILoggedInUser loggedInUser)
        {
            _factory = factory;
            _dataContext = dataContext;
            _loggedInUser = loggedInUser;
        }

        public TResult Execute<TCls, TResult, TParameters>(TParameters parameters)
            where TCls : class
            where TResult : class
            where TParameters : class
        {
            var _handler = _factory.CreateFactory<TResult, TParameters, TCls>(_dataContext, _loggedInUser);
            return _handler.Execute(parameters);
        }
    }
}
