using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Interfaces
{
    public interface ICanHaveOptions
    {
        IEnumerable<SelectListItem>? SelectList { get; set; }
    }
}