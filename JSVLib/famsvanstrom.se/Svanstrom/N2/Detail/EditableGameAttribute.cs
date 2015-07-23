using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using N2.Details;

namespace famsvanstrom.se.Svanstrom.N2.Detail
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EditableGameAttribute : EditableDropDownAttribute
    {
        protected override ListItem[] GetListItems()
        {
            return GamesList().Select(game => new ListItem(game, game)).ToArray();
        }

        private IEnumerable<string> GamesList()
        {
            var scriptPath = HttpContext.Current.Server.MapPath("~/Scripts/games");
            return Directory.EnumerateDirectories(scriptPath).Select(Path.GetFileName).ToList();
        }
    }
}