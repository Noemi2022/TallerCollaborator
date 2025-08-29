using Proyecto.Models.Colaborador;
using Proyecto.Models.Collaborator;
using Proyecto.Models.Language;
using Proyecto.Models.ProyectoColaborador;

namespace Proyecto.Repository
{
    public class CollaboratorLanguageRepository
    {
        
        static List<CollaboratorLanguageModel> collaboratorsLanguage = new List<CollaboratorLanguageModel>();

        public bool AddCollaboratorLanguage(string idColaborador, List<LanguageModel> language)
        {
            CollaboratorLanguageModel collaborator = new CollaboratorLanguageModel(idColaborador, language);
            collaboratorsLanguage.Add(collaborator);
            return true;
        }

        public List<CollaboratorLanguageModel> GetElGordo()
        {
            return collaboratorsLanguage;
        }

        public CollaboratorLanguageModel? GetCollaboratorById(string id)
        {
            return collaboratorsLanguage.FirstOrDefault((model) => model.GetId() == id);
        }

        public bool RemoveCollaboratorLanguage(string id)
        {
           CollaboratorLanguageModel? model = GetCollaboratorById(id);
            if (model == null) return false;
            return collaboratorsLanguage.Remove(model);  //para usar el remove tengo que madnar tod el modelo
        }
    }
}
