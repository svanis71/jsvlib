using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.Web.UI.WebControls;
using Dinamico;
using Dinamico.Models;
using N2;
using N2.Details;
using N2.Persistence;
using famsvanstrom.se.Svanstrom.N2.Detail;

namespace famsvanstrom.se.Models.Pages
{
    [PageDefinition(Name="Ett spel", Title = "Spel", Description = "Min generella sidtemplate för javascriptspel.")]
    [WithEditableTemplateSelection(ContainerName = Defaults.Containers.Metadata)]
    [WithEditableTitle]
    public class GamePage : ContentPage
    {
        [EditableGame]
        [Persistable(Length = 20)]
        public string Game { get; set; }

        [EditableText(Name = "Javascript files", Columns = 60, Rows = 6, Title = "Javascriptfiler", 
            TextMode = TextBoxMode.MultiLine, MaxLength = 200, Placeholder = "En js-fil per rad.")]
        [Persistable(Length = 200)]
        public string JavaScriptFiles { get; set; }

    }
}