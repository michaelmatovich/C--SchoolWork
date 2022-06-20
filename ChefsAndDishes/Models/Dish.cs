#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsAndDishes.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required]
    public string Name { get; set; }    
    public int? ChefId  { get; set; }
    [Required]
    public int Tastiness {get;set;}
    [Required]
    [Range(1,10000,ErrorMessage = "Calories!!!!")]
    public int Calories {get;set;}
    [Required]
    public string Description { get; set; }
    public Chef? Chef {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
