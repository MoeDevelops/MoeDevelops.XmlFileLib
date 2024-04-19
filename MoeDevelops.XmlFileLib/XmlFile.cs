using System.Xml.Serialization;

namespace MoeDevelops.XmlFileLib;

/// <summary>
///     A wrapper around the XmlSerializer
/// </summary>
/// <typeparam name="T">Type of the object that will be saved or loaded</typeparam>
public class XmlFile<T>
{
    /// <param name="filePath">Path of the file that will be loaded or saved</param>
    public XmlFile(string filePath)
    {
        FilePath = filePath;
        Serializer = new XmlSerializer(typeof(T));
    }

    private string FilePath { get; }
    private XmlSerializer Serializer { get; }

    /// <summary>
    ///     Saves an object
    /// </summary>
    /// <param name="obj">The object that will be saved</param>
    public void Save(T obj)
    {
        using var writer = GetWriter(FilePath);
        Serializer.Serialize(writer, obj);
    }

    /// <summary>
    ///     Loads an object
    /// </summary>
    /// <returns>The loaded object</returns>
    public T Load()
    {
        using var reader = GetReader(FilePath);
        return (T)Serializer.Deserialize(reader)!;
    }

    /// <summary>
    ///     Saves an object
    /// </summary>
    /// <param name="path">Path of the file that will be saved</param>
    /// <param name="obj">The object that will be saved</param>
    public static void Save(string path, T obj)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var writer = GetWriter(path);
        serializer.Serialize(writer, obj);
    }

    /// <summary>
    ///     Loads an object
    /// </summary>
    /// <param name="path">Path of the file that will be loaded</param>
    /// <returns>The loaded object</returns>
    public static T Load(string path)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = GetReader(path);
        return (T)serializer.Deserialize(reader)!;
    }

    private static TextWriter GetWriter(string path)
    {
        return new StreamWriter(path);
    }

    private static Stream GetReader(string path)
    {
        return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
    }
}