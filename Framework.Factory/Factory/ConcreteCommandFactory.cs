using System;

namespace Framework.Factory.Factory
{
    public class ConcreteCommandFactory : CommandFactory
    {
        public override ICommand<TObj> CreateFactory<TObj, TCls>(params object[] paramArray)
        {
            return (ICommand<TObj>)Activator.CreateInstance(typeof(TCls), paramArray);
        }
    }
}
