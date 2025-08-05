using Proyecto.Models.Collaborator;
using Proyecto.Models.Language;

namespace Proyecto.Models.Project
{
    public class ProjectWithCollaboratorResponse
    {
        public string projectId { get; set; }
        public string name { get; set; }

        public List<CollaboratorAllResponse> collaborators { get; set; }
    }
}
