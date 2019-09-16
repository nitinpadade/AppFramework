namespace Framework.Factory
{
    public interface ICommand<T>
    {
        T Execute(T obj);
    }
}
