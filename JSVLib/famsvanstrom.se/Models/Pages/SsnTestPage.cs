// // famsvanstrom.se: SsnTestPage.cs
// // Author: Johan Svanström
// // Created: 2015-05-29
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using Dinamico;
using Dinamico.Models;
using N2;
using N2.Details;
using N2.Persistence;

#endregion

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