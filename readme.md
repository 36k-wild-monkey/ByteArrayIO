# ByteArrayIO

[![NuGet version (ByteArrayIO)](https://img.shields.io/nuget/v/ByteArrayIO.svg?style=flat-square)](https://www.nuget.org/packages/ByteArrayIO/)


### Example
```c#
using (ByteArray stream = new ByteArray())
{
    string str1 = "";
    string str2 = "";
    Byte num = 0;

    stream.WriteString("123")
        .WriteString("456")
        .WriteUInt8(1)
        .Seek(0, System.IO.SeekOrigin.Begin)
        .ReadString((x) => str1 = x)
        .ReadString((x) => str2 = x)
        .ReadUInt8((x) => num = x);

    Debug.WriteLine("{0} {1} {2}", str1, str2, num);
}
```
