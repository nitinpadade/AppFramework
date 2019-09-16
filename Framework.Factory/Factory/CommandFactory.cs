namespace Framework.Factory.Factory
{
    public abstract class CommandFactory
    {
        public abstract ICommand<TObj> CreateFactory<TObj, TCls>(params object[] paramArray)
            where TObj : class
             where TCls : class;
    }
}
