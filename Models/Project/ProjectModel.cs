namespace Proyecto.Models.Proyecto
{
    public class ProjectModel
    {

        private string id;
        private string name;
        private DateTime dateReg;

        public ProjectModel(string name)
        {
            Guid guid = Guid.NewGuid();
            this.id = guid.ToString();
            this.name = name;          
            this.dateReg = DateTime.Now;
        }

        public string GetId() { return id; }

        public string GetName() { return name; }


        public DateTime GetDateReg() { return dateReg; }

    }
}
