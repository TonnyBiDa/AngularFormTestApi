using System;
using BidOneApi.Models;
using Microsoft.AspNetCore.Mvc;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace BidOneApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SubmitFormController : Controller
    {
        [HttpPost]
        public ActionResult<CommonResult<string>> SubmitFormPost([FromBody] FormModel jsonData)
        {
            dynamic json = jsonData;
            string firstName = json.firstName;
            string lastName = json.lastName;
            string dob = json.dob;
            string email = json.email;

            bool emailValid = emailValidation.IsValidEmail(email);
            var result = new CommonResult<string>();
            if (string.IsNullOrWhiteSpace(firstName))
            {
                result.ErrorMessage = "First name not valid ";
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                result.ErrorMessage += "Last name not valid ";
            }

            DateTime dDate;
            if (!DateTime.TryParse(dob, out dDate))
            {
                result.ErrorMessage += "DOB not valid ";
            }

            if (!emailValid)
            {
                result.ErrorMessage += "Email not valid ";
            }

            if (result.ErrorMessage==null)
            {
                result.IsSuccess = true;
            }
            else
            {
                result.IsSuccess = false;
            }
           
            return result;
        }
    }
}
