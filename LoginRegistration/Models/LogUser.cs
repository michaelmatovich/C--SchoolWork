#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.Models;
public class LogUser
{       
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password {get;set;} 
    
    [Required]
    [EmailAddress] 
    public string Email {get;set;}
    

}