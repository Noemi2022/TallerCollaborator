using Proyecto.Helpers.Models;
using Proyecto.Models.Project;
using Proyecto.Models.Proyecto;

namespace Proyecto.Bll.Project
{
    public interface IProjectBll
    {
        public List<ProjectAllResponse> GetProjects();
        
        public ResponseGeneralModel<ProjectAllResponse?> GetProjectById(string id);
        public List<ProjectWithCollaboratorResponse> ListProjectWithCollaborator();
       
        
    }
}
