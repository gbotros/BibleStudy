namespace Shared;

public interface IFileSaver
{
    Task SaveFile(string filePathWithName, string text);
}

public class FileSaver : IFileSaver
{
    public async Task SaveFile(string filePathWithName, string text)
    {
        var directory = Path.GetDirectoryName(filePathWithName);
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory!);

        await File.WriteAllTextAsync(filePathWithName, text);
    }

}