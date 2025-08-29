using Microsoft.AspNetCore.Mvc;
using Proyecto.Bll;
using Proyecto.Bll.Project;
using Proyecto.Helpers.Models;
using Proyecto.Models.Collaborator;
using Proyecto.Helpers.Vars;
using Proyecto.Models.Language;
using Proyecto.Models.Proyecto;
using Proyecto.Models.ProyectoColaborador;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorLanguagesController : ControllerBase
    {
        CollaboratorLanguageBll bll = new CollaboratorLanguageBll();

        // GET: api/<CollaboratorController>
        [HttpGet]

        public ResponseGeneralModel<List<CollaboratorLanguageResponse>> Get()
        {
            return new ResponseGeneralModel<List<CollaboratorLanguageResponse>>(200, bll.GetCollaboratorsLanguage(), "");
        }

        // GET api/<CollaboratorController>/2
        [HttpGet("{id}")]
        public ResponseGeneralModel<CollaboratorLanguageResponse?> Get(string id)
        {
            try
            {
                return bll.GetCollaboratorById(id);
            }
            catch (Exception ex)
            {
                return new ResponseGeneralModel<CollaboratorLanguageResponse?>(500, null, Message.errorGeneral);
            }
        }

        // POST api/<CollaboratorLanguagesController>
        [HttpPost]
        public ResponseGeneralModel<string> Post([FromBody] CollaboratorLanguageRequest item)
        {
            return bll.NewLanguageInCollaborator(item);
           
        }

        // DELETE api/<LanguageController>/5
        [HttpDelete("{id}")]
        public ResponseGeneralModel<List<LanguageModel>> Delete(string id)
        {
            bool isOk = false;
            try
            {
                isOk = bll.DeleteLanguage(id);
            }
            catch { isOk = false; }

            return new ResponseGeneralModel<List<LanguageModel>>((isOk) ? 200 : 500, null, (isOk) ? Message.deleteCollaboratorLanguageOk : Message.deleteCollaboratorLanguageError);
        }


    }
}
