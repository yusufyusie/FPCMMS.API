using System.ComponentModel.DataAnnotations;

namespace FPCMMS.Application.DTOs
{
    public class UserForUpdateDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Picture { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        //public string Email { get; set; }
        //public string PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
