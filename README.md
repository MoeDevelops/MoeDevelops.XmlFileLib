# XmlFile

A wrapper around XmlSerializer

## Usage

Can be used either with an instance or statically

```cs
XmlFile<List<string>>.Save("List.xml", myList);
var xmlFile = new XmlFile<List<string>>("List.xml");
xmlFile.Save(myList);
```
