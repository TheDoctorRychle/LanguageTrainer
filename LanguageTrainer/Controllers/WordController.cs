using LanguageTrainer.Data;
using LanguageTrainer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageTrainer.Controllers;

[Route("api/words"), ApiController]
public class WordController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetWords()
    {
        var words = context.Words.ToList();
        return Ok(words);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetWord(int id)
    {
        var word = context.Words.Find(id);
        if (word == null) return NotFound();
        return Ok(word);
    }
    
    [HttpGet("category/{categoryId:int}")]
    public IActionResult GetWordsByCategory(int categoryId)
    {
        var words = context.Words
            .Where(w => context.WordCategories.Any(wc => wc.WordId == w.Id && wc.CategoryId == categoryId))
            .ToList();
        return Ok(words);
    }

    [HttpGet("difficulty/{level}")]
    public IActionResult GetWordsByDifficulty(string level)
    {
        var words = context.Words
            .Where(w => context.WordDifficulty.Any(wd => wd.WordId == w.Id && wd.DifficultyLevel == level))
            .ToList();
        return Ok(words);
    }
    

    [HttpPost]
    public IActionResult AddWord([FromBody] Word? word, [FromQuery] List<int>? categoryIds, [FromQuery] string difficulty)
    {
        if (word == null || categoryIds == null || string.IsNullOrEmpty(difficulty)) 
            return BadRequest("Brak wymaganych danych.");
        
        context.Words.Add(word);
        context.SaveChanges();
        foreach (var categoryId in categoryIds)
        {
            context.WordCategories.Add(new WordCategory
            {
                WordId = word.Id,
                CategoryId = categoryId
            });
        }
        context.WordDifficulty.Add(new WordDifficulty
        {
            WordId = word.Id,
            DifficultyLevel = difficulty
        });
        context.SaveChanges();
        return CreatedAtAction(nameof(GetWord), new { id = word.Id }, word);
    }
    
    [HttpPost("quiz/custom")]
    public IActionResult CreateCustomQuiz([FromBody] List<int> wordIds)
    {
        var words = context.Words
            .Where(w => wordIds.Contains(w.Id))
            .ToList();

        if (words.Count == 0) return BadRequest("Nie znaleziono żadnych słówek.");

        return Ok(words);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateWord(int id, [FromBody] Word updatedWord)
    {
        var word = context.Words.Find(id);
        if (word == null) return BadRequest();
        word.English = updatedWord.English;
        word.Polish = updatedWord.Polish;
        context.Words.Update(word);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteWord(int id)
    {
        var word = context.Words.Find(id);
        if (word == null) return NotFound();
        context.Words.Remove(word);
        context.SaveChanges();
        return NoContent();
    }
}