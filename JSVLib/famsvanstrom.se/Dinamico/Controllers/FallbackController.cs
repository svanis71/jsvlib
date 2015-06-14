// // famsvanstrom.se: FallbackController.cs
// // Author: Johan Svanström
// // Created: 2015-04-30
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using Dinamico.Models;
using N2.Web;
using N2.Web.Mvc;

#endregion

namespace Dinamico.Controllers
{
    [Controls(typeof(PageModelBase))]
    public class FallbackController : ContentController
    {
    }
}
