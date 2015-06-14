// // famsvanstrom.se: ContentPart.cs
// // Author: Johan Svanström
// // Created: 2015-04-30
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using N2;
using N2.Details;

#endregion

namespace Dinamico.Models
{
    /// <summary>
    /// This part model is the base of several "template first" definitions 
    /// located in /dinamico/default/views/contentparts/ 
    /// </summary>
    [PartDefinition]
    [WithEditableTemplateSelection(ContainerName = Defaults.Containers.Metadata)]
    public class ContentPart : PartModelBase
    {
    }
}
