using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Resolvers;
using GraphQL.Types;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace JZSoft.OrchardCore.RDBMS.Services
{
    public class ContentFieldsValuePathProvider : IContentFieldsValuePathProvider
    {
        public static Dictionary<string, FieldTypeValuePathDescriptor> ContentFieldValuePathMappings = new Dictionary<string, FieldTypeValuePathDescriptor>
        {
            {
                nameof(BooleanField),
                new FieldTypeValuePathDescriptor
                {
                    FieldName=nameof(BooleanField),
                    Description = "Boolean field",
                    FieldType = typeof(bool),
                    UnderlyingType = typeof(BooleanField),
                    FieldAccessor = field => (bool)field.Content.Value
                }
            },
            {
                nameof(DateField),
                new FieldTypeValuePathDescriptor
                {
                    FieldName=nameof(DateField),
                    Description = "Date field",
                    FieldType = typeof(DateTime?),
                    UnderlyingType = typeof(DateField),
                    FieldAccessor = field => (DateTime?)field.Content.Value
                }
            },
            {
                nameof(DateTimeField),
                new FieldTypeValuePathDescriptor
                {
                    Description = "Date & time field",
                    FieldName=nameof(DateTimeField),
                    FieldType = typeof(DateTime?),
                    UnderlyingType = typeof(DateTimeField),
                    FieldAccessor = field => (DateTime?)field.Content.Value
                }
            },
            {
                nameof(NumericField),
                new FieldTypeValuePathDescriptor
                {
                    Description = "Numeric field",
                    FieldName=nameof(NumericField),
                    FieldType = typeof(decimal?),
                    UnderlyingType = typeof(NumericField),
                    FieldAccessor = field => (decimal?)field.Content.Value
                }
            },
            {
                nameof(TextField),
                new FieldTypeValuePathDescriptor
                {
                    Description = "Text field",
                    FieldName=nameof(TextField),
                    FieldType = typeof(string),
                    UnderlyingType = typeof(TextField),
                    ValuePath="Text",
                    FieldAccessor = field => field.Content.Text
                }
            },
            {
                nameof(TimeField),
                new FieldTypeValuePathDescriptor
                {
                    FieldName=nameof(TimeField),
                    Description = "Time field",
                    FieldType = typeof(TimeSpan?),
                    UnderlyingType = typeof(TimeField),
                    FieldAccessor = field => (TimeSpan?)field.Content.Value
                }
            },
            {
                nameof(MultiTextField),
                new FieldTypeValuePathDescriptor
                {
                    Description = "Multi text field",
                    FieldType = typeof(string),
                    UnderlyingType = typeof(MultiTextField),
                    ValuePath=nameof(MultiTextField.Values),
                    FieldAccessor = field => field.Content.Values
                }
            }
        };

        public static Dictionary<Type, FieldTypeValuePathDescriptor> ContentFieldTypehMappings = ContentFieldValuePathMappings.Values.ToDictionary(x => x.FieldType);

        public FieldTypeValuePathDescriptor GetField(ContentPartFieldDefinition field)
        {
            if (!ContentFieldValuePathMappings.ContainsKey(field.FieldDefinition.Name)) return null;
            var fieldDescriptor = ContentFieldValuePathMappings[field.FieldDefinition.Name];
            return fieldDescriptor;
        }

        public FieldTypeValuePathDescriptor GetField<T>(T fieldType)
        {
            return GetField(fieldType.GetType());
        }
        public FieldTypeValuePathDescriptor GetField(Type fieldType)
        {
            if (!ContentFieldTypehMappings.ContainsKey(fieldType)) return null;
            var fieldDescriptor = ContentFieldTypehMappings[fieldType];
            return fieldDescriptor;
        }

    }



    public class FieldTypeValuePathDescriptor
    {
        public string Description { get; set; }
        public string FieldName { get; set; }
        public Type FieldType { get; set; }
        public Type UnderlyingType { get; set; }
        public Func<ContentElement, object> FieldAccessor { get; set; }
        public string ValuePath { get; set; } = "Value";
    }


}
