using System.ComponentModel.DataAnnotations;

namespace FluentBootstrapCore.Test.WebUI.Models.MvcTests
{
    public class Person
    {
        [Display(Name = "First Name")]
        public string? Name { get; set; }

        [Display(Name = "Last Name")]
        public string? Surname { get; set; }

        [Display(Name = "Biography")]
        public string? Bio { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public bool Married { get; set; }
        public Address? Address { get; set; }
    }
}