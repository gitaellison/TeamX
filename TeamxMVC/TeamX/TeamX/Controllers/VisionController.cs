using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TeamX.Controllers
{
    public class VisionController : ApiController
    {
        public IHttpActionResult Get(string imgsrc)
        {
            return Ok(ComputerVisionIntegration.MakeAnalysisRequest(imgsrc).Result);
        }

    }
}
