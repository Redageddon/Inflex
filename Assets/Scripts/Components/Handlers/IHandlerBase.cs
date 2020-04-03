public interface IHandlerBase<T>
{
    T Load(string path);
    void Save(string path);
}