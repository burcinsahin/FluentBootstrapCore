using System.ComponentModel.DataAnnotations;

namespace FBootstrapCoreMvc.Test.WebUI.Models.MvcTests
{
    public class Customer
    {
        [Display(Name = "First Name")]
        public string? Name { get; set; }

        [Display(Name = "Last Name")]
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public bool IsMarried { get; set; }
        public Address? Address { get; set; }
    }

    public class Address
    {
        [Display(Name = "Address Detail")]
        public string? Detail { get; set; }
        public string? Town { get; set; }
        public string? City { get; set; }
    }
}