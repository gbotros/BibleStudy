namespace BibleReader;

public interface IBibleReaderService
{
    Task<IEnumerable<BibleVerse>> ReadChapter(string bookName, int chapter);
    Task<string> ReadChapterAsText(string bookName, int chapter);
}
