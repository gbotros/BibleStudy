using System.Net.Http;

namespace BibleReader;

public interface IBibleJsonReaderService
{
    Task<IEnumerable<BibleVerse>> ReadTheBible(string theBibleFilePath);
}

public sealed class BibleJsonReaderService() : IBibleJsonReaderService
{
    public async Task<IEnumerable<BibleVerse>> ReadTheBible(string theBibleFilePath)
    {
        var theBiblePath = theBibleFilePath;
        using FileStream stream = File.OpenRead(theBiblePath);
        var theBibleVerses = await stream.DeserializeAsync<IEnumerable<BibleVerse>>()
            ?? throw new Exception("Error reading the bible file");
        return theBibleVerses;
    }
}
