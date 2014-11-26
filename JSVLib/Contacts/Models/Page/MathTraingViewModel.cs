using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contacts.Models.Page
{
    internal class EnumList
    {
        public int Value { get; set; }
        public string Text { get; set; } 
    }

    public class MathTraingViewModel
    {
        [Required]
        [Display(Name = "Svårighet")]
        public Difficulty difficulty { get; set; }
        [Required]
        [Display(Name = "Antal tal")]
        public int numbers { get; set; }


        [Display(Name = "Svårighet")]
        public SelectList Difficulties
        {
            get
            {
                var list = (from object value in Enum.GetValues(typeof (Difficulty))
                            select new EnumList() {Value = (int) value, Text = Enum.GetName(typeof (Difficulty), value)}).ToList();
                list.Insert(0, new EnumList() {Text = "Välj här"});
                return new SelectList(list, "Value", "Text");
            }
        }
        [Display(Name = "Antal tal")]
        public SelectList NumberCount
        {
            get
            {
                List<int> list = new List<int>();
                for (int i = 1; i <= 10; i++)
                {
                    list.Add(i * 10);
                }
                var selList = new SelectList(list);
                return selList;
            }
        }
    }
}