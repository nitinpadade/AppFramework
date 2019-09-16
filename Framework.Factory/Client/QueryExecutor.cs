using Framework.Data;
using Framework.Factory.Factory;

namespace Framework.Factory.Client
{
    public class QueryExecutor : IQueryExecutor
    {
        readonly QueryFactory _factory = null;
        readonly FrameworkDataContext _dataContext = null;
        public QueryExecutor(QueryFactory factory, FrameworkDataContext dataContext)
        {
            _factory = factory;
            _dataContext = dataContext;
        }

        public TResult Execute<TCls, TResult, TParameters>(TParameters parameters)
            where TCls : class
            where TResult : class
            where TParameters : class
        {
            var _handler = _factory.CreateFactory<TResult, TParameters, TCls>(_dataContext);
            return _handler.Execute(parameters);
        }
    }
}
