namespace FBootstrapCoreMvc.Interfaces
{
    public interface IInput : ICanHaveValue,
        ICanHaveName,
        ICanBeDisabled,
        ICanBeRequired
    {
    }
}