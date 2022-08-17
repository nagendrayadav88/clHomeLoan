namespace BusinessService.Model
{
    public class Register
    {
        public int RegisterId { get; set; }

        public DateTime RegisterDate { get; set; }

        public Property? Property { get; set; }

        public int PropertyId { get; set; }

        public Guid? UserId { get; set; }
    }
}  