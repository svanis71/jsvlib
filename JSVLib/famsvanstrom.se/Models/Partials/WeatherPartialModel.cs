using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dinamico;
using Dinamico.Models;
using N2;
using N2.Details;
using N2.Persistence;
using famsvanstrom.se.Services;

namespace famsvanstrom.se.Models.Partials
{
    [PartDefinition(Name = "Weather", Description = "Weather data")]
    [WithEditableTemplateSelection(ContainerName = Defaults.Containers.Metadata)]
    public class WeatherPartialModel : ContentPart
    {
        readonly TempratureDataService _tempratureDataService;

        public WeatherPartialModel()
        {
            _tempratureDataService = new TempratureDataService();
        }

        public TempratureDataService.CurrentWeather Weather
        {
            get { return _tempratureDataService.Weather; }
        }

        [EditableText(Placeholder = "Rubrik", Title = "Rubrik för innetempratur")]
        [Persistable(Length = 30)]
        public string IndoorTempratureLabel { get; set; }
        [EditableText(Placeholder = "Rubrik", Title = "Rubrik för utetempratur")]
        [Persistable(Length = 30)]
        public string OutdoorTempratureLabel { get; set; }
        [EditableText(Placeholder = "Rubrik", Title = "Rubrik för luftfuktighet")]
        [Persistable(Length = 30)]
        public string IndoorHumidityLabel { get; set; }

        public double IndoorTemprature { get; set; }
        public double IndoorHumidity { get; set; }
        public double OutdoorTemprature { get; set; }
        public double Rain { get; set; }
    }
}