namespace PoliHack18.Models
{
    public class User
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}