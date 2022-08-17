using System.ComponentModel.DataAnnotations;

namespace BusinessService.Model
{
    public class MortgageModels  
    {  
        public Guid? Id { get; set; }  
  
        [Required(ErrorMessage = "Name is required")]  
        public string? Name { get; set; } 
        [Required(ErrorMessage = "User is required")]  
        public DateTime? CreatedON { get; set; } 
        public bool? IsActive { get; set; } 

    }  
}  