﻿using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;

namespace FBootstrapCoreMvc.Components
{
    public class Icon : BootstrapComponent
    {
        public Icon(IconType icon)
            : base("i")
        {
            AddCss($"bi bi-{icon.GetCssDescription()}");
        }
    }
}
