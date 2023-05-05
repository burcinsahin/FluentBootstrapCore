using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FluentBootstrapCore.Interfaces
{
    public interface ICanHaveOptions
    {
        IEnumerable<SelectListItem>? SelectList { get; set; }
    }
}