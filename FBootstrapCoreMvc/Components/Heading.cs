using FBootstrapCoreMvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Heading : Component<Heading>
    {
        public Heading(IHtmlHelper helper, byte size)
            : base(helper, $"h{size}")
        {
        }
    }
}
