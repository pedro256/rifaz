using System.ComponentModel.DataAnnotations;

namespace Api.DTO.InputModel;

public class UserCreateRequest
{
    [Required(ErrorMessage = "fullname is required")]
    [StringLength(150,MinimumLength = 10, ErrorMessage = "fullname must be between 10 and 150 characters long")]
    public string FullName { get; set; }
    [EmailAddress(ErrorMessage = "email is invalid")]
    [Required(ErrorMessage = "email is required")]
    public string Email { get; set; }
}