using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Dinamico.Models;
using N2;
using N2.Details;

namespace Dinamico.Dinamico.Models
{
    [PageDefinition(Name = "Personnummergenerator", Title = "Personnummergenerator", Description = "Ett litet verktyg jag använder för att slumpa fram personnummer med rätt checksiffra.")]
    [WithEditableTemplateSelection(ContainerName = Defaults.Containers.Metadata)]
    public class SsnGenModel : ContentPage
    {
        public SsnGenModel()
        {
            DefaultNumberOfSsn = "1000";
        }

        public string PageTitle { get; set;  }
        [EditableText(DefaultValue = "1000", Title = "Standardvärde på antal personnummer")]
        public string DefaultNumberOfSsn { get; set; }

        [Required]
        [Display(Name = "Antal personnummer", Prompt = "Antal personnummer")]
        public int NumberOfSsn { get; set; }
    }
}