﻿using System.ComponentModel.DataAnnotations;

namespace FluentBootstrapCore.Test.WebUI.Models.MvcTests
{
    public class Address
    {
        [Display(Name = "Address Detail")]
        public string? Detail { get; set; }
        public string? Town { get; set; }
        public string? City { get; set; }
    }
}