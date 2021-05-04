using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using test_task.Migrations;

namespace test_task.Controllers
{
    [ApiController]
    [Route("api/themes")]
    public class ThemeController : ControllerBase
    {
        private readonly FeedbackContext _dbContext;
        public ThemeController(FeedbackContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var themes = from t in _dbContext.Themes
                         select t.ThemeName;
            var themesList = new List<string>();

            foreach (var theme in themes)
            {
                themesList.Add(theme);
            }

            return Ok(themesList);
        }
    }
}
