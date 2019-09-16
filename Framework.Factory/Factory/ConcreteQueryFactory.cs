using System;

namespace Framework.Factory.Factory
{
    public class ConcreteQueryFactory : QueryFactory
    {
        public override IQuery<TResult, TParameters> CreateFactory<TResult, TParameters, TCls>(params object[] paramArray)
        {
            return (IQuery<TResult, TParameters>)Activator.CreateInstance(typeof(TCls), paramArray);
        }
        
    }
}
