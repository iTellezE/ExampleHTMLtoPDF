using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using System;
using System.Dynamic;

namespace ExampleNodejs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pdfController : ControllerBase
    {
        private readonly INodeServices nodeServices;
        private const string NODE_POST_SCRIPT = "./Node/htmlTopdf";

        public pdfController(INodeServices nodeServices)
        {
            this.nodeServices = nodeServices;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                dynamic postResult = await nodeServices.InvokeAsync<ExpandoObject>(NODE_POST_SCRIPT,2);
                //var file = _converter.Convert(postResult);

               // return Ok("Successfully created PDF document.");
                return File(postResult, "application/pdf", "EmployeeReport.pdf");
                //return Json(postResult);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
