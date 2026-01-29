using System.ComponentModel.DataAnnotations;
namespace MusmulogullariMarket.AdminUI.ViewModels.Categories;

public class CreateCategoryViewModel
{
    [Required]
    public string Name { get; set; } = null!;
}