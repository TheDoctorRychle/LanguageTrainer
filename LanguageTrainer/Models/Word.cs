namespace LanguageTrainer.Models;

public class Word
{
    public int Id { get; set; }
    public string English { get; set; }
    public string Polish { get; set; }
    public string Difficulty {get; set;}

    public ICollection<WordCategory> WordCategories { get; set; }
    public ICollection<UserWord> UserWords { get; set; }
    public ICollection<WordDifficulty> WordDifficulties { get; set; } 
}

