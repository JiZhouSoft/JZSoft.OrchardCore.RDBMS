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
        public Step[] steps { get; set; }
    }

    public class Step
    {
        public string name { get; set; }
        public Contenttype[] ContentTypes { get; set; }
        public Contentpart[] ContentParts { get; set; }
    }

    public class Contenttype
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Settings Settings { get; set; }
        public Contenttypepartdefinitionrecord[] ContentTypePartDefinitionRecords { get; set; }
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

    public class Contenttypepartdefinitionrecord
    {
        public string PartName { get; set; }
        public string Name { get; set; }
        public Settings1 Settings { get; set; }
    }

    public class Settings1
    {
        public Contenttypepartsettings ContentTypePartSettings { get; set; }
    }

    public class Contenttypepartsettings
    {
        public string Position { get; set; }
    }

    public class Contentpart
    {
        public string Name { get; set; }
        public ContentpartSettings Settings { get; set; }
        public Contentpartfielddefinitionrecord[] ContentPartFieldDefinitionRecords { get; set; }
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

    public class Contentpartfielddefinitionrecord
    {
        public string FieldName { get; set; }
        public string Name { get; set; }
        public Settings3 Settings { get; set; }
    }

    public class Settings3
    {
        public Contentpartfieldsettings ContentPartFieldSettings { get; set; }

        //public Textfieldpredefinedlisteditorsettings TextFieldPredefinedListEditorSettings { get; set; }
    }

    public class Contentpartfieldsettings
    {
        public string DisplayName { get; set; }
        public string Position { get; set; }
        //public string Editor { get; set; }
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



