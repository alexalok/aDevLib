namespace DependencyInjectionExt.Interfaces
{
    public interface IFactory<out T>
    {
        T Create();
    }
}