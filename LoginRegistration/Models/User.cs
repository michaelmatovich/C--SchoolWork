#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegistration.Models;
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MinLength(2)]    
    public string Firstname {get;set;}

    [Required]
    [MinLength(2)]
    public string Lastname {get;set;}
    
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password {get;set;} 
    
    
    [NotMapped]
    [Compare("Password", ErrorMessage = "Both passwords must match!")]
    [DataType(DataType.Password)]
    
    public string PassConfirm {get;set;}

    [Required]
    [EmailAddress]
    public string Email {get;set;}
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}