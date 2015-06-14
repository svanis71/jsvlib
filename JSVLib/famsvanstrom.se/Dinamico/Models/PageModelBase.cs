// // famsvanstrom.se: PageModelBase.cs
// // Author: Johan Svanström
// // Created: 2015-04-30
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using N2;
using N2.Definitions;
using N2.Details;
using N2.Integrity;
using N2.Web.UI;

#endregion

namespace Dinamico.Models
{
    /// <summary>
    /// Base implementation for pages on a dinamico site.
    /// </summary>
    [WithEditableTitle]
    [WithEditableName(ContainerName = Defaults.Containers.Metadata)]
    [WithEditableVisibility(ContainerName = Defaults.Containers.Metadata)]
    [SidebarContainer(Defaults.Containers.Metadata, 100, HeadingText = "Metadata")]
    [TabContainer(Defaults.Containers.Content, "Content", 1000)]
    [RestrictParents(typeof(IPage))]
    public abstract class PageModelBase : ContentItem, IPage
    {
    }
}
