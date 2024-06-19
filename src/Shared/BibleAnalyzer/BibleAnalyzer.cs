
namespace BibleAnalyzer;

public interface IBibleAnalyzer
{
    BibleSummary Analyze(IEnumerable<BibleVerse> verses, HashSet<string> oldTestamentBooks, HashSet<string> newTestamentBooks);
}

public class BibleAnalyzer() : IBibleAnalyzer
{
    public BibleSummary Analyze(IEnumerable<BibleVerse> verses, HashSet<string> oldTestamentBooks, HashSet<string> newTestamentBooks)
    {
        var bibleSummary = new BibleSummary();

        // build empty books dictionary for old and new testament
        foreach (var book in oldTestamentBooks) bibleSummary.OldTestamentSummary.Books.Add(book, new BookSummary(book));
        foreach (var book in newTestamentBooks) bibleSummary.NewTestamentSummary.Books.Add(book, new BookSummary(book));

        foreach (var verse in verses)
        {
            foreach (var word in verse.Words)
            {
                var isOldTestament = oldTestamentBooks.Contains(verse.BookName);
                var isNewTestament = newTestamentBooks.Contains(verse.BookName);
                if (!isOldTestament && !isNewTestament) throw new ArgumentException($"Unknow book name {verse.BookName}");

                UpdateWordsDictionary(bibleSummary.Words, word);

                var testamentSummary = isOldTestament ? bibleSummary.OldTestamentSummary : bibleSummary.NewTestamentSummary;
                UpdateWordsDictionary(testamentSummary.Words, word);

                var bookWords = testamentSummary.Books[verse.BookName].Words;
                UpdateWordsDictionary(bookWords, word);
            }
        }

        return bibleSummary;
    }

    private static void UpdateWordsDictionary(IDictionary<string, int> wordsDictionary, string word)
    {
        wordsDictionary.TryAdd(word, 0);
        wordsDictionary[word]++;
    }
}
