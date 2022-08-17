namespace BusinessService.Authentication  
{  
    public class Response  
    {  
        public string? Status { get; set; }  
        public string? Message { get; set; }  
        public object? Data{get;set;}
    }  
    public class LoginResponse
    {
        public string? token{get;set;}
        public DateTime? expiration{get;set;}
        public string? name{get;set;}
        public List<string>? roles{get;set;}
    }
} 