namespace DependencyInjectionExt.Interfaces
{
    public interface ISelector<out TService>
    {
        public TService Select();
    }
}