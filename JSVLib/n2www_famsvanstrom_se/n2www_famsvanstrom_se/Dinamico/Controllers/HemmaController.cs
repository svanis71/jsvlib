using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using www.fam_svanstrom.se.Models;

namespace www.fam_svanstrom.se.Dinamico.Controllers
{
    public class HemmaController : ApiController
    {
        public string Get()
        {
            return "0000";
        }

        public string Post([FromBody]PostStatusRequestData indata)
        {
            Debug.WriteLine(indata.ToString());
            return "OK";
        }
    }
}