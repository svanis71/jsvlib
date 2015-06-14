// // famsvanstrom.se: RecursiveZoneAdapter.cs
// // Author: Johan Svanström
// // Created: 2015-04-30
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Linq;
using Dinamico.Models;
using N2;
using N2.Engine;
using N2.Web.Parts;

#endregion

namespace Dinamico.Registrations
{
    /// <summary>
    /// Implements "Recusive" zones functionality.
    /// </summary>
    [Adapts(typeof(ContentPage))]
    public class RecursiveZonesAdapter : PartsAdapter
    {
        public override System.Collections.Generic.IEnumerable<ContentItem> GetParts(ContentItem page, string zoneName, string @interface)
        {
            var items = base.GetParts(page, zoneName, @interface);

            var pageParent = page.VersionOf.HasValue
                                      ? (ContentItem)page.VersionOf.Parent
                                      : page.Parent;

            if (pageParent != null && zoneName.StartsWith("Recursive"))
                return items.Union(GetParts(pageParent, zoneName, @interface));

            return items;
        }
    }
}
