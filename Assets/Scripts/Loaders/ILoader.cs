public interface ILoader<T>
{
    T Load(string path);
    void Save(string path);
}