namespace LanguageTrainer.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public bool IsApproved { get; set; }
    public bool IsAdmin { get; set; } 
    public ICollection<UserWord> UserWords { get; set; }
}
