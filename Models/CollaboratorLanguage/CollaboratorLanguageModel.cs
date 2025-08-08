namespace Proyecto.Models.CollaboratorLanguage
{
    public class CollaboratorLanguageModel
    {
        private string id { get; set; }
        private string collaboratorId { get; set; }
        private string languageId { get; set; }


        public CollaboratorLanguageModel(string collaboratorId, string languageId)
        {
            Guid guid = Guid.NewGuid();
            this.id = guid.ToString();
            this.collaboratorId = collaboratorId;
            this.languageId = languageId;
        }

        public string GetId() { return id; }

        public string GetCollaborator() { return collaboratorId; }

        public string GetLanguage() { return languageId; }
    }
}
