using Microsoft.AspNet.OData;
using ODataV4ServiceAPI4.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ODataV4ServiceAPI3.Controllers
{
    [EnableQuery]
    public class CustomerController : ODataController
    {
        public IHttpActionResult Get()
        {
            return Ok(DemoDataSources.Instance.Customers.AsQueryable());
        }
    }
}