namespace Proyecto.Models.ProyectoColaborador
{
    public class ProjectCollaboratorModel
    {
        private string id { get; set; }
        private string projectId { get; set; }
        private string collaboratorId { get; set; }


        public ProjectCollaboratorModel(string projectId, string collaboratorId)
        {
            Guid guid = Guid.NewGuid();
            this.id = guid.ToString();
            this.projectId = projectId;
            this.collaboratorId = collaboratorId;
        }

        public string GetId() { return id; }

        public string GetProject() { return projectId; }

        public string GetCollaborator() { return collaboratorId; }
    }
}
