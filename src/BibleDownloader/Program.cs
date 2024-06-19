using static System.Net.Mime.MediaTypeNames;

var host = Host();

var httpBibleService = host.Services.GetService<IBibleReaderService>();
var fileSaver = host.Services.GetService<IFileSaver>();
var fileNameHelper = host.Services.GetService<IFileNameHelper>();
var logger = host.Services.GetService<ILogger<Program>>();
var analyzer = host.Services.GetService<IBibleAnalyzer>();
var indexer = host.Services.GetService<IBibleIndexer>();
var jsonBibleReader = host.Services.GetService<IBibleJsonReaderService>();

await DownloadTheBible(httpBibleService, fileSaver, fileNameHelper);
await RunAnalyzers();

async Task DownloadTheBible(IBibleReaderService? bibleService, IFileSaver? fileSaver, IFileNameHelper? fileNameHelper)
{
    var fullBibleVerses = new List<BibleVerse>();
    logger!.LogInformation("Start downloading the bible.");
    foreach (var book in BibleBooks.Books)
    {
        logger!.LogInformation("Start downloading {bookName}", book.Name);
        var bookVerses = new List<BibleVerse>();
        for (int chapter = 1; chapter <= book.ChaptersCount; chapter++)
        {
            var chapterVerses = await bibleService!.ReadChapter(book.Name, chapter);
            fullBibleVerses.AddRange(chapterVerses);
            bookVerses.AddRange(chapterVerses);

            //save chapter
            await SaveChapterVersesJson(chapterVerses, book.Name, chapter, indented: true);
            await SaveChapterVersesJson(chapterVerses, book.Name, chapter, indented: false);
            await SaveChapterVersesTxt(chapterVerses, book.Name, chapter);
        }

        await SaveBookVersesJson(bookVerses, book.Name, indented: true);
        await SaveBookVersesJson(bookVerses, book.Name, indented: false);
        await SaveBookVersesTxt(bookVerses, book.Name);
    }

    await SaveTheBibleJson(fullBibleVerses, indented: true);
    await SaveTheBibleJson(fullBibleVerses, indented: false);
}

async Task SaveChapterVersesJson(IEnumerable<BibleVerse> verses, string bookName, int chapter, bool indented)
{
    var jsonText = verses.SerializeToJson(indented);
    var filePath = fileNameHelper!.GetChapterPath("json", bookName, chapter, indented);
    await fileSaver!.SaveFile(filePath, jsonText);
}
async Task SaveBookVersesJson(IEnumerable<BibleVerse> verses, string bookName, bool indented)
{
    var jsonText = verses.SerializeToJson(indented);
    var filePath = fileNameHelper!.GetBookPath("json", bookName, indented);
    await fileSaver!.SaveFile(filePath, jsonText);
}
async Task SaveChapterVersesTxt(IEnumerable<BibleVerse> verses, string bookName, int chapter)
{
    var versesTextList = verses.Select(v => v.Text).ToList();
    var plainText = string.Join(Environment.NewLine, versesTextList);
    var filePath = fileNameHelper!.GetChapterPath("txt", bookName, chapter, false);
    await fileSaver!.SaveFile(filePath, plainText);

}
async Task SaveBookVersesTxt(IEnumerable<BibleVerse> verses, string bookName)
{
    var versesTextList = verses.Select(v => v.Text).ToList();
    var plainText = string.Join(Environment.NewLine, versesTextList);
    var filePath = fileNameHelper!.GetBookPath("json", bookName, false);
    await fileSaver!.SaveFile(filePath, plainText);
}

async Task SaveTheBibleJson(List<BibleVerse> fullBibleVerses, bool indented)
{
    var text = fullBibleVerses.SerializeToJson(indented);
    var filePath = fileNameHelper!.GetTheBiblePath("json", indented);
    await fileSaver!.SaveFile(filePath, text);
}

async Task RunAnalyzers()
{
    var theBiblePath = fileNameHelper!.GetTheBiblePath("json", indented: false);
    var verses = await jsonBibleReader!.ReadTheBible(theBiblePath);

    var analyzerTask = RunAnalyzerAndSaveSummary(verses);
    var indexerTask = RunIndexerAndSaveIndex(verses);
    await Task.WhenAll(analyzerTask, indexerTask);
}

async Task RunAnalyzerAndSaveSummary(IEnumerable<BibleVerse> verses)
{
    var oldTestamentBooks = BibleBooks.Books.Where(b => b.Testament == Testament.OldTestament).Select(b => b.Name).ToHashSet();
    var newTestamentBooks = BibleBooks.Books.Where(b => b.Testament == Testament.NewTestament).Select(b => b.Name).ToHashSet();
    var summary = analyzer!.Analyze(verses, oldTestamentBooks, newTestamentBooks);
    await SaveBibleSummary(summary, true);
    await SaveBibleSummary(summary, false);
    Console.WriteLine("Run Analyzer Completed");
}

async Task RunIndexerAndSaveIndex(IEnumerable<BibleVerse> verses)
{
    var summary = indexer!.Index(BibleBooks.Books, verses);
    await SaveIndex(summary, indented: true);
    await SaveIndex(summary, indented: false);
    Console.WriteLine("Run Indexer Completed");
}

async Task SaveBibleSummary(BibleSummary summary, bool indented)
{
    var summaryPath = fileNameHelper.GetSummaryFilePath("json", "bibleSummary", indented);
    var summaryText = summary.SerializeToJson(indented);
    await fileSaver!.SaveFile(summaryPath, summaryText);
}

async Task SaveIndex(BibleIndex summary, bool indented)
{
    var summaryPath = fileNameHelper.GetSummaryFilePath("json", "bibleIndex", indented);
    var text = summary.SerializeToJson(indented);
    await fileSaver!.SaveFile(summaryPath, text);
}

static IHost Host()
{
    var builder = new HostBuilder()
        .ConfigureServices((hostContext, services) =>
        {
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
                builder.AddFilter((provider, category, logLevel) =>
                {
                    var httpLog = category!.Contains("System.Net.Http.HttpClient");
                    if (!httpLog) return true;

                    return httpLog && logLevel >= LogLevel.Warning;
                });
                builder.SetMinimumLevel(LogLevel.Debug);
            });

            // downloader services
            services.AddHttpClient("netBibleApiUrl", client => { client.BaseAddress = new Uri("https://labs.bible.org/api/"); });
            services.AddSingleton<IBibleReaderService, NetBibleHttpReaderService>();
            services.AddSingleton<IFileSaver, FileSaver>();
            services.AddSingleton<IFileNameHelper, FileNameHelper>();

            // analyzers services
            services.AddSingleton<BibleAnalyzer.IBibleAnalyzer, BibleAnalyzer.BibleAnalyzer>();
            services.AddSingleton<IBibleIndexer, BibleIndexer>();
            services.AddSingleton<IBibleJsonReaderService, BibleJsonReaderService>();
        })
        .UseConsoleLifetime();

    var host = builder.Build();
    VerifyHost(host);
    return host;
}

static void VerifyHost(IHost host)
{
    var logger = host.Services.GetService<ILogger<Program>>();
    // downloader services
    var httpClient = host.Services.GetService<HttpClient>();
    var bibleService = host.Services.GetService<IBibleReaderService>();
    var fileSaver = host.Services.GetService<IFileSaver>();
    var nameHelper = host.Services.GetService<IFileNameHelper>();

    // analyzers services
    var bibleReader = host.Services.GetService<IBibleJsonReaderService>();
    var bibleAnalyzer = host.Services.GetService<IBibleAnalyzer>();
    var bibleIndexer = host.Services.GetService<IBibleIndexer>();

    // downloader services
    ArgumentNullException.ThrowIfNull(bibleService);
    ArgumentNullException.ThrowIfNull(logger);
    ArgumentNullException.ThrowIfNull(fileSaver);
    ArgumentNullException.ThrowIfNull(nameHelper);

    // analyzers services
    ArgumentNullException.ThrowIfNull(bibleReader);
    ArgumentNullException.ThrowIfNull(logger);
    ArgumentNullException.ThrowIfNull(bibleAnalyzer);
    ArgumentNullException.ThrowIfNull(bibleIndexer);

}
