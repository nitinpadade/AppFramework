namespace Framework.Factory.Factory
{
    public abstract class QueryFactory
    {
        public abstract IQuery<TResult, TParameters> CreateFactory<TResult, TParameters, TCls>(params object[] paramArray)
             where TResult : class
             where TParameters : class
             where TCls : class;
    }
}
