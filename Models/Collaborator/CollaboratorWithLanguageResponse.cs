using Proyecto.Models.Language;

namespace Proyecto.Models.Colaborador
{
    public class CollaboratorWithLanguageResponse
    {
        public string collaboratorId { get; set; }
        public string name { get; set; }

        public List<LanguageAllResponse> languages { get; set; }
    }
}
