using System.ComponentModel.DataAnnotations;
namespace MusmulogullariMarket.AdminUI.ViewModels.Categories;

public class UpdateCategoryViewModel
{
    [Required]
     public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}