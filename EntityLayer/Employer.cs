namespace EntityLayer
{
    public class Employer : IEntity
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
        public string ContactNumber { get; set; }
    }
}
