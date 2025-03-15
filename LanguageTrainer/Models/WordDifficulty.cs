namespace LanguageTrainer.Models;

public class WordDifficulty
{
    public int Id { get; set; }
    public int WordId { get; set; }
    public Word Word { get; set; }
    public string DifficultyLevel { get; set; }
}