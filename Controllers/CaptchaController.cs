using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_task.Utils;
using System.IO;

namespace test_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController : ControllerBase
    {
        // private static string code;
        [HttpGet]
        public IActionResult Get()
        {
            int width = 100;
            int height = 36;
            var captchaCode = Captcha.GenerateCaptchaCode();
            var result = Captcha.GenerateCaptchaImage(width, height, captchaCode);
            HttpContext.Session.SetString("key", result.CaptchaCode);
            // CaptchaController.code = HttpContext.Session.GetString("key");
            Stream s = new MemoryStream(result.CaptchaByteData);
            return new FileStreamResult(s, "image/png");
        }

        [HttpPost]
        public IActionResult Post([FromBody] keyCode res)
        {
            string validKey = HttpContext.Session.GetString("key");
            // string validKey = CaptchaController.code;
            if (validKey == res.key)
            {
                return Ok(new { success = true });
            }
            return Ok(new { success = false });
        }

        public class keyCode
        {
            public string key { get; set; }
        }
    }
}
