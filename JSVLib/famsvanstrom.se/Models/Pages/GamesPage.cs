using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dinamico;
using Dinamico.Models;
using N2;
using N2.Details;

namespace famsvanstrom.se.Models.Pages
{
    [PageDefinition(Name = "Spel", Title = "Spel", Description = "Sida där diverse spel samlas")]
    [WithEditableTemplateSelection(ContainerName = Defaults.Containers.Metadata)]
    public class GamesPage : ContentPage
    {
        [EditableTextBox]
        public string CurrentGame { get; set; }
    }
}