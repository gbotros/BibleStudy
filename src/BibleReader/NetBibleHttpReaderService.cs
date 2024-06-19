namespace BibleReader;

public sealed class NetBibleHttpReaderService(IHttpClientFactory httpClientFactory, ILogger<IBibleReaderService> logger) : IBibleReaderService
{
    public async Task<string> ReadChapterAsText(string bookName, int chapter)
    {
        using HttpClient client = httpClientFactory.CreateClient("netBibleApiUrl");

        try
        {
            var chapterText= await client.GetStringAsync($"?passage={bookName} {chapter}");
            return chapterText;
        }
        catch (Exception ex)
        {
            logger.LogError("Error reading {bookName} {chapter} :: {Error}", bookName, chapter, ex);
        }

        return "";
    }

    public async Task<IEnumerable<BibleVerse>> ReadChapter(string bookName, int chapter)
    {
        using HttpClient client = httpClientFactory.CreateClient("netBibleApiUrl");

        try
        {
            BibleVerse[]? chapterVerses = await client.GetFromJsonAsync<BibleVerse[]>(
                $"?passage={bookName} {chapter}&type=json",
                new JsonSerializerOptions(JsonSerializerDefaults.Web));

            return chapterVerses ?? [];
        }
        catch (Exception ex)
        {
            logger.LogError("Error reading {bookName} {chapter} :: {Error}", bookName, chapter, ex);
        }

        return [];
    }
}

