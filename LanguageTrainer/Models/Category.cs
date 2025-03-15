namespace LanguageTrainer.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<WordCategory> WordCategories { get; set; }
}
