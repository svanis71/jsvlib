using Dinamico;
using Dinamico.Models;
using N2;
using N2.Details;
using N2.Persistence;

namespace famsvanstrom.se.Models.Pages
{
    [PageDefinition(Name = "Personnummerkoll", Title = "Personnummerkollen", Description = "Ett verktyg för att få fram rätt checksiffra på ett personnummer.")]
    [WithEditableTemplateSelection(ContainerName = Defaults.Containers.Metadata)]
    public class SsnTestPage : ContentPage
    {
        [EditableText(DefaultValue="Ange personnummer att kontrollera", Title = "Rubrik för textinmatning")]
        [Persistable(Length = 50)]
        public string Label { get; set; }

        [EditableText(Title = "Vattenmärkestext", DefaultValue = "Personnummer")]
        [Persistable(Length = 20)]
        public string Placeholder { get; set; }

    }
}