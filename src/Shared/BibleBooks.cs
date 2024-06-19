namespace Shared;

public static class BibleBooks
{
    static BibleBooks()
    {
        Books = [
        Genesis,
        Exodus,
        Leviticus,
        Numbers,
        Deuteronomy,
        Joshua,
        Judges,
        Ruth,
        OneSamuel,
        TwoSamuel,
        OneKings,
        TwoKings,
        OneChronicles,
        TwoChronicles,
        Ezra,
        Nehemiah,
        Esther,
        Job,
        Psalms,
        Proverbs,
        Ecclesiastes,
        SongOfSongs,
        Isaiah,
        Jeremiah,
        Lamentations,
        Ezekiel,
        Daniel,
        Hosea,
        Joel,
        Amos,
        Obadiah,
        Jonah,
        Micah,
        Nahum,
        Habakkuk,
        Zephaniah,
        Haggai,
        Zechariah,
        Malachi,
        Matthew,
        Mark,
        Luke,
        John,
        Acts,
        Romans,
        OneCorinthians,
        TwoCorinthians,
        Galatians,
        Ephesians,
        Philippians,
        Colossians,
        OneThessalonians,
        TwoThessalonians,
        OneTimothy,
        TwoTimothy,
        Titus,
        Philemon,
        Hebrews,
        James,
        OnePeter,
        TwoPeter,
        OneJohn,
        TwoJohn,
        ThreeJohn,
        Jude,
        Revelation
        ];
    }
    public static readonly IEnumerable<BibleBook> Books;

    #region OldTestament

    public static readonly BibleBook Genesis = new(name: "Genesis", abbreviation: "Gen", chaptersCount: 50, testament: Testament.OldTestament);
    public static readonly BibleBook Exodus = new(name: "Exodus", abbreviation: "Exo", chaptersCount: 40, testament: Testament.OldTestament);
    public static readonly BibleBook Leviticus = new(name: "Leviticus", abbreviation: "Lev", chaptersCount: 27, testament: Testament.OldTestament);
    public static readonly BibleBook Numbers = new(name: "Numbers", abbreviation: "Num", chaptersCount: 36, testament: Testament.OldTestament);
    public static readonly BibleBook Deuteronomy = new(name: "Deuteronomy", abbreviation: "Deu", chaptersCount: 34, testament: Testament.OldTestament);
    public static readonly BibleBook Joshua = new(name: "Joshua", abbreviation: "Jos", chaptersCount: 24, testament: Testament.OldTestament);
    public static readonly BibleBook Judges = new(name: "Judges", abbreviation: "Jdg", chaptersCount: 21, testament: Testament.OldTestament);
    public static readonly BibleBook Ruth = new(name: "Ruth", abbreviation: "Rut", chaptersCount: 4, testament: Testament.OldTestament);
    public static readonly BibleBook OneSamuel = new(name: "1 Samuel", abbreviation: "1Sa", chaptersCount: 31, testament: Testament.OldTestament);
    public static readonly BibleBook TwoSamuel = new(name: "2 Samuel", abbreviation: "2Sa", chaptersCount: 24, testament: Testament.OldTestament);
    public static readonly BibleBook OneKings = new(name: "1 Kings", abbreviation: "1Ki", chaptersCount: 22, testament: Testament.OldTestament);
    public static readonly BibleBook TwoKings = new(name: "2 Kings", abbreviation: "2Ki", chaptersCount: 25, testament: Testament.OldTestament);
    public static readonly BibleBook OneChronicles = new(name: "1 Chronicles", abbreviation: "1Ch", chaptersCount: 29, testament: Testament.OldTestament);
    public static readonly BibleBook TwoChronicles = new(name: "2 Chronicles", abbreviation: "2Ch", chaptersCount: 36, testament: Testament.OldTestament);
    public static readonly BibleBook Ezra = new(name: "Ezra", abbreviation: "Ezr", chaptersCount: 10, testament: Testament.OldTestament);
    public static readonly BibleBook Nehemiah = new(name: "Nehemiah", abbreviation: "Neh", chaptersCount: 13, testament: Testament.OldTestament);
    public static readonly BibleBook Esther = new(name: "Esther", abbreviation: "Est", chaptersCount: 10, testament: Testament.OldTestament);
    public static readonly BibleBook Job = new(name: "Job", abbreviation: "Job", chaptersCount: 42, testament: Testament.OldTestament);
    public static readonly BibleBook Psalms = new(name: "Psalms", abbreviation: "Psa", chaptersCount: 150, testament: Testament.OldTestament);
    public static readonly BibleBook Proverbs = new(name: "Proverbs", abbreviation: "Pro", chaptersCount: 31, testament: Testament.OldTestament);
    public static readonly BibleBook Ecclesiastes = new(name: "Ecclesiastes", abbreviation: "Ecc", chaptersCount: 12, testament: Testament.OldTestament);
    public static readonly BibleBook SongOfSongs = new(name: "The Song of Songs", abbreviation: "Sos", chaptersCount: 8, testament: Testament.OldTestament);
    public static readonly BibleBook Isaiah = new(name: "Isaiah", abbreviation: "Isa", chaptersCount: 66, testament: Testament.OldTestament);
    public static readonly BibleBook Jeremiah = new(name: "Jeremiah", abbreviation: "Jer", chaptersCount: 52, testament: Testament.OldTestament);
    public static readonly BibleBook Lamentations = new(name: "Lamentations", abbreviation: "Lam", chaptersCount: 5, testament: Testament.OldTestament);
    public static readonly BibleBook Ezekiel = new(name: "Ezekiel", abbreviation: "Eze", chaptersCount: 48, testament: Testament.OldTestament);
    public static readonly BibleBook Daniel = new(name: "Daniel", abbreviation: "Dan", chaptersCount: 12, testament: Testament.OldTestament);
    public static readonly BibleBook Hosea = new(name: "Hosea", abbreviation: "Hos", chaptersCount: 14, testament: Testament.OldTestament);
    public static readonly BibleBook Joel = new(name: "Joel", abbreviation: "Joe", chaptersCount: 3, testament: Testament.OldTestament);
    public static readonly BibleBook Amos = new(name: "Amos", abbreviation: "Amo", chaptersCount: 9, testament: Testament.OldTestament);
    public static readonly BibleBook Obadiah = new(name: "Obadiah", abbreviation: "Oba", chaptersCount: 1, testament: Testament.OldTestament);
    public static readonly BibleBook Jonah = new(name: "Jonah", abbreviation: "Jon", chaptersCount: 4, testament: Testament.OldTestament);
    public static readonly BibleBook Micah = new(name: "Micah", abbreviation: "Mic", chaptersCount: 7, testament: Testament.OldTestament);
    public static readonly BibleBook Nahum = new(name: "Nahum", abbreviation: "Nah", chaptersCount: 3, testament: Testament.OldTestament);
    public static readonly BibleBook Habakkuk = new(name: "Habakkuk", abbreviation: "Hab", chaptersCount: 3, testament: Testament.OldTestament);
    public static readonly BibleBook Zephaniah = new(name: "Zephaniah", abbreviation: "Zep", chaptersCount: 3, testament: Testament.OldTestament);
    public static readonly BibleBook Haggai = new(name: "Haggai", abbreviation: "Hag", chaptersCount: 2, testament: Testament.OldTestament);
    public static readonly BibleBook Zechariah = new(name: "Zechariah", abbreviation: "Zec", chaptersCount: 14, testament: Testament.OldTestament);
    public static readonly BibleBook Malachi = new(name: "Malachi", abbreviation: "Mal", chaptersCount: 4, testament: Testament.OldTestament);

    #endregion

    #region New Testament
    public static readonly BibleBook Matthew = new(name: "Matthew", abbreviation: "Mat", chaptersCount: 28, testament: Testament.NewTestament);
    public static readonly BibleBook Mark = new(name: "Mark", abbreviation: "Mar", chaptersCount: 16, testament: Testament.NewTestament);
    public static readonly BibleBook Luke = new(name: "Luke", abbreviation: "Luk", chaptersCount: 24, testament: Testament.NewTestament);
    public static readonly BibleBook John = new(name: "John", abbreviation: "Joh", chaptersCount: 21, testament: Testament.NewTestament);
    public static readonly BibleBook Acts = new(name: "Acts", abbreviation: "Act", chaptersCount: 28, testament: Testament.NewTestament);
    public static readonly BibleBook Romans = new(name: "Romans", abbreviation: "Rom", chaptersCount: 16, testament: Testament.NewTestament);
    public static readonly BibleBook OneCorinthians = new(name: "1 Corinthians", abbreviation: "1Co", chaptersCount: 16, testament: Testament.NewTestament);
    public static readonly BibleBook TwoCorinthians = new(name: "2 Corinthians", abbreviation: "2Co", chaptersCount: 13, testament: Testament.NewTestament);
    public static readonly BibleBook Galatians = new(name: "Galatians", abbreviation: "Gal", chaptersCount: 6, testament: Testament.NewTestament);
    public static readonly BibleBook Ephesians = new(name: "Ephesians", abbreviation: "Eph", chaptersCount: 6, testament: Testament.NewTestament);
    public static readonly BibleBook Philippians = new(name: "Philippians", abbreviation: "Phi", chaptersCount: 4, testament: Testament.NewTestament);
    public static readonly BibleBook Colossians = new(name: "Colossians", abbreviation: "Col", chaptersCount: 4, testament: Testament.NewTestament);
    public static readonly BibleBook OneThessalonians = new(name: "1 Thessalonians", abbreviation: "1Th", chaptersCount: 5, testament: Testament.NewTestament);
    public static readonly BibleBook TwoThessalonians = new(name: "2 Thessalonians", abbreviation: "2Th", chaptersCount: 3, testament: Testament.NewTestament);
    public static readonly BibleBook OneTimothy = new(name: "1 Timothy", abbreviation: "1Ti", chaptersCount: 6, testament: Testament.NewTestament);
    public static readonly BibleBook TwoTimothy = new(name: "2 Timothy", abbreviation: "2Ti", chaptersCount: 4, testament: Testament.NewTestament);
    public static readonly BibleBook Titus = new(name: "Titus", abbreviation: "Tit", chaptersCount: 3, testament: Testament.NewTestament);
    public static readonly BibleBook Philemon = new(name: "Philemon", abbreviation: "Phm", chaptersCount: 1, testament: Testament.NewTestament);
    public static readonly BibleBook Hebrews = new(name: "Hebrews", abbreviation: "Heb", chaptersCount: 13, testament: Testament.NewTestament);
    public static readonly BibleBook James = new(name: "James", abbreviation: "Jam", chaptersCount: 5, testament: Testament.NewTestament);
    public static readonly BibleBook OnePeter = new(name: "1 Peter", abbreviation: "1Pe", chaptersCount: 5, testament: Testament.NewTestament);
    public static readonly BibleBook TwoPeter = new(name: "2 Peter", abbreviation: "2Pe", chaptersCount: 3, testament: Testament.NewTestament);
    public static readonly BibleBook OneJohn = new(name: "1 John", abbreviation: "1Jo", chaptersCount: 5, testament: Testament.NewTestament);
    public static readonly BibleBook TwoJohn = new(name: "2 John", abbreviation: "2Jo", chaptersCount: 1, testament: Testament.NewTestament);
    public static readonly BibleBook ThreeJohn = new(name: "3 John", abbreviation: "3Jo", chaptersCount: 1, testament: Testament.NewTestament);
    public static readonly BibleBook Jude = new(name: "Jude", abbreviation: "Jud", chaptersCount: 1, testament: Testament.NewTestament);
    public static readonly BibleBook Revelation = new(name: "Revelation", abbreviation: "Rev", chaptersCount: 22, testament: Testament.NewTestament);

    #endregion
}

public class BibleBook(string name, string abbreviation, int chaptersCount, Testament testament)
{
    public string Name { get; set; } = name;
    public string Abbreviation { get; set; } = abbreviation;
    public int ChaptersCount { get; set; } = chaptersCount;
    public Testament Testament { get; set; } = testament;
}

public enum Testament { OldTestament, NewTestament }
