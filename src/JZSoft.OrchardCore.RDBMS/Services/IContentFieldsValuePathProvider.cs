using OrchardCore.ContentManagement.Metadata.Models;

namespace JZSoft.OrchardCore.RDBMS.Services
{
    public interface IContentFieldsValuePathProvider
    {
        FieldTypeValuePathDescriptor GetField(ContentPartFieldDefinition field);
    }
}