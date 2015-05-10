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
    [PageDefinition(Name = "Mina grejer", Title = "Mina grejer", Description = "Visar status på mina grejer som kopplats till tellsticken.")]
    [WithEditableTemplateSelection(ContainerName = Defaults.Containers.Metadata)]
    public class DevicesPageModel : ContentPage
    {

    }
}