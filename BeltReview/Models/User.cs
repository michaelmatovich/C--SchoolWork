#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltReview.Models;

public class User
{
    [Key]
    public int UserId{get;set;}

    public string Email {get;set;}

    public string Password {get;set;}

    public string PassConfirm {get;set;}

    public DateTime CreatedAt {get;set;} =  DateTime.Now;
    public DateTime UpdateddAt {get;set;} =  DateTime.Now;


}