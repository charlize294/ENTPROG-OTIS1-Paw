using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Suppliers.App.Models
{
    public class SignInVM
    {
        public SignInVM()
        {
            Username = "";
            Password = "";
        }

        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
