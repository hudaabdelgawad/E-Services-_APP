using System.ComponentModel.DataAnnotations;

 namespace Core.Dots
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Enter User Email")]
        public string Email { get; set; }
        [Required(ErrorMessage= "Enter Password")]
        public string Password { get; set; }
     
    }
}
