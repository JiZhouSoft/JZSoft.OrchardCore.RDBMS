using Newtonsoft.Json.Linq;
using OrchardCore.ContentManagement.Metadata.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JZSoft.OrchardCore.RDBMS.ViewModels
{
    public class RecipeModel
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string description { get; set; }
        public string author { get; set; }
        public string website { get; set; }
        public string version { get; set; }
        public bool issetuprecipe { get; set; }
        public object[] categories { get; set; }
        public object[] tags { get; set; }
        public List<Step> steps { get; set; }
    }

    public class Step
    {
        public string name { get; set; }
        public List<Contenttype> ContentTypes { get; set; }
        public List<Contentpart> ContentParts { get; set; }
    }

    public class Contenttype
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public JObject Settings { get; set; }
        public ContentTypePartDefinitionRecord[] ContentTypePartDefinitionRecords { get; set; }
    }

    public class Settings
    {
        public Contenttypesettings ContentTypeSettings { get; set; }
    }

    public class Contenttypesettings
    {
        public bool Creatable { get; set; }
        public bool Listable { get; set; }
        public bool Draftable { get; set; }
        public bool Versionable { get; set; }
        public bool Securable { get; set; }
    }



    public class Contentpart
    {
        public string Name { get; set; }
        public ContentpartSettings Settings { get; set; }
        public ContentPartFieldDefinitionRecord[] ContentPartFieldDefinitionRecords { get; set; }
    }

    public class ContentpartSettings
    {
        public Contentpartsettings ContentPartSettings { get; set; }
    }

    public class Contentpartsettings
    {
        public bool Attachable { get; set; }
        public string Description { get; set; }
        public string DefaultPosition { get; set; }
    }



    public class Contentpartfieldsettings
    {
        public string DisplayName { get; set; }
        public string Position { get; set; }
    }



    public class Textfieldpredefinedlisteditorsettings
    {
        public Option[] Options { get; set; }
        public int Editor { get; set; }
        public string DefaultValue { get; set; }
    }

    public class Option
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}



