using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Bll.Project;
using Proyecto.Helpers.Models;
using Proyecto.Models.Project;
using Proyecto.Models.Proyecto;
using Proyecto.Helpers.Vars;

using Proyecto.Validator.Proyecto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {



        private readonly IConfiguration _configuration;
        ProjectValidate validate = new ProjectValidate();
        private readonly IProjectBll bll;

        public ProjectController(IConfiguration configuration, IProjectBll projectsBll)
        {
            _configuration = configuration;
            bll = projectsBll;
        }
        // GET: api/<ProjectController>
        [HttpGet]
        
        public ResponseGeneralModel<List<ProjectAllResponse>> Get()
        {
            return new ResponseGeneralModel<List<ProjectAllResponse>>(200, bll.GetProjects(), "");
        }

        [HttpGet("collaborators")]
        public ResponseGeneralModel<List<ProjectWithCollaboratorResponse>> GetWithCollaborators()
        {
            return new ResponseGeneralModel<List<ProjectWithCollaboratorResponse>>(200, bll.ListProjectWithCollaborator(), "");
        }

       

        //[HttpGet("prueba/{dato}")]
        //public bool GetPrueba(string dato)
        //{
        //    Regex regEx = new Regex(VarHelper.regExParamString);
        //    return regEx.IsMatch(dato);
        //}

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public ResponseGeneralModel<ProjectAllResponse?> Get(string id)
        {
            try
            {
                return bll.GetProjectById(id);
            }
            catch (Exception ex)
            {
                return new ResponseGeneralModel<ProjectAllResponse?>(500, null, Message.errorGeneral);
            }
        }



        // POST api/<ProjectController>
        [HttpPost]
       
        public ResponseGeneralModel<List<ProjectModel>> Post([FromBody] ProjectAddRequest item)
        {
            //bool isOk = bll.AddClassroom(item);
            // return new ResponseGeneralModel<List<ClassroomModel>>((isOk) ? 200 : 500, null, ""); //esto es if ternario
            try
            {
                ResponseGeneralModel<List<ProjectModel>> validateD = validate.AddClassroom(item);
                if (validateD.code != 200) return validateD;

                return bll.AddProject(item);
            }
            catch
            {
                return new ResponseGeneralModel<List<ProjectModel>>(500, null, Message.errorGeneral);
            }
        }



        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }




        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void delete(int id, [FromBody] string value)
        {
        }

    }
}
