namespace MoeDevelops.XmlFileLib.Test;

public class TestFileAccess : IDisposable
{
    public TestFileAccess(string fileName)
    {
        const string dirName = "TestFiles";

        FilePath = Path.Combine(dirName, fileName);

        if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);

        DeleteIfExists();
    }

    public string FilePath { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        DeleteIfExists();
    }

    private void DeleteIfExists()
    {
        if (File.Exists(FilePath)) File.Delete(FilePath);
    }
}