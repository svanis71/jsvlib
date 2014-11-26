using System;
using System.Web;
using System.Web.Routing;

namespace Contacts.Helpers
{
    public class HttpHandlerRoute : IRouteHandler
    {
        private Type _handlerType;
        public HttpHandlerRoute(Type handlerType)
        {
            _handlerType = handlerType;
        }

        #region Implementation of IRouteHandler

        /// <summary>
        /// Provides the object that processes the request.
        /// </summary>
        /// <returns>
        /// An object that processes the request.
        /// </returns>
        /// <param name="requestContext">An object that encapsulates information about the request.</param>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return (IHttpHandler)Activator.CreateInstance(_handlerType);
        }

        #endregion
    }
}
