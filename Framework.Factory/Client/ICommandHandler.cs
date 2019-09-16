namespace Framework.Factory.Client
{
    public interface ICommandHandler
    {
        TObj Dispatch<TCls, TObj>(TObj cmdObj)
           where TCls : class
           where TObj : class;
    }
}
