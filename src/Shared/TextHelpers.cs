namespace Shared;

public static partial class TextHelpers
{
    private static readonly JsonSerializerOptions options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private static readonly JsonSerializerOptions optionsIndented = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true

    };

    public static string SerializeToJson(this object o, bool indented)
    {
        var selectedOptions = indented ? optionsIndented : options;
        return JsonSerializer.Serialize(o, selectedOptions);
    }

    public static async Task<T?> DeserializeAsync<T>(this FileStream stream)
    {
        return await JsonSerializer.DeserializeAsync<T>(stream, options);
    }

    public static string RemoveNonAlphanumericCharacters(this string text)
    {
        var verseLower = text.ToLower();
        return OnlyWordsRegex().Replace(verseLower, " ").Trim();
    }

    [GeneratedRegex(@"[^a-z ]")]
    private static partial Regex OnlyWordsRegex();
}
