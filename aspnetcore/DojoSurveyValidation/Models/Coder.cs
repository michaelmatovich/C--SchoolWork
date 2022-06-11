using System.ComponentModel.DataAnnotations;
namespace DojoSurveyValidation.Models;
#pragma warning disable CS8618
public class Coder
{
    [Required]
    [MinLength(2)]
    public string Name {get;set;}
    [Required]
    [MinLength(2)]
    public string Location {get;set;}
    [Required]
    [MinLength(2)]
    public string FavLanguage {get;set;}

    [MinLength(20)]
    public string? Comment {get;set;}

}

