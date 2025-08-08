using Proyecto.Models.ProyectoColaborador;

namespace Proyecto.Repository
{
    public class CollaboratorLanguageRepository
    {
        public static List<ProjectCollaboratorModel> projectCollaborator = new List<ProjectCollaboratorModel>();

        public bool SaveProjectCollaborator(ProjectCollaboratorModel model)
        {
            projectCollaborator.Add(model);
            return true;
        }

        public List<ProjectCollaboratorModel> GetCollaborator()
        {
            return projectCollaborator;
        }

        public List<ProjectCollaboratorModel> GetCollaboratorByProjectId(string projectId)
        {
            return projectCollaborator.Where((projectcollaborator) => projectcollaborator.GetCollaborator() == projectId).ToList();
        }
    }
}
