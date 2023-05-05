﻿using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class LinkButton : ButtonComponent, ILink
    {
        public string? Href { get; set; }
        public LinkTarget? Target { get; set; }

        public LinkButton(object? content = null)
            : base("a")
        {
            Content = content;
        }

        protected override void PreBuild()
        {
            MergeAttribute("role", "button");

            base.PreBuild();
        }
    }
}