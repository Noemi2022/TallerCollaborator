using Proyecto.Models.Colaborador;
using Proyecto.Models.Collaborator;
using Proyecto.Repository;
using Proyecto.Helpers.Models;

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

        //public bool AddCollaboratos(CollaboratorAddRequest request)
        //{
        //    CollaboratorModel model = new CollaboratorModel(request.name, request.lastName, request.year);

        //    return repository.AddNewStudent(model);
        //}

        //public ResponseGeneralModel<string> RegisterStudentInClassroom(ClassroomStudentRegisterRequest request)
        //{
        //    CollaboratorModel? studentFind = repository.GetStudentsById(request.studentId);
        //    if (studentFind == null) return new ResponseGeneralModel<string>(400, null, Message.saveClassromStudentErrorIdStudent, Message.saveClassromStudentErrorIdStudent);

        //    ClassroomModel? classroomFind = (new ClassroomRepository()).GetClassroomById(request.classroomId);
        //    if (classroomFind == null) return new ResponseGeneralModel<string>(400, null, Message.saveClassromStudentErrorIdClassroom, Message.saveClassromStudentErrorIdClassroom);


        //    ClassroomStudentModel modelSave = new ClassroomStudentModel(request.classroomId, request.studentId);
        //    bool isOk = (new ClassroomStudentRepository()).SaveClassroomStudent(modelSave);

        //    return new ResponseGeneralModel<string>((isOk) ? 200 : 500, null, (isOk) ? Message.saveClassromStudentOk : Message.errorGeneral, "");
        //}



        private CollaboratorAllResponse ModelToResponse(CollaboratorModel model)
        {
            CollaboratorAllResponse response = new CollaboratorAllResponse();
            response.SetId(model.GetId());
            response.name = model.GetName();
           
            return response;
        }
    }
}
