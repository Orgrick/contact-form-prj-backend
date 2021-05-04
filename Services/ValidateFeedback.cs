using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace test_task.Services
{
    public class ValidateFeedback
    {
        private bool nameIsValid = false;
        private bool emailIsValid = false;
        private bool telIsValid = false;
        private bool mesIsValid = false;
        public ValidateFeedback(Feedback feedback)
        {
            validateName(feedback.name);
            validateEmail(feedback.email);
            validateTel(feedback.tel);
            validateMessage(feedback.message);
        }

        private void validateName(string name)
        {
            if(name.Length == 0)
            {
                return;
            }
            nameIsValid = true;
            return;
        }

        private void validateMessage(string mes)
        {
            if (mes.Length == 0)
            {
                return;
            }
            mesIsValid = true;
            return;
        }

        private void validateEmail(string email)
        {
            if (email.Length == 0)
            {
                return;
            }
            string pattern = @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$";

            if (Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                emailIsValid = true;
                return;
            }
        }

        private void validateTel(string tel)
        {
            if (tel.Length == 0)
            {
                return;
            }
            string pattern = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

            if (Regex.IsMatch(tel, pattern))
            {
                telIsValid = true;
                return;
            }
        }

        public string[] getInValidInputs()
        {
            var inValidInput = new List<string>();
            if (!nameIsValid)
            {
                inValidInput.Add("name");
            }

            if (!emailIsValid)
            {
                inValidInput.Add("email");
            }

            if (!telIsValid)
            {
                inValidInput.Add("tel");
            }

            if (!mesIsValid)
            {
                inValidInput.Add("message");
            }
            return inValidInput.ToArray();
        }
    }
}
