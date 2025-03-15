namespace LanguageTrainer.Models;

public class WordCategory
{
    public int WordId { get; set; }
    public Word Word { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}