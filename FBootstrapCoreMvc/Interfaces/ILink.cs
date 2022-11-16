namespace FBootstrapCoreMvc.Interfaces
{
    public interface ILink<TComponent>
    {
        TComponent SetHref(string? href);
    }
}