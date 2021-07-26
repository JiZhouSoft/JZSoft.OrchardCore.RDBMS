using OrchardCore.ContentManagement.Metadata.Models;
using System;

namespace JZSoft.OrchardCore.RDBMS.Services
{
    public interface IContentFieldsValuePathProvider
    {
        FieldTypeValuePathDescriptor GetField(ContentPartFieldDefinition field);
        FieldTypeValuePathDescriptor GetField<T>(T fieldType);
        FieldTypeValuePathDescriptor GetField(Type fieldType);
    }
}