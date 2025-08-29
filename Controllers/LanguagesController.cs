using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Bll;
using Proyecto.Bll.Project;
using Proyecto.Helpers.Models;
using Proyecto.Helpers.Vars;
using Proyecto.Models.Collaborator;
using Proyecto.Models.Language;
using Proyecto.Models.Proyecto;
using Proyecto.Validator.Proyecto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {

       LanguageBll bll = new LanguageBll();
        ProjectValidate validate = new ProjectValidate();
        // GET: api/<LanguagesController>
        [HttpGet]
        public ResponseGeneralModel<List<LanguageAllResponse>> Get()
        {
            return new ResponseGeneralModel<List<LanguageAllResponse>>(200, bll.GetLanguages(), "");
        }



        // POST api/<LanguagesController>
        [HttpPost]
        public ResponseGeneralModel<List<LanguageModel>> Post([FromBody] LanguageAddRequest item)
        {

            try
            {
                ResponseGeneralModel<List<LanguageModel>> validates = validate.AddLanguagess(item);
                if (validates.code != 200) return validates;
                return bll.AddLanguages(item);
            }
            catch
            {
                return new ResponseGeneralModel<List<LanguageModel>>(500, null, Message.errorGeneral);
            }

        }


       


    }
}
