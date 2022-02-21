using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//imported system.data
using System.Data;



namespace server.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            //just for testing response in json format
            DataTable dt = new DataTable();
            dt.Columns.Add("StudID");
            dt.Columns.Add("StudName");
            dt.Rows.Add(2, "Sajeev");
            dt.Rows.Add(3, "Keerththi");
            return Request.CreateResponse(HttpStatusCode.OK, dt);



        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
