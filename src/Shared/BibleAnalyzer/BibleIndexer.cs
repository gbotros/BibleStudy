
namespace BibleAnalyzer;

public interface IBibleIndexer
{
    BibleIndex Index(IEnumerable<BibleBook> books, IEnumerable<BibleVerse> verses);
}
public class BibleIndexer() : IBibleIndexer
{
    public BibleIndex Index(IEnumerable<BibleBook> books, IEnumerable<BibleVerse> verses)
    {
        var wordVerses = new Dictionary<string, HashSet<string>>();

        foreach (var verse in verses)
        {
            foreach (var word in verse.Words)
            {
                wordVerses.TryAdd(word, []);
                wordVerses[word].Add(verse.Reference);
            }
        }

        var references = wordVerses
            .Select(wv => new { wv.Key, wv.Value })
            .OrderBy(wr => wr.Key)
            .ToDictionary(i => i.Key, i => i.Value.AsEnumerable());
        var indexSummary = new BibleIndex(references);

        return indexSummary;
    }


}



