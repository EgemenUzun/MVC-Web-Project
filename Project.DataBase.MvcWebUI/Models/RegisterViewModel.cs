using Project.DataBase.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Project.DataBase.MvcWebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]

        public string Password { get; set; }
        public Customer Customer { get; set; }
        public Addresses Addresses { get; set; }

    }
}
