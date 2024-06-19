namespace Shared;

public interface IFileNameHelper
{
    string GetTheBiblePath(string fileExtension, bool indented  );
    string GetBookPath(string fileExtension, string bookName, bool indented  );
    string GetChapterPath(string fileExtension, string bookName, int chapter, bool indented  );
    string GetSummaryFilePath(string fileExtension, string summaryName, bool indented  );
}

public class FileNameHelper : IFileNameHelper
{
    public string GetTheBiblePath(string fileExtension, bool indented  )
    {
        var root = GetRootDirectoryPath();
        return Path.Combine(root, $"TheBible{GetIndentedSuffix(indented)}.{fileExtension}");
    }

    public string GetBookPath(string fileExtension, string bookName, bool indented )
    {
        var root = GetRootDirectoryPath();
        return Path.Combine(root, bookName, $"{bookName}{GetIndentedSuffix(indented)}.{fileExtension}");
    }

    public string GetChapterPath(string fileExtension, string bookName, int chapter, bool indented)
    {
        var root = GetRootDirectoryPath();
        return Path.Combine(root, bookName, $"{bookName} {chapter}{GetIndentedSuffix(indented)}.{fileExtension}"); ;
    }

    public  string GetSummaryFilePath(string fileExtension, string summaryName, bool indented)
    {
        return Path.Combine(GetRootDirectoryPath(), "summaries", $"{summaryName}{GetIndentedSuffix(indented)}.{fileExtension}");
    }

    private static string GetRootDirectoryPath()
    {
        var exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var root = Directory.GetParent(exeDirectory)?.Parent?.Parent?.Parent?.Parent?.Parent?.FullName ?? exeDirectory;
        return Path.Combine(root, "TheBible");
    }

    private static string GetIndentedSuffix(bool indented)
    {
        return indented ? "-indented" : "";
    }

}
