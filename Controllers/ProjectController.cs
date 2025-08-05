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
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public ResponseGeneralModel<List<ProjectAllResponse>> Get()
        {
            return new ResponseGeneralModel<List<ProjectAllResponse>>(200, bll.GetProjects(), "");
        }

        [HttpGet("collaborator")]
        public ResponseGeneralModel<List<ProjectWithCollaboratorResponse>> GetWithCollaborators()
        {
            return new ResponseGeneralModel<List<ProjectWithCollaboratorResponse>>(200, bll.ListProjectWithCollaborator(), "");
        }

        [HttpGet("prueba/{dato}")]
        public bool GetPrueba(string dato)
        {
            Regex regEx = new Regex(VarHelper.regExParamString);
            return regEx.IsMatch(dato);
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProjectController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
