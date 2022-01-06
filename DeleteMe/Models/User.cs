namespace DeleteMe.Models
{
    public enum Roles
    {
        Admin,
        Client
    }
    public class User
    {
        public int Id { get; set; }
        public Roles Role { get; set; }
        public string Name { get; set; }
        public  decimal Wallet { get; set; }

        
    }
}