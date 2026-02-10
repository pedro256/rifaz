using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities;

[Table(("users"))]
public class UserEntity
{
    [Column("id")]
    public Guid Id { get; set; }

    [Required]
    [Column("full_name")]
    [MaxLength(250)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Column("email")]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [Column("profile_image")]
    [MaxLength(150)]
    public string ProfileImagePath { get; set; } = string.Empty;
    
    [Required]
    [Column("created_at")]
    public DateTime CreatedAt  { get; set; }
    
    [Column("kc_id")]
    public Guid  KcId { get; set; }
    
}