using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using test_task.Migrations;
using test_task.Models;
using test_task.Services;

namespace test_task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackContext _dbContext;
        public FeedbackController(FeedbackContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Feedback feedback)
        {
            var validate = new ValidateFeedback(feedback);
            if(validate.getInValidInputs().Length > 0)
            {
                var invalidInputs = validate.getInValidInputs();
                return BadRequest(new { message = "Поля формы не прошли проверку", invalidInputs });
            }

            var contact = new Contact
            {
                ContactName = feedback.name,
                ContactEmail = feedback.email,
                ContactTel = feedback.tel,
            };
            if(isNewContact(contact))
            {
                _dbContext.Contacts.Add(contact);
                _dbContext.SaveChanges();
            }
            Message mes = addMessage(feedback);
            var resMes = new
            {
                contactName = mes.Contact.ContactName,
                theme = mes.Theme.ThemeName,
                content = mes.content
            };

            return Ok(new { message = "Сохранено", resMes });
        }
        private bool isNewContact(Contact condidate)
        {
            var contacts = from t in _dbContext.Contacts
                         select t;

            foreach (var contact in contacts)
            {
                if(condidate.ContactTel == contact.ContactTel && condidate.ContactEmail == contact.ContactEmail)
                {
                    return false;
                }
            }
            return true;
        }

        private Message addMessage(Feedback feedback)
        {
            var contact = (from t in _dbContext.Contacts
                            where t.ContactEmail == feedback.email && t.ContactTel == feedback.tel
                            select t).Single();

            var themes = (from t in _dbContext.Themes
                          where t.ThemeName == feedback.theme
                          select t);
            Theme theme;
            if (themes.Any())
            {
                theme = themes.Single();
            } else
            {
                theme = (from t in _dbContext.Themes
                         where t.ThemeName == "Другое"
                         select t).Single();
            }
            

            var message = new Message()
            {
                Theme = theme,
                Contact = contact,
                content = feedback.message
            };

            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
            return message;
        }
    }
}
