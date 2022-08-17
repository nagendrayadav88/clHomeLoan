
using System.ComponentModel.DataAnnotations;

namespace BusinessService.Model
{
    public class User
    {
        [Key]
        public Guid? Id{get;set;}
        public string? UserName{get;set;}
    }
}