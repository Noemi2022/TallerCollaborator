using System.Xml.Linq;
using Proyecto.Models.Colaborador;

namespace Proyecto.Repository
{
    public class CollaboratorRepository
    {
        static List<CollaboratorModel> collaborators = new List<CollaboratorModel>();

        public List<CollaboratorModel> GetCollaborators()
        {
            return collaborators;
        }

        public CollaboratorModel? GetCollaboratorsById(string id)
        {
            return collaborators.FirstOrDefault((model) => model.GetId() == id);
        }


        public CollaboratorModel? GetLastCollaborator()
        {
            int countClass = collaborators.Count();
            if (countClass == 0) return null;
            return collaborators[countClass - 1];
        }

        public bool AddNewCollaborator(CollaboratorModel model)
        {
            collaborators.Add(model);

            return true;
        }

        //public bool RemoveStudent(string id)
        //{
        //    CollaboratorModel? model = GetStudentsById(id);
        //    if (model == null) return false;
        //    return students.Remove(model);
        //}
    }
}
