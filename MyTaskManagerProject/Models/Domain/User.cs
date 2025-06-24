namespace MyTaskManagerProject.Models.Domain
{
    public class User
    {
        public int Id { get; set; }

        public required string Login { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get;set; }
    }
}
