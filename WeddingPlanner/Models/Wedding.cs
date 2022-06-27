#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId {get; set;}
    [Required]
    public string WedderOne {get; set;}
    [Required]
    public string WedderTwo {get; set;}
    [Required]
    public DateTime Date {get; set;}
    [Required]
    public string Address {get;set;}
    public int? Creator {get;set;}
    public List<Guest> Guests {get;set;} = new List<Guest>();

}