using System.ComponentModel.DataAnnotations;

namespace server.Shared.Model
{
    public class userModel
    {
        [Required(ErrorMessage = "Check your Email")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Check your Password")]
        [MinLength(8, ErrorMessage = "Password Should be longer than 8 characters")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).$", ErrorMessage = "It has to be one uppercase English Letter,and also it must has one special character")]
        public string? Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Mismatched Password")]
        public string? PasswordCheck { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [RegularExpression("^01([0|1|6|7|8|9])-?([0-9]{3,4})-?([0-9]{4})$", ErrorMessage = "InCorrect Formatting of Phone-Num")]
        public string? PhoneNum { get; set; }
    }
}
