using System.ComponentModel.DataAnnotations;

namespace BusinessService.Model
{
    public class Location
    {
        public Guid? id{get;set;}
        public string? HuseNo{get;set;}
        public string? City{get;set;}
        public string? PinNo{get;set;}
        public string? State{get;set;}
    }
}  