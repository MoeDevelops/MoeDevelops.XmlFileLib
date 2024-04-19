using NUnit.Framework;

namespace MoeDevelops.XmlFileLib.Test;

[TestFixture]
public class XmlFileTest
{
    [Test]
    public void TestSavingLoadingStatic()
    {
        using var fileAccess = new TestFileAccess("TestFile.xml");

        var list = new List<string>
        {
            "Test1",
            "Test2",
            "Test3"
        };

        XmlFile<List<string>>.Save(fileAccess.FilePath, list);

        var listFromFile = XmlFile<List<string>>.Load(fileAccess.FilePath);

        Assert.That(list, Is.EquivalentTo(listFromFile));
    }

    [Test]
    public void TestSavingLoading()
    {
        using var fileAccess = new TestFileAccess("TestFile.xml");

        var list = new List<string>
        {
            "Test1",
            "Test2",
            "Test3"
        };

        var xmlFile = new XmlFile<List<string>>(fileAccess.FilePath);

        xmlFile.Save(list);

        var listFromFile = xmlFile.Load();

        Assert.That(list, Is.EquivalentTo(listFromFile));
    }
}