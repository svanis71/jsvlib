using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dinamico;
using Dinamico.Models;
using N2;
using N2.Details;

namespace famsvanstrom.se.Models.Partials
{
    [PartDefinition(Name = "Weather", Description = "Weather data")]
    [WithEditableTemplateSelection(ContainerName = Defaults.Containers.Metadata)]
    public class WeatherPartialModel : ContentPart
    {
        public double IndoorTemprature { get; set; }
        public double IndoorHumidity { get; set; }
        public double OutdoorTemprature { get; set; }
        public double Rain { get; set; }
    }
}