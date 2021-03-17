using Microsoft.OData.Edm;
using System.Web.Http;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Batch;
using ODataV4ServiceAPI4.Models;

namespace ODataV4ServiceAPI4
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();
        }
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "Demos";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Customer>("Customer");
            builder.EntitySet<Order>("Order");
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}
