#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models;
public class LogUser
{       
    [Required]
    [EmailAddress] 
    public string Email {get;set;}
    
    [Required]    
    [DataType(DataType.Password)]
    public string Password {get;set;} 
    
    

}