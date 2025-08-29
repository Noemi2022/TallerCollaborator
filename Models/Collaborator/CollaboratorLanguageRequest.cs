using Proyecto.Models.Language;

namespace Proyecto.Models.Collaborator
{
    public class CollaboratorLanguageRequest
    {
        public string id { get; set; }

        public List<LanguageModel> languages { get; set; }
    }
}
