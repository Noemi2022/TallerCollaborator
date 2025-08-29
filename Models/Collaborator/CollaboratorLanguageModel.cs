using System.Xml.Linq;
using Proyecto.Models.Colaborador;
using Proyecto.Models.Language;
using Proyecto.Repository;

namespace Proyecto.Models.Collaborator
{
    public class CollaboratorLanguageModel
    {
        private string id { get; set; }
      
       
        private List<LanguageModel> languages { get; set; }

       
        public CollaboratorLanguageModel(string idCollaboratorLanguage, List<LanguageModel> languages)
        {
          
            this.id = idCollaboratorLanguage;
         
            this.languages = languages;
        }

        

       

        public string GetId() { return id; }
      
        public List<LanguageModel> GetLanguages (){ return languages; }


    }

   


      

    }
