using System.Xml.Linq;
using Proyecto.Models.Proyecto;

namespace Proyecto.Repository
{
    public class ProjectRepository
    {
        static List<ProjectModel> projects = new List<ProjectModel>();


        //SI PARA EL ID
        public List<ProjectModel> GetList()
        {
            return projects;
        }

        public ProjectModel? GetProjectById(string id)
        {
            return projects.FirstOrDefault((model) => model.GetId() == id);
        }

        public ProjectModel? GetProjectByName(string name)
        {
            return projects.FirstOrDefault((model) => model.GetName() == name);         
        }


        //SI PARA EL ID GetLastProjects() Y gETnEWId y AddNewProject
        public ProjectModel? GetLastProjects()
        {
            int countProject = projects.Count();
            if (countProject == 0) return null;
            return projects[countProject - 1];
        }

        public bool AddNewProject(ProjectModel model)
        {
            projects.Add(model);
            return true;
        }

        //public bool RemoveClassroom(string id)
        //{
        //    ClassroomModel? model = GetClassroomById(id);
        //    if (model == null) return false;
        //    return classrooms.Remove(model);
        //}
    }
}
