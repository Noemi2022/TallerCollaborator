using System.Reflection;
using Proyecto.Helpers.Models;
using Proyecto.Helpers.Vars;
using Proyecto.Models.Colaborador;
using Proyecto.Models.Collaborator;
using Proyecto.Models.Proyecto;
using Proyecto.Models.ProyectoColaborador;
using Proyecto.Repository;

namespace Proyecto.Bll.Project
{
    public class CollaboratorLanguageBll
    {
        CollaboratorLanguageRepository repositoryCollaboratorLanguage = new CollaboratorLanguageRepository();

        CollaboratorRepository allCollaborators = new CollaboratorRepository();
        LanguageRepository languageRepository = new LanguageRepository();   

        public ResponseGeneralModel<string> NewLanguageInCollaborator(CollaboratorLanguageRequest requestCollaborator)
        {
           

            

            //2) Una vez que se encuentra el colaborado, se debe envíar a guardar el dato completo
            bool response = repositoryCollaboratorLanguage.AddCollaboratorLanguage(requestCollaborator.id, requestCollaborator.languages);
            if (!response) {
                return new ResponseGeneralModel<string>(400, null, "error no se pudo agregar",""); 
            }
            
                return new ResponseGeneralModel<string>(200, null, Message.mensajePersonalizado, "");
 

        }
        public List<CollaboratorLanguageResponse> GetCollaboratorsLanguage()
        {
            List<CollaboratorLanguageResponse> list = new List<CollaboratorLanguageResponse>();


            // Obten la lista de registros de colaboradores
            List<CollaboratorModel> listaColaboradores = allCollaborators.GetCollaborators();


            // Obtener la lista de CollaboratorLeangugues
            List<CollaboratorLanguageModel> listaColaboradoresLenaguages = repositoryCollaboratorLanguage.GetElGordo();

            // REcorrer la lista de lista lista de CollaboratorLeangugues y relacionar el colaborador con el CollaboratorsLanguage
            foreach (var colaboradoresLenaguage in listaColaboradoresLenaguages)
            {
                CollaboratorLanguageResponse newColaborator = new CollaboratorLanguageResponse();
                newColaborator.languages = colaboradoresLenaguage.GetLanguages();
                newColaborator.id = colaboradoresLenaguage.GetId();

                foreach (var colaborador in listaColaboradores)
                {
                    if (colaborador.GetId().Equals(colaboradoresLenaguage.GetId()))
                    {
                        newColaborator.name = colaborador.GetName();

                    }
                }

                list.Add(newColaborator);
            }
            return list;
        }
        public ResponseGeneralModel<CollaboratorLanguageResponse?> GetCollaboratorById(string id)
        {
            CollaboratorLanguageModel? model = repositoryCollaboratorLanguage.GetCollaboratorById(id);
            List<CollaboratorModel> listaColaboradores = allCollaborators.GetCollaborators();

            if (model == null)
            {
                return new ResponseGeneralModel<CollaboratorLanguageResponse?>(404, null, Message.getCollaboratorLanguageByIdNotFound);
            }

            CollaboratorLanguageResponse response = new CollaboratorLanguageResponse();
            response.id = model.GetId();
            response.languages = model.GetLanguages();
            foreach (var colaborador in listaColaboradores)
            {             
                    response.name = colaborador.GetName();
            }
            return new ResponseGeneralModel<CollaboratorLanguageResponse?>(200, response, Message.getCollaboratorLanguageByIdOk);
        }

        public bool DeleteLanguage(string id)
        {
            return languageRepository.RemoveLanguage(id);
        }



    }
}
