using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using PuppeteerSharp;
using System;
using System.Dynamic;

namespace ExampleNodejs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pdf2Controller : ControllerBase
    {

        public pdf2Controller()
        {
    
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                using var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
                var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true
                });
                var page = await browser.NewPageAsync();
                await page.GoToAsync("https://new-mtn.eleva.school/#/auth/login?returnUrl=%2F");
                // await page.PdfAsync(outputFile);
                //await page.PdfAsync($"{DateTime.Today.ToShortDateString().Replace("/", "-")}.pdf");

              var file =  await page.PdfDataAsync();
              return File(file, "application/pdf", "file.pdf");

              //return Ok("Successfully created PDF document.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
