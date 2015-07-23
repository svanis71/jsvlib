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

    [PageDefinition(Name = "Annas jobbschema", Title = "Annas schemaläggare", Description = "Ett hjälpmedel för att få in Annas jobbtider i Google calendar")]
    [WithEditableTemplateSelection(ContainerName = Defaults.Containers.Metadata)]
    public class SchemaModel : ContentPage
    {
        private string _calendarName;

        public SchemaModel()
        {
        }

        [Display(Name = "Namn på googlekalendern", Prompt = "Googlekalender")]
        [EditableText(DefaultValue = "nellis76@gmail.com", Title = "Välj googlekalender")]
        public string CalendarName
        {
            get { return _calendarName; }
            set { _calendarName = value; }
        }
    }
}