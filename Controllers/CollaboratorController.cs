using Microsoft.AspNetCore.Mvc;
using Proyecto.Bll;
using Proyecto.Helpers.Models;
using Proyecto.Models.Colaborador;
using Proyecto.Models.Collaborator;
using Proyecto.Models.Project;
using Proyecto.Models.Proyecto;
using Proyecto.Helpers.Vars;
using Proyecto.Models.ProyectoColaborador;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        CollaboratorBll bll = new CollaboratorBll();
        // GET: api/<CollaboratorController>
        [HttpGet]
       
        public ResponseGeneralModel<List<CollaboratorAllResponse>> Get()
        {
            return new ResponseGeneralModel<List<CollaboratorAllResponse>>(200, bll.GetCollaborators(), "");
        }

  

        // POST api/<CollaboratorController>
        [HttpPost]
        public ResponseGeneralModel<List<CollaboratorAllResponse>> Post([FromBody] CollaboratorAddRequest item)
        {
            bool isOk = bll.AddCollaborators(item);
            return new ResponseGeneralModel<List<CollaboratorAllResponse>>((isOk) ? 200 : 500, null, (isOk) ? Message.addCollaboratorOk : Message.addProjectError);
        }


        

        [HttpPost("register")]
        public ResponseGeneralModel<string> RegisterCollaborator([FromBody] ProjectCollaboratorRegisterRequest request)
        {
            return bll.RegisterCollaboratorInProject(request);
        }

       

       
    }
}
