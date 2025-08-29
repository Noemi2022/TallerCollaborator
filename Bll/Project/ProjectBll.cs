using System.IO.Pipelines;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Proyecto.Helpers.Models;
using Proyecto.Helpers.Vars;
using Proyecto.Models.Colaborador;
using Proyecto.Models.Collaborator;
using Proyecto.Models.Project;
using Proyecto.Models.Proyecto;
using Proyecto.Models.ProyectoColaborador;
using Proyecto.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto.Bll.Project

{
    public class ProjectBll:IProjectBll
    {
        ProjectRepository repository = new ProjectRepository();

        private readonly IConfiguration _configuration;

        public ProjectBll(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       
        public List<ProjectAllResponse> GetProjects()
        {
            if (repository.GetList().Count() == 0) //getList es de la clase ClassroomRepository 
            {
                ProjectModel project001 = new ProjectModel("Sistemas de Ventas");
                repository.AddNewProject(project001);
                ProjectModel project002 = new ProjectModel("Sistema de Registros");
                repository.AddNewProject(project002);

                CollaboratorModel collaborator001 = new CollaboratorModel("Helen");
                CollaboratorModel collaborator002 = new CollaboratorModel("Noemi");
                CollaboratorRepository collabRep = new CollaboratorRepository();
                collabRep.AddNewCollaborator(collaborator001);
                collabRep.AddNewCollaborator(collaborator002);

                ProjectCollaboratorRepository projCollabRep = new ProjectCollaboratorRepository();
                projCollabRep.SaveProjectCollaborator(new ProjectCollaboratorModel(project001.GetId(), collaborator001.GetId()));
                projCollabRep.SaveProjectCollaborator(new ProjectCollaboratorModel(project001.GetId(), collaborator002.GetId()));
                projCollabRep.SaveProjectCollaborator(new ProjectCollaboratorModel(project002.GetId(), collaborator002.GetId()));
            }


            List<ProjectAllResponse> list = new List<ProjectAllResponse>();
            foreach (ProjectModel model in repository.GetList())
            {
                ProjectAllResponse response = ModelToResponse(model);
                list.Add(response);
            }
            return list;
        }







        public ResponseGeneralModel<ProjectAllResponse?> GetProjectById(string id)
        {
            ProjectModel? model = repository.GetProjectById(id);

            if (model == null)
            {
                return new ResponseGeneralModel<ProjectAllResponse?>(404, null, Message.getProjectByIdNotFound);
            }

            ProjectAllResponse response = ModelToResponse(model);

            return new ResponseGeneralModel<ProjectAllResponse?>(200, response, Message.getProjectByIdOk);
        }


        public List<ProjectWithCollaboratorResponse> ListProjectWithCollaborator()
        {
            return (
                from model in repository.GetList()
                select new ProjectWithCollaboratorResponse()
                {
                    projectId = model.GetId(),
                    name = model.GetName(),
                    collaborators = (from projectCollaborator in new ProjectCollaboratorRepository().GetCollaboratorByProjectId(model.GetId())
                                join collabModel in new CollaboratorRepository().GetCollaborators() on projectCollaborator.GetCollaborator() equals collabModel.GetId()
                                select new CollaboratorAllResponse()
                                {
                                     
                                    id = collabModel.GetId(),
                                    name = collabModel.GetName(),
                                   
                                }).ToList()
                }
            ).ToList();
           

        }

        public ResponseGeneralModel<List<ProjectModel>> AddProject(ProjectAddRequest request)
        {
            ProjectModel modelF = repository.GetProjectByName(request.name);

            if (modelF == null)
            {
                ProjectModel model = new ProjectModel(request.name);

                bool isAdd = repository.AddNewProject(model);

                return new ResponseGeneralModel<List<ProjectModel>>(isAdd ? 200 : 500, null, isAdd ? Message.addProjectOk : Message.addProjectError);
            }
            else
            {
                return new ResponseGeneralModel<List<ProjectModel>>(400, null, Message.addProjectDuplicate);
            }
        }

        private ProjectAllResponse ModelToResponse(ProjectModel model)
        {
            ProjectAllResponse response = new ProjectAllResponse();
            response.id = model.GetId();
            response.name = model.GetName();
            response.dateReg = model.GetDateReg();
            return response;
        }
    }
}















