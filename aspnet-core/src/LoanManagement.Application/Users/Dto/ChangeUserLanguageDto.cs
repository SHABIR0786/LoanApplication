using System.ComponentModel.DataAnnotations;

namespace LoanManagement.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}