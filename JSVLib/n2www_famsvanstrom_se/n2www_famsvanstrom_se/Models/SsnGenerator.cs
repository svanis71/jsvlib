using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dinamico.Models;
using N2;
using N2.Details;

namespace n2www_famsvanstrom_se.Models
{
    [PartDefinition(Title = "Personnummergenerator", TemplateUrl = "SsnGen", IconClass = "")]
    public class SsnGenerator : PartModelBase
    {
        public const string NumberOfSsnKey = "NumberOfSsn";
        public const string InputTitleKeyName = "InputTitle";
        public const int DefaultNumberOfSsnValue = 1000;
        public const string DefaultAntalPersonnummerInputTitle = "Antal personnummer";

        [EditableText(Title = DefaultAntalPersonnummerInputTitle, DefaultValue = "")]
        public string InputTitle
        {
            get { return (string) GetDetail(InputTitleKeyName) ?? DefaultAntalPersonnummerInputTitle; }
            set { SetDetail(InputTitleKeyName, value, DefaultAntalPersonnummerInputTitle); }
        }

        [EditableText(Title = "Standardvärde på personnummer", DefaultValue = 1000)]
        public int? DefaultNumberOfSsn
        {
            get { return (int?) GetDetail(NumberOfSsnKey) ?? DefaultNumberOfSsnValue; }
            set { SetDetail(NumberOfSsnKey, value, DefaultNumberOfSsnValue); }
        }
    }
}