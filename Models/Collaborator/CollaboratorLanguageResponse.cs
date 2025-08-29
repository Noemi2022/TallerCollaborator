using Proyecto.Models.Collaborator;
using Proyecto.Models.Language;

namespace Proyecto.Models.Collaborator
{
    public class CollaboratorLanguageResponse
    {
        public string id { get; set; }
        public string name { get; set; } //aqui hice cambios######
        public List<LanguageModel> languages { get; set; }

      //  LanguageAllResponse
        public string GetId()   // This is the getter
        {
            return id;
        }
        public void SetId(string newid)   // This is the setter, new value
        {
            id = newid;
        }
    }
    }
