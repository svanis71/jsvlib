// // famsvanstrom.se: PartModelBase.cs
// // Author: Johan Svanström
// // Created: 2015-04-30
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using N2;
using N2.Definitions;
using N2.Web.UI;

#endregion

namespace Dinamico.Models
{
    /// <summary>
    /// Base implementation of parts on a dinamico site.
    /// </summary>
    [SidebarContainer(Defaults.Containers.Metadata, 100, HeadingText = "Metadata")]
    public abstract class PartModelBase : ContentItem, IPart
    {
    }
}
