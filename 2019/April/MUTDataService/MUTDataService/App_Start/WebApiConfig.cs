using System.Web.Http;
using MUTDataService.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace MUTDataService
{
	public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services
			ODataModelBuilder builder = new ODataConventionModelBuilder();
			builder.EntitySet<MUTJob>("MUTJob");
			config.MapODataServiceRoute(
				routeName: "odata",
				routePrefix: "odata",
				model: builder.GetEdmModel());

			//// Web API routes
			//config.MapHttpAttributeRoutes();

   //         config.Routes.MapHttpRoute(
   //             name: "DefaultApi",
   //             routeTemplate: "api/{controller}/{id}",
   //             defaults: new { id = RouteParameter.Optional }
   //         );
        }
    }
}
