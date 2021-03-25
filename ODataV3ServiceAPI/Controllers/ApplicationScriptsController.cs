using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData.Routing;
using ODataServiceDemo;
using ODataV3ServiceAPI.Data;
using System.Web.Http.OData;

namespace ODataV3ServiceAPI.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ODataServiceDemo;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<ApplicationScript>("ApplicationScripts");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ApplicationScriptsController : ODataController
    {
        private ODataV3ServiceAPIContext db = new ODataV3ServiceAPIContext();

        // GET: odata/ApplicationScripts
        [EnableQuery]
        public IQueryable<ApplicationScript> GetApplicationScripts()
        {
            return db.ApplicationScripts;
        }

        // GET: odata/ApplicationScripts(5)
        [EnableQuery]
        public SingleResult<ApplicationScript> GetApplicationScript([FromODataUri] int key)
        {
            return SingleResult.Create(db.ApplicationScripts.Where(applicationScript => applicationScript.ID == key));
        }

        // PUT: odata/ApplicationScripts(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<ApplicationScript> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationScript applicationScript = db.ApplicationScripts.Find(key);
            if (applicationScript == null)
            {
                return NotFound();
            }

            patch.Put(applicationScript);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationScriptExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(applicationScript);
        }

        // POST: odata/ApplicationScripts
        public IHttpActionResult Post(ApplicationScript applicationScript)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApplicationScripts.Add(applicationScript);
            db.SaveChanges();

            return Created(applicationScript);
        }

        // PATCH: odata/ApplicationScripts(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ApplicationScript> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationScript applicationScript = db.ApplicationScripts.Find(key);
            if (applicationScript == null)
            {
                return NotFound();
            }

            patch.Patch(applicationScript);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationScriptExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(applicationScript);
        }

        // DELETE: odata/ApplicationScripts(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ApplicationScript applicationScript = db.ApplicationScripts.Find(key);
            if (applicationScript == null)
            {
                return NotFound();
            }

            db.ApplicationScripts.Remove(applicationScript);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationScriptExists(int key)
        {
            return db.ApplicationScripts.Count(e => e.ID == key) > 0;
        }
    }
}
