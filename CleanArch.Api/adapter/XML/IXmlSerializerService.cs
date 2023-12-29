namespace MyProject.Api.adapter.XML
{
    public interface IXmlSerializerService
    {
        T Deserialize<T>(string xml);
    }
}
