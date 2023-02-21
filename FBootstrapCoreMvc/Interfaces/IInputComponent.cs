namespace FBootstrapCoreMvc.Interfaces
{
    public interface IInputComponent : ICanHaveValue,
        ICanHaveName,
        ICanBeDisabled,
        ICanBeRequired,
        ICanBeReadonly
    {
    }
}