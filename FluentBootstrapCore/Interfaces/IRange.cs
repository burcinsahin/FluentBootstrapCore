namespace FluentBootstrapCore.Interfaces
{
    public interface IRange
    {
        int Max { get; set; }
        int Min { get; set; }
        double Step { get; set; }
    }
}