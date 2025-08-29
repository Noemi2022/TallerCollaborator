using System.Reflection;
using Proyecto.Helpers.Models;
using Proyecto.Helpers.Vars;
using Proyecto.Models.Colaborador;
using Proyecto.Models.Collaborator;
using Proyecto.Models.Language;
using Proyecto.Models.Proyecto;
using Proyecto.Models.ProyectoColaborador;
using Proyecto.Repository;
namespace Proyecto.Bll
{
    public class CollaboratorBll
    {

        CollaboratorRepository repository = new CollaboratorRepository();
       

        public List<CollaboratorAllResponse> GetCollaborators()
        {
            List<CollaboratorAllResponse> list = new List<CollaboratorAllResponse>();
            foreach (CollaboratorModel model in repository.GetCollaborators())
            {
                CollaboratorAllResponse response = ModelToResponse(model);

                list.Add(response);
            }

            return list;
        }

    public bool AddCollaborators(CollaboratorAddRequest request)
        {
            CollaboratorModel model = new CollaboratorModel(request.name);

            return repository.AddNewCollaborator(model);
        }

        public ResponseGeneralModel<string> RegisterCollaboratorInProject(ProjectCollaboratorRegisterRequest request)
        {  
            CollaboratorModel? studentFind = repository.GetCollaboratorsById(request.collaboratorId);
            if (studentFind == null) return new ResponseGeneralModel<string>(400, null, Message.saveProjectCollaboratorErrorIdCollaborator, Message.saveProjectCollaboratorErrorIdCollaborator);

           ProjectModel? projectFind = (new ProjectRepository()).GetProjectById(request.projectId);
            if (projectFind == null) return new ResponseGeneralModel<string>(400, null, Message.saveProjectCollaboratorErrorIdProject, Message.saveProjectCollaboratorErrorIdProject);


            ProjectCollaboratorModel modelSave = new ProjectCollaboratorModel(request.projectId, request.collaboratorId);
            bool isOk = (new ProjectCollaboratorRepository()).SaveProjectCollaborator(modelSave);

            return new ResponseGeneralModel<string>((isOk) ? 200 : 500, null, (isOk) ? Message.saveProjectCollaboratorOk : Message.errorGeneral, "");
        }



        private CollaboratorAllResponse ModelToResponse(CollaboratorModel model)
        {
            CollaboratorAllResponse response = new CollaboratorAllResponse();
            response.id = model.GetId();
            response.name = model.GetName();
           
            return response;
        }


       
    }
}
